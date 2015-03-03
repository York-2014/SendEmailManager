using SendEmailManager.MyControls;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SendEmailManager
{
    public partial class MainForm : Form
    {
        public static string baseUrl = "http://192.168.1.163";
        public static string updateUrl = baseUrl + "/update_task.php";
        public static string htmlFolderUrl = baseUrl + "/htmlcontent/";
        public static string xmlFileUrl = baseUrl + "/task_list.xml";

        private static XmlDocument xdoc;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadControlBySettings();
            init();
        }

        private void loadControlBySettings()
        {
            xdoc = new XmlDocument();
            xdoc.LoadXml(File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "settings.xml")));
            baseUrl = xdoc["settings"]["server"].InnerText;
            for (int i = 0; i < xdoc["settings"]["country"].ChildNodes.Count; i++)
            {
                Send_Template template = new Send_Template();
                template.SendDate = System.DateTime.Now;
                template.CountryCode = xdoc["settings"]["country"].ChildNodes[i].Attributes["code"].InnerText;
                template.Label = xdoc["settings"]["country"].ChildNodes[i].Attributes["label"].InnerText;
                template.To = xdoc["settings"]["country"].ChildNodes[i].Attributes["to"].InnerText;
                template.EmailAddress = xdoc["settings"]["country"].ChildNodes[i].Attributes["from"].InnerText;
                template.CurrentMode = ModeType.Empty;
                this.Controls.Add(template);
                template.Location = new System.Drawing.Point(13, 13 + (i * 55));
            }
            updateUrl = baseUrl + "/update_task.php";
            htmlFolderUrl = baseUrl + "/htmlcontent/";
            xmlFileUrl = baseUrl + "/task_list.xml";
        }

        private void init()
        {
            this.Text = string.Format("{0} - {1}", this.Text, Common.AssemblyFileVersion());
            //Get xml file
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                string strData = wc.DownloadString(xmlFileUrl);
                strData = Encoding.UTF8.GetString(Encoding.Default.GetBytes(strData));
                xdoc.LoadXml(strData);
            }
            if (xdoc.ChildNodes.Count > 0)
            {
                XmlNodeList xnList = xdoc.GetElementsByTagName("item");
                foreach (XmlNode node in xnList)
                {
                    foreach (Send_Template template in this.Controls)
                    {
                        if (node.Attributes["country"].InnerText.ToUpper() == template.CountryCode.ToUpper())
                        {
                            if (node["completed"].InnerText == "false")
                            {
                                template.Subject = node["subject"].InnerText;
                                template.SendDate = Convert.ToDateTime(node["senddate"].InnerText);
                                template.CurrentMode = ModeType.Modify;
                            }
                            else
                            {
                                template.CurrentMode = ModeType.Empty;
                            }
                        }
                    }
                }
            }
        }
    }
}