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

namespace Bai2_TX2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XmlDocument doc = new XmlDocument();
        string tentep = @"E:\Documents\Giao trinh hoc online\4th year\Tich hop HTPM\Codes\TX2\TX2\Bai2_TX2\congty.xml";
        int d;

        private void HienThi()
        {
            datacongty.Rows.Clear();
            doc.Load(tentep);
            XmlNodeList NV = doc.SelectNodes("/congty/nhanvien");
            int sd = 0;
            datacongty.ColumnCount = 8;
            datacongty.Rows.Add();
            foreach(XmlNode nv in NV)
            {
                XmlNode manv = nv.SelectSingleNode("@manv");
                datacongty.Rows[sd].Cells[0].Value = manv.InnerText;

                XmlNode hoten = nv.SelectSingleNode("hoten");
                datacongty.Rows[sd].Cells[1].Value = hoten.InnerText;

                XmlNode tuoi = nv.SelectSingleNode("tuoi");
                datacongty.Rows[sd].Cells[2].Value = tuoi.InnerText;

                XmlNode luong = nv.SelectSingleNode("luong");
                datacongty.Rows[sd].Cells[3].Value = luong.InnerText;

                XmlNode xa = nv.SelectSingleNode("diachi/xa");
                datacongty.Rows[sd].Cells[4].Value = xa.InnerText;

                XmlNode huyen = nv.SelectSingleNode("diachi/huyen");
                datacongty.Rows[sd].Cells[5].Value = huyen.InnerText;

                XmlNode tinh = nv.SelectSingleNode("diachi/tinh");
                datacongty.Rows[sd].Cells[6].Value = tinh.InnerText;

                XmlNode dienthoai = nv.SelectSingleNode("dienthoai");
                datacongty.Rows[sd].Cells[7].Value = dienthoai.InnerText;

                datacongty.Rows.Add();
                sd++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void datacongty_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            d = e.RowIndex;
            txtmanv.Text = datacongty.Rows[d].Cells[0].Value.ToString();
            txthoten.Text = datacongty.Rows[d].Cells[1].Value.ToString();
            txttuoi.Text = datacongty.Rows[d].Cells[2].Value.ToString();
            txtluong.Text = datacongty.Rows[d].Cells[3].Value.ToString();
            txtxa.Text = datacongty.Rows[d].Cells[4].Value.ToString();
            txthuyen.Text = datacongty.Rows[d].Cells[5].Value.ToString();
            txttinh.Text = datacongty.Rows[d].Cells[6].Value.ToString();
            txtdienthoai.Text = datacongty.Rows[d].Cells[7].Value.ToString();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;

            XmlNode chkTrung = goc.SelectSingleNode("/congty/nhanvien[@manv = '" + txtmanv.Text + "']");

            if (chkTrung != null)
            {
                MessageBox.Show("Mã nhân viên '" + txtmanv.Text + "' bị trùng", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                XmlElement nhan_vien = doc.CreateElement("nhanvien");
                XmlAttribute ma_nv = doc.CreateAttribute("manv");
                XmlNode ho_ten = doc.CreateElement("hoten");
                XmlNode t = doc.CreateElement("tuoi");
                XmlNode l = doc.CreateElement("luong");
                XmlNode dia_chi = doc.CreateElement("diachi");
                XmlNode x = doc.CreateElement("xa");
                XmlNode h = doc.CreateElement("huyen");
                XmlNode th = doc.CreateElement("tinh");
                XmlNode dien_thoai = doc.CreateElement("dienthoai");

                ma_nv.InnerText = txtmanv.Text;
                ho_ten.InnerText = txthoten.Text;
                t.InnerText = txttuoi.Text;
                l.InnerText = txtluong.Text;
                x.InnerText = txtxa.Text;
                h.InnerText = txthuyen.Text;
                th.InnerText = txttinh.Text;
                dien_thoai.InnerText = txtdienthoai.Text;

                nhan_vien.Attributes.Append(ma_nv);
                nhan_vien.AppendChild(ho_ten);
                nhan_vien.AppendChild(t);
                nhan_vien.AppendChild(l);
                nhan_vien.AppendChild(dia_chi);
                dia_chi.AppendChild(x);
                dia_chi.AppendChild(h);
                dia_chi.AppendChild(th);
                nhan_vien.AppendChild(dia_chi);
                nhan_vien.AppendChild(dien_thoai);

                goc.AppendChild(nhan_vien);
            }
            doc.Save(tentep);
            HienThi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;

            XmlNode scu = goc.SelectSingleNode("/congty/nhanvien[@manv = '" + txtmanv.Text + "']");

            if (scu == null)
            {
                MessageBox.Show("Mã nhân viên '" + txtmanv.Text + "' không tồn tại", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            else
            {
                XmlElement nhan_vien = doc.CreateElement("nhanvien");
                XmlAttribute ma_nv = doc.CreateAttribute("manv");
                XmlNode ho_ten = doc.CreateElement("hoten");
                XmlNode t = doc.CreateElement("tuoi");
                XmlNode l = doc.CreateElement("luong");
                XmlNode dia_chi = doc.CreateElement("diachi");
                XmlNode x = doc.CreateElement("xa");
                XmlNode h = doc.CreateElement("huyen");
                XmlNode th = doc.CreateElement("tinh");
                XmlNode dien_thoai = doc.CreateElement("dienthoai");

                ma_nv.InnerText = txtmanv.Text;
                ho_ten.InnerText = txthoten.Text;
                t.InnerText = txttuoi.Text;
                l.InnerText = txtluong.Text;
                x.InnerText = txtxa.Text;
                h.InnerText = txthuyen.Text;
                th.InnerText = txttinh.Text;
                dien_thoai.InnerText = txtdienthoai.Text;

                nhan_vien.Attributes.Append(ma_nv);
                nhan_vien.AppendChild(ho_ten);
                nhan_vien.AppendChild(t);
                nhan_vien.AppendChild(l);
                nhan_vien.AppendChild(dia_chi);
                dia_chi.AppendChild(x);
                dia_chi.AppendChild(h);
                dia_chi.AppendChild(th);
                nhan_vien.AppendChild(dia_chi);
                nhan_vien.AppendChild(dien_thoai);

                goc.ReplaceChild(nhan_vien, scu);
            }
            MessageBox.Show("Sửa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK);
            doc.Save(tentep);
            HienThi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;

            XmlNode s = goc.SelectSingleNode("/congty/nhanvien[@manv = '" + txtmanv.Text + "']");

            if (s == null)
            {
                MessageBox.Show("Mã nhân viên '" + txtmanv.Text + "' không tồn tại", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            DialogResult res = MessageBox.Show("Bạn có muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                goc.RemoveChild(s);
            }
            doc.Save(tentep);
            HienThi();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;
            XmlNodeList DS = doc.SelectNodes("/congty/nhanvien");
            XmlNode nhanVien = goc.SelectSingleNode("/congty/nhanvien[@manv='" + txtTim.Text + "']");
            datacongty.Rows.Clear();
            datacongty.Rows.Add();
            int sd = 0;

            foreach (XmlNode nv in DS)
            {
                if(nhanVien.SelectSingleNode("@manv").InnerText == nv.SelectSingleNode("@manv").InnerText)
                {
                    XmlNode manv = nv.SelectSingleNode("@manv");
                    datacongty.Rows[sd].Cells[0].Value = manv.InnerText;

                    XmlNode hoten = nv.SelectSingleNode("hoten");
                    datacongty.Rows[sd].Cells[1].Value = hoten.InnerText;

                    XmlNode tuoi = nv.SelectSingleNode("tuoi");
                    datacongty.Rows[sd].Cells[2].Value = tuoi.InnerText;

                    XmlNode luong = nv.SelectSingleNode("luong");
                    datacongty.Rows[sd].Cells[3].Value = luong.InnerText;

                    XmlNode xa = nv.SelectSingleNode("diachi/xa");
                    datacongty.Rows[sd].Cells[4].Value = xa.InnerText;

                    XmlNode huyen = nv.SelectSingleNode("diachi/huyen");
                    datacongty.Rows[sd].Cells[5].Value = huyen.InnerText;

                    XmlNode tinh = nv.SelectSingleNode("diachi/tinh");
                    datacongty.Rows[sd].Cells[6].Value = tinh.InnerText;

                    XmlNode dienthoai = nv.SelectSingleNode("dienthoai");
                    datacongty.Rows[sd].Cells[7].Value = dienthoai.InnerText;

                    datacongty.Rows.Add();
                }
                
                //else if(nhanVien.SelectSingleNode("@manv").InnerText == null)
                //{
                //    MessageBox.Show("Mã nhân viên không được để trống!", "Thông báo", MessageBoxButtons.OK);
                //}
                
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
