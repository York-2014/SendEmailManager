using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Net;
using System.Diagnostics;
using System.Web;

namespace SendEmailManager.MyControls
{
    public enum ModeType
    {
        Empty,
        Modify,
        Update
    }

    public partial class Send_Template : UserControl
    {
        public enum SaveType
        {
            Create,
            Update,
            Stop
        }

        private DateTime tempDateTime = DateTime.MinValue;
        public Send_Template()
        {
            InitializeComponent();
        }

        private void changeMode()
        {
            switch (CurrentMode)
            {
                case ModeType.Empty:
                    HtmlContent = string.Empty;
                    label_comment.Text = "请填写发送信息。";
                    textBox_subject.Enabled = true;
                    dateTimePicker_sendDate.Enabled = true;

                    button_submit.Enabled = true;
                    button_modifyInfo.Enabled = false;
                    button_update.Enabled = false;
                    button_stopTask.Enabled = false;

                    button_editHtml.Enabled = true;

                    button_submit.Show();
                    button_modifyInfo.Hide();
                    button_update.Hide();
                    button_stopTask.Hide();

                    button_view.Enabled = false;
                    break;
                case ModeType.Modify:
                    label_comment.Text = "准备完成，等待发送。";
                    textBox_subject.Enabled = false;
                    dateTimePicker_sendDate.Enabled = false;

                    button_modifyInfo.Enabled = true;
                    button_submit.Enabled = false;
                    button_update.Enabled = false;
                    button_stopTask.Enabled = false;

                    button_editHtml.Enabled = false;

                    button_modifyInfo.Show();
                    button_submit.Hide();
                    button_update.Hide();
                    button_stopTask.Hide();

                    button_view.Enabled = true;
                    break;
                case ModeType.Update:
                    label_comment.Text = "请修改发送详情。";
                    textBox_subject.Enabled = true;
                    dateTimePicker_sendDate.Enabled = true;

                    button_submit.Enabled = false;
                    button_modifyInfo.Enabled = false;
                    button_update.Enabled = true;
                    button_stopTask.Enabled = true;

                    button_editHtml.Enabled = true;

                    button_submit.Hide();
                    button_modifyInfo.Hide();
                    button_update.Show();
                    button_stopTask.Show();

                    button_view.Enabled = false;
                    break;
            }
            validation();
        }

        #region 控件自定义属性
        private ModeType _Mode = ModeType.Empty;
        [CategoryAttribute("自定义属性"),
        DescriptionAttribute("当前模式"),
        DefaultValue("")]
        public ModeType CurrentMode
        {
            set
            {
                _Mode = value;
                changeMode();
            }
            get { return _Mode; }
        }

        private string _CountryCode = "AU";
        [CategoryAttribute("自定义属性"),
        DescriptionAttribute("国家代码"),
        DefaultValue("AU")]
        public string CountryCode
        {
            set
            {
                _CountryCode = value;
                label_countryCode.Text = _CountryCode;
            }
            get { return _CountryCode; }
        }

        private string _Label = string.Empty;
        [CategoryAttribute("自定义属性"),
        DescriptionAttribute("Label"),
        DefaultValue("")]
        public string Label
        {
            set
            {
                _Label = value;
            }
            get { return _Label; }
        }

        private string _To = string.Empty;
        [CategoryAttribute("自定义属性"),
        DescriptionAttribute("收件地址"),
        DefaultValue("")]
        public string To
        {
            set
            {
                _To = value;
            }
            get { return _To; }
        }

        private string _EmailAddress = string.Empty;
        [CategoryAttribute("自定义属性"),
        DescriptionAttribute("发件地址"),
        DefaultValue("")]
        public string EmailAddress
        {
            set
            {
                _EmailAddress = value;
            }
            get { return _EmailAddress; }
        }

        private string _Subject = string.Empty;
        [CategoryAttribute("自定义属性"),
        DescriptionAttribute("邮件标题"),
        DefaultValue("")]
        public string Subject
        {
            set
            {
                _Subject = value;
                textBox_subject.Text = _Subject;
            }
            get { return _Subject; }
        }

        private string _HtmlContent = string.Empty;
        [CategoryAttribute("自定义属性"),
        DescriptionAttribute("HTML内容"),
        DefaultValue("")]
        public string HtmlContent
        {
            set
            {
                _HtmlContent = value;
            }
            get { return _HtmlContent; }
        }

        private DateTime _SendDate = System.DateTime.Now;
        [CategoryAttribute("自定义属性"),
        DescriptionAttribute("发送时间"),
        DefaultValue("")]
        public DateTime SendDate
        {
            set
            {
                _SendDate = value;
                dateTimePicker_sendDate.Value = _SendDate;
            }
            get { return _SendDate; }
        }
        #endregion

        private void dateTimePicker_sendDate_ValueChanged(object sender, EventArgs e)
        {
            if (SendDate != dateTimePicker_sendDate.Value)
            {
                SendDate = dateTimePicker_sendDate.Value;
                validation();
            }
        }

        /// <summary>
        /// 编辑html
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_editHtml_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = string.Empty;
                openFileDialog1.Filter = "Html格式,Htm格式|*.html;*.htm";
                if (DialogResult.OK == openFileDialog1.ShowDialog())
                {
                    HtmlContent = File.ReadAllText(openFileDialog1.FileName, Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                HtmlContent = string.Empty;
                button_view.Enabled = false;
            }
            finally
            {
                validation();
            }
        }

        private void textBox_subject_TextChanged(object sender, EventArgs e)
        {
            Subject = textBox_subject.Text;
            if (string.IsNullOrEmpty(Subject))
            {
                textBox_subject.BackColor = Color.Red;
            }
            else
            {
                textBox_subject.BackColor = Color.White;
            }
            validation();
        }

        /// <summary>
        /// 验证
        /// </summary>
        private void validation()
        {
            switch (CurrentMode)
            {
                case ModeType.Empty:
                    if (string.IsNullOrEmpty(Subject) || string.IsNullOrEmpty(HtmlContent) || SendDate < System.DateTime.Now)
                    {
                        if (string.IsNullOrEmpty(Subject))
                        {
                            label_comment.Text = "主题不能为空.";
                        }
                        else if (SendDate < System.DateTime.Now)
                        {
                            label_comment.Text = "发送时间必须大于当前时间.";
                        }
                        else
                        {
                            label_comment.Text = "请编辑HTML内容.";
                        }
                        button_submit.Enabled = false;
                    }
                    else
                    {
                        button_submit.Enabled = true;
                    }
                    break;
                case ModeType.Update:
                    if (string.IsNullOrEmpty(Subject) || SendDate < System.DateTime.Now)
                    {
                        if (string.IsNullOrEmpty(Subject))
                        {
                            label_comment.Text = "主题不能为空.";
                        }
                        else if (SendDate < System.DateTime.Now)
                        {
                            label_comment.Text = "发送时间必须大于当前时间.";
                        }
                        button_update.Enabled = false;
                    }
                    else
                    {
                        button_update.Enabled = true;
                    }
                    break;
            }
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_submit_Click(object sender, EventArgs e)
        {
            string strResult = saveData(SaveType.Create);
            if (strResult.ToLower() == "successfully!")
            {
                //success
                MessageBox.Show("任务设置成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CurrentMode = ModeType.Modify;
            }
            else
            {
                //failed
                MessageBox.Show("任务设置失败!\r\n细节：" + strResult, "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        private string saveData(SaveType type)
        {
            string strData = string.Empty;
            switch (type)
            {
                case SaveType.Create:
                    strData = "country=" + CountryCode.ToLower()
                               + "&label=" + Label
                               + "&subject=" + HttpUtility.UrlEncode(Subject)
                               + "&content=" + HttpUtility.UrlEncode(HtmlContent)
                               + "&senddate=" + SendDate
                               + "&to=" + To
                               + "&from=" + EmailAddress
                               + "&type=create";
                    break;
                case SaveType.Update:                    
                    strData = "country=" + CountryCode.ToLower()
                               + "&label=" + Label
                               + "&subject=" + HttpUtility.UrlEncode(Subject)
                               + "&content=" + HttpUtility.UrlEncode(HtmlContent)
                               + "&senddate=" + SendDate
                               + "&to=" + To
                               + "&from=" + EmailAddress
                               + "&type=update";
                    break;
                case SaveType.Stop:
                    strData = "country=" + CountryCode.ToLower()
                               + "&label=" + Label
                               + "&subject=" + HttpUtility.UrlEncode(Subject)
                               + "&content=" + HttpUtility.UrlEncode(HtmlContent)
                               + "&senddate=" + SendDate
                               + "&to=" + To
                               + "&from=" + EmailAddress
                               + "&type=stop";
                    break;
            }

            CookieContainer cookie = new CookieContainer();
            string strResult = Common.SendDataByPost(MainForm.updateUrl, strData, ref cookie);
            return strResult;
        }

        /// <summary>
        /// 预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_view_Click(object sender, EventArgs e)
        {
            string viewUrl = MainForm.htmlFolderUrl + CountryCode.ToLower() + ".html";
            Process.Start(viewUrl);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_modifyInfo_Click(object sender, EventArgs e)
        {
            this.CurrentMode = ModeType.Update;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_update_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定要更新任务吗？", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                string strResult = saveData(SaveType.Update);
                if (strResult.ToLower() == "successfully!")
                {
                    //success
                    MessageBox.Show("更新成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.CurrentMode = ModeType.Modify;
                }
                else
                {
                    //failed
                    MessageBox.Show("更新失败!\r\n细节：" + strResult, "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_stopTask_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定要终止任务吗？", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                string strResult = saveData(SaveType.Stop);
                if (strResult.ToLower() == "successfully!")
                {
                    //success
                    MessageBox.Show("终止成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.CurrentMode = ModeType.Empty;
                }
                else
                {
                    //failed
                    MessageBox.Show("终止失败!\r\n细节：" + strResult, "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}