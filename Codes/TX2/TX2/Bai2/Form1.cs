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
using System.Xml.Linq;


namespace Bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        XmlDocument document = new XmlDocument();
        string tentep = @"E:\Documents\Giao trinh hoc online\4th year\Tich hop HTPM\Codes\TX2\TX2\Bai2\ThoiTietHomNay.xml";
        int d;

        //private void HienThi()
        //{
        //    datathoitiet.Rows.Clear();
        //    document.Load(tentep);

        //    XmlNodeList TG = document.SelectNodes("/thoitiethomnay/thoigian");
        //    XmlNodeList KV = document.SelectNodes("/thoitiethomnay/thoigian/khuvuc");
        //    int sd = 0;

        //    datathoitiet.ColumnCount = 5;
        //    datathoitiet.Rows.Add();

        //    foreach (XmlNode tg in TG)
        //    {
        //        //XmlNode gio = tg.SelectSingleNode("@gio");
        //        //datathoitiet.Rows[sd].Cells[0].Value = gio.InnerText.ToString();

        //        XmlNode gio = tg.SelectSingleNode("@gio");
        //        XmlNode ma = tg.SelectSingleNode("khuvuc/@ma");
        //        XmlNode kieutt = tg.SelectSingleNode("khuvuc/kieuthoitiet");
        //        XmlNode nhietdo = tg.SelectSingleNode("khuvuc/nhietdo");
        //        XmlNode doam = tg.SelectSingleNode("khuvuc/doam");

        //        datathoitiet.Rows[sd].Cells[0].Value = gio.InnerText.ToString();
        //        datathoitiet.Rows[sd].Cells[1].Value = ma.InnerText.ToString();
        //        datathoitiet.Rows[sd].Cells[2].Value = kieutt.InnerText.ToString();
        //        datathoitiet.Rows[sd].Cells[3].Value = nhietdo.InnerText.ToString();
        //        datathoitiet.Rows[sd].Cells[4].Value = doam.InnerText.ToString();

        //        //XmlNode kv = tg.SelectSingleNode("khuvuc");
        //        //datathoitiet.Rows[sd].Cells[1].Value = kv.InnerText.ToString();

        //        datathoitiet.Rows.Add();
        //        //foreach (XmlNode kv in KV)
        //        //{
        //        //    XmlNode ma = kv.SelectSingleNode("@ma");
        //        //    datathoitiet.Rows[sd].Cells[1].Value = ma.InnerText.ToString();

        //        //    XmlNode kieutt = kv.SelectSingleNode("kieuthoitiet");
        //        //    datathoitiet.Rows[sd].Cells[2].Value = kieutt.InnerText.ToString();

        //        //    XmlNode nhietdo = kv.SelectSingleNode("nhietdo");
        //        //    datathoitiet.Rows[sd].Cells[3].Value = nhietdo.InnerText.ToString();

        //        //    XmlNode doam = kv.SelectSingleNode("doam");
        //        //    datathoitiet.Rows[sd].Cells[4].Value = doam.InnerText.ToString();

        //        //    datathoitiet.Rows.Add();
        //        //    sd++;
        //        //}
        //        sd++;
        //    }
        //}

        private void HienThi()
        {
            datathoitiet.Rows.Clear();
            document.Load(tentep);
            XmlNodeList TG = document.SelectNodes("/thoitiethomnay/thoigian");
            int sd = 0;
            datathoitiet.ColumnCount = 5;
            datathoitiet.Rows.Add();
            foreach (XmlNode tg in TG)
            {
                XmlNode gio = tg.SelectSingleNode("@gio");
                XmlNodeList kv = document.SelectNodes("/khuvuc");
                foreach (XmlNode kv2 in kv)
                {
                    XmlNode ma = kv2.SelectSingleNode("@ma");
                    XmlNode kieutt = kv2.SelectSingleNode("kieuthoitiet");
                    XmlNode nhietdo = kv2.SelectSingleNode("nhietdo");
                    XmlNode doam = kv2.SelectSingleNode("doam");


                    datathoitiet.Rows[sd].Cells[1].Value = ma.InnerText.ToString();
                    datathoitiet.Rows[sd].Cells[2].Value = kieutt.InnerText.ToString();
                    datathoitiet.Rows[sd].Cells[3].Value = nhietdo.InnerText.ToString();
                    datathoitiet.Rows[sd].Cells[4].Value = doam.InnerText.ToString();

                }
                datathoitiet.Rows[sd].Cells[0].Value = gio.InnerText.ToString();
                sd++;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }



}
