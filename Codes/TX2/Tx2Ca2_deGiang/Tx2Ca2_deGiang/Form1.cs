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
        string tentep = @"C:\Users\Mr.Duong\Documents\Tích hợp\emduong\Tx2Ca2_deGiang\Tx2Ca2_deGiang\ThoiTietHomNay.xml";
        
        private void Showdata()
        {
            datathoitiet.Rows.Clear();
            document.Load(tentep);
            XmlNodeList TG = document.SelectNodes("thoitiethomnay/thoigian");
            int sd = 0;
            datathoitiet.Rows.Add();
            datathoitiet.ColumnCount = 5;
            foreach (XmlNode tg in TG)
            {
                XmlNode gio = tg.SelectSingleNode("@gio");
                datathoitiet.Rows[sd].Cells[0].Value = gio.InnerText.ToString();
                XmlNodeList kv = document.SelectNodes("./thoigian/khuvuc");
                foreach (XmlNode kv2 in kv)
                {
                    XmlNode ma = kv2.SelectSingleNode("khuvuc/@ma");
                    XmlNode kieutt = kv2.SelectSingleNode("khuvuc/kieuthoitiet");
                    XmlNode nhietdo = kv2.SelectSingleNode("khuvuc/nhietdo");
                    XmlNode doam = kv2.SelectSingleNode("khuvuc/doam");
                    datathoitiet.Rows[sd].Cells[1].Value = ma.InnerText.ToString();
                    datathoitiet.Rows[sd].Cells[2].Value = kieutt.InnerText.ToString();
                    datathoitiet.Rows[sd].Cells[3].Value = nhietdo.InnerText.ToString();
                    datathoitiet.Rows[sd].Cells[4].Value = doam.InnerText.ToString(); 
                    sd++;
                }
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
