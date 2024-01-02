using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace Tx2Ca2_deGiang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        XmlDocument document = new XmlDocument();
        string tentep = @"E:\Documents\Giao trinh hoc online\4th year\Tich hop HTPM\Codes\TX2\Tx2Ca2_deGiang (1)\Tx2Ca2_deGiang\ThoiTietHomNay.xml";
        int d;
        
        private void Showdata()
        {
            datathoitiet.Rows.Clear();
            document.Load(tentep);
            XmlNodeList TG = document.SelectNodes("/thoitiethomnay/thoigian");
            XmlNodeList KV = document.SelectNodes("/thoitiethomnay/thoigian/khuvuc");
            int sd = 0;
            datathoitiet.ColumnCount = 5;
            datathoitiet.Rows.Add();
            foreach (XmlNode tg in TG) 
            {
                XmlNode gio = tg.SelectSingleNode("@gio");
                foreach(XmlNode kv in KV)
                {
                    datathoitiet.Rows[sd].Cells[0].Value = gio.InnerText.ToString();
                    
                    XmlNode ma = kv.SelectSingleNode("@ma");
                    datathoitiet.Rows[sd].Cells[1].Value = ma.InnerText.ToString();

                    XmlNode kieutt = kv.SelectSingleNode("kieuthoitiet");
                    datathoitiet.Rows[sd].Cells[2].Value = kieutt.InnerText.ToString();
                    
                    XmlNode nhietdo = kv.SelectSingleNode("nhietdo");
                    datathoitiet.Rows[sd].Cells[3].Value = nhietdo.InnerText.ToString();
                    
                    XmlNode doam = kv.SelectSingleNode("doam");
                    datathoitiet.Rows[sd].Cells[4].Value = doam.InnerText.ToString();
                    
                    datathoitiet.Rows.Add();
                    sd++;
                }
                datathoitiet.Rows.Add();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Showdata();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {

        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {

        }
    }
}
