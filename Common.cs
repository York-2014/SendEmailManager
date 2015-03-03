using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace SendEmailManager
{
    class Common
    {
        #region MD5
        /// <summary>
        /// 取得输入字符串的MD5哈希值
        /// </summary>
        /// <param name="argInput">输入字符串</param>
        /// <returns>MD5哈希值</returns>
        public static string GetMd5Hash(string argInput)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(argInput));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// 验证MD5哈希值
        /// </summary>
        /// <param name="argInput">输入字符串</param>
        /// <param name="argHash">哈希值</param>
        /// <returns>相同返回TRUE,不同返回FALSE</returns>
        public static bool VerifyMd5Hash(string argInput, string argHash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(argInput);

            // Create a StringComparer an comare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, argHash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 同步通过POST方式发送数据
        /// <summary>
        /// 通过POST方式发送数据
        /// </summary>
        /// <param name="Url">url</param>
        /// <param name="postDataStr">Post数据</param>
        /// <param name="cookie">Cookie容器</param>
        /// <returns></returns>
        public static string SendDataByPost(string Url, string postDataStr, ref CookieContainer cookie)
        {
            string retString = null;
            HttpWebRequest request = null;
            Stream myRequestStream = null;
            StreamWriter myStreamWriter = null;
            HttpWebResponse response = null;
            Stream myResponseStream = null;
            StreamReader myStreamReader = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(Url);
                if (cookie.Count == 0)
                {
                    request.CookieContainer = new CookieContainer();
                    cookie = request.CookieContainer;
                }
                else
                {
                    request.CookieContainer = cookie;
                }
                //设置超时时间为60秒
                request.Timeout = 60000;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";                
                request.ContentLength = postDataStr.Length;
                myRequestStream = request.GetRequestStream();
                myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312")); //gb2312
                myStreamWriter.Write(postDataStr);
                myStreamWriter.Close();

                response = (HttpWebResponse)request.GetResponse();
                myResponseStream = response.GetResponseStream();
                myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                retString = myStreamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                //Common.WriteLog("数据POST传输失败\r\n" + ex.Message + "\r\nDetails:" + ex.StackTrace);
                retString = string.Empty;
            }
            finally
            {
                if (myStreamReader != null)
                {
                    myStreamReader.Close();
                }
                if (myResponseStream != null)
                {
                    myResponseStream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (myStreamWriter != null)
                {
                    myStreamWriter.Close();
                }
                if (myRequestStream != null)
                {
                    myRequestStream.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return retString;
        }
        #endregion

        #region 获取当前程序版本号
        /// <summary>
        /// 获取当前程序版本号
        /// </summary>
        /// <returns>版本号</returns>
        public static string AssemblyFileVersion()
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
            if (attributes.Length == 0)
            {
                return string.Empty;
            }
            else
            {
                return ((AssemblyFileVersionAttribute)attributes[0]).Version;
            }
        }
        #endregion
    }
}
