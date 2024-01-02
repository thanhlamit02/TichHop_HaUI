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

namespace BT1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XmlDocument doc = new XmlDocument();
        string tentep = @"D:\NguyenThanhLam_2020601227\BT1\dsnhanvien.xml";
        int d;

        private void HienThi()
        {
            datanhanvien.Rows.Clear();
            doc.Load(tentep);
            XmlNodeList DS = doc.SelectNodes("/ds/nhanvien");
            int sd = 0;
            datanhanvien.ColumnCount = 3;
            datanhanvien.Rows.Add();

            foreach (XmlNode nhan_vien in DS)
            {
                XmlNode ma_nv = nhan_vien.SelectSingleNode("@manv");
                datanhanvien.Rows[sd].Cells[0].Value = ma_nv.InnerText.ToString();

                XmlNode ho_ten = nhan_vien.SelectSingleNode("hoten");
                datanhanvien.Rows[sd].Cells[1].Value = ho_ten.InnerText.ToString();

                XmlNode dia_chi = nhan_vien.SelectSingleNode("diachi");
                datanhanvien.Rows[sd].Cells[2].Value = dia_chi.InnerText.ToString();

                datanhanvien.Rows.Add();
                sd++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;

            XmlNode nhan_vien = doc.CreateElement("nhanvien");

            XmlAttribute ma_nv = doc.CreateAttribute("manv");
            ma_nv.InnerText = txtmanv.Text;
            nhan_vien.Attributes.Append(ma_nv);

            XmlNode ho_ten = doc.CreateElement("hoten");
            ho_ten.InnerText = txthoten.Text;
            nhan_vien.AppendChild(ho_ten);

            XmlNode dia_chi = doc.CreateElement("diachi");
            dia_chi.InnerText = txtdiachi.Text;
            nhan_vien.AppendChild(dia_chi);

            goc.AppendChild(nhan_vien);

            doc.Save(tentep);
            HienThi();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;

            XmlNode nhan_vien_cu = goc.SelectSingleNode("/ds/nhanvien[@manv='" + txtmanv.Text + "']");
            XmlNode nhan_vien_moi = doc.CreateElement("nhanvien");

            XmlAttribute ma_nv = doc.CreateAttribute("manv");
            ma_nv.InnerText = txtmanv.Text;
            nhan_vien_moi.Attributes.Append(ma_nv);

            XmlNode ho_ten = doc.CreateElement("hoten");
            ho_ten.InnerText = txthoten.Text;
            nhan_vien_moi.AppendChild(ho_ten);

            XmlNode dia_chi = doc.CreateElement("diachi");
            dia_chi.InnerText = txtdiachi.Text;
            nhan_vien_moi.AppendChild(dia_chi);

            goc.ReplaceChild(nhan_vien_moi, nhan_vien_cu);
            doc.Save(tentep);
            HienThi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;

            XmlNode nhan_vien_xoa = goc.SelectSingleNode("/ds/nhanvien[@manv='" + txtmanv.Text + "']");
            goc.RemoveChild(nhan_vien_xoa);
            doc.Save(tentep);
            HienThi();
        }

        private void datanhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            d = e.RowIndex;
            txtmanv.Text = datanhanvien.Rows[d].Cells[0].Value.ToString();
            txthoten.Text = datanhanvien.Rows[d].Cells[1].Value.ToString();
            txtdiachi.Text = datanhanvien.Rows[d].Cells[2].Value.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;
            XmlNodeList DS = doc.SelectNodes("/ds/nhanvien");
            XmlNode nhanVien = goc.SelectSingleNode("/ds/nhanvien[@manv='" + txtmanv.Text + "']");
            datanhanvien.Rows.Clear();
            datanhanvien.Rows.Add();
            int sd = 0;
            foreach (XmlNode nv in DS)
            {
                if (nhanVien.SelectSingleNode("@manv").InnerText == nv.SelectSingleNode("@manv").InnerText)
                {
                    datanhanvien.Rows[sd].Cells[0].Value = nv.SelectSingleNode("@manv").InnerText;
                    datanhanvien.Rows[sd].Cells[1].Value = nv.SelectSingleNode("hoten").InnerText;
                    datanhanvien.Rows[sd].Cells[2].Value = nv.SelectSingleNode("diachi").InnerText;
                    datanhanvien.Rows.Add();
                    sd++;
                }

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
