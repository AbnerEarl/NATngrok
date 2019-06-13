using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace NATngrok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startNat();
        }



        private void startNat()
        {

            String folderName = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            String fileName = "nat.bat";
            //String path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "nat.bat";
            String path = folderName + fileName;
            try
            {

                // FileStream fs = new FileStream(path, FileMode.Append);
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                StreamWriter wr = null;
                wr = new StreamWriter(fs);
                String result = "ding -config=./ding.cfg -subdomain=";
                if (textBox1.Text.Length > 1)
                {
                    result = result + textBox1.Text + " ";
                }
                else
                {
                    result = result + "frank111 ";
                }
                if (textBox2.Text.Length > 1)
                {
                    result = result + textBox2.Text;
                }
                else
                {
                    result = result + "3306";
                }
                wr.WriteLine(result);
                wr.Close();

            }
            catch (Exception e)
            {

            }
            excuteCommand(folderName,fileName);

        }


        private void excuteCommand(String folderName,String fileName)
        {
            Process proc = null;
            try
            {
                string targetDir = string.Format(folderName);
                proc = new Process();
                proc.StartInfo.WorkingDirectory = targetDir;
                proc.StartInfo.FileName = fileName;
               // proc.StartInfo.Arguments = string.Format("10");//参数设置
                //proc.StartInfo.CreateNoWindow = true;
                //proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//这里设置DOS窗口不显示
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }

            //MessageBox.Show("网络穿透成功！映射地址为： http://frank111.vaiwan.com");
        }

    }

}
