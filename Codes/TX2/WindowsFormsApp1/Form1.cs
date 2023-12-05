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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XmlDocument doc = new XmlDocument();
        string tentep = @"E:\Documents\Giao trinh hoc online\4th year\Tich hop HTPM\Codes\TX2\WindowsFormsApp1\dsnhanvien.xml";
        int d;


        private void HienThi()
        {
            datanhanvien.Rows.Clear();
            doc.Load(tentep);

            XmlNodeList DS = doc.SelectNodes("/ds/nhanvien");
            int sd = 0;

            datanhanvien.ColumnCount = 6;
            datanhanvien.Rows.Add();

            foreach(XmlNode nhan_vien in DS)
            {
                XmlNode ma_nv = nhan_vien.SelectSingleNode("@manv");
                datanhanvien.Rows[sd].Cells[0].Value = ma_nv.InnerText.ToString();

                XmlNode ho = nhan_vien.SelectSingleNode("hoten/ho");
                datanhanvien.Rows[sd].Cells[1].Value = ho.InnerText.ToString();

                XmlNode ten = nhan_vien.SelectSingleNode("hoten/ten");
                datanhanvien.Rows[sd].Cells[2].Value = ten.InnerText.ToString();

                XmlNode gioi_tinh = nhan_vien.SelectSingleNode("gioitinh");
                datanhanvien.Rows[sd].Cells[3].Value = gioi_tinh.InnerText.ToString();

                XmlNode trinh_do = nhan_vien.SelectSingleNode("trinhdo");
                datanhanvien.Rows[sd].Cells[4].Value = trinh_do.InnerText.ToString();

                XmlNode dia_chi = nhan_vien.SelectSingleNode("diachi");
                datanhanvien.Rows[sd].Cells[5].Value = dia_chi.InnerText.ToString();

                datanhanvien.Rows.Add();
                sd++;
            }
            
        }

        private void LoadComboBox()
        {
            cbxTrinhdo.SelectedText = "Đại học";
            cbxTrinhdo.Items.Add("Cao đẳng");
            cbxTrinhdo.Items.Add("Không có");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
            LoadComboBox();
        }

        private void datanhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            d = e.RowIndex;
            txtManv.Text = datanhanvien.Rows[d].Cells[0].Value.ToString();
            txtHo.Text = datanhanvien.Rows[d].Cells[1].Value.ToString();
            txtTen.Text = datanhanvien.Rows[d].Cells[2].Value.ToString();
            if (datanhanvien.Rows[d].Cells[3].Value.ToString() == "Nam" )
            {
                radioBtnNam.Checked = true;
            }
            else
            {
                radioBtnNu.Checked = true;
            }
            cbxTrinhdo.Text = datanhanvien.Rows[d].Cells[4].Value.ToString();
            txtDiachi.Text = datanhanvien.Rows[d].Cells[5].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;
            XmlNode nhan_vien = doc.CreateElement("nhanvien");
            XmlAttribute ma_nv = doc.CreateAttribute("manv");
            XmlNode ho_ten = doc.CreateElement("hoten");
            XmlNode ho = doc.CreateElement("ho");
            XmlNode ten = doc.CreateElement("ten");
            XmlNode gioi_tinh = doc.CreateElement("gioitinh");
            XmlNode trinh_do = doc.CreateElement("trinhdo");
            XmlNode dia_chi = doc.CreateElement("diachi");
            
            ma_nv.InnerText = txtManv.Text;
            ho.InnerText = txtHo.Text;
            ten.InnerText = txtTen.Text;
            if (radioBtnNam.Checked == true)
            {
                gioi_tinh.InnerText = "Nam";
            }
            else
            {
                gioi_tinh.InnerText = "Nữ";
            }
            trinh_do.InnerText = cbxTrinhdo.Text;
            dia_chi.InnerText = txtDiachi.Text;

            if (goc.SelectSingleNode("nhanvien[@manv = '" + ma_nv.Value + "']") != null)
            {
                MessageBox.Show("Mã nhân viên bị trùng, sửa lại mã nhân viên!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                nhan_vien.Attributes.Append(ma_nv);
                nhan_vien.AppendChild(ho_ten);
                ho_ten.AppendChild(ho);
                ho_ten.AppendChild(ten);
                nhan_vien.AppendChild(gioi_tinh);
                nhan_vien.AppendChild(trinh_do);
                nhan_vien.AppendChild(dia_chi);

                goc.AppendChild(nhan_vien);
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK);
            }

            doc.Save(tentep);
            HienThi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;

            XmlNode nv_cu = goc.SelectSingleNode("/ds/nhanvien[@manv = '" + txtManv.Text + "']");

            if(nv_cu == null)
            {
                MessageBox.Show("Không tìm thấy mã nhân viên!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            XmlNode nv_moi = doc.CreateElement("nhanvien");
            XmlAttribute ma_nv = doc.CreateAttribute("manv");
            XmlNode ho_ten = doc.CreateElement("hoten");
            XmlNode ho = doc.CreateElement("ho");
            XmlNode ten = doc.CreateElement("ten");
            XmlNode gioi_tinh = doc.CreateElement("gioitinh");
            XmlNode trinh_do = doc.CreateElement("trinhdo");
            XmlNode dia_chi = doc.CreateElement("diachi");

            ma_nv.InnerText = txtManv.Text;
            ho.InnerText = txtHo.Text;
            ten.InnerText = txtTen.Text;
            if (radioBtnNam.Checked == true)
            {
                gioi_tinh.InnerText = "Nam";
            }
            else
            {
                gioi_tinh.InnerText = "Nữ";
            }
            trinh_do.InnerText = cbxTrinhdo.Text;
            dia_chi.InnerText = txtDiachi.Text;

            nv_moi.Attributes.Append(ma_nv);
            nv_moi.AppendChild(ho_ten);
            ho_ten.AppendChild(ho);
            ho_ten.AppendChild(ten);
            nv_moi.AppendChild(gioi_tinh);
            nv_moi.AppendChild(trinh_do);
            nv_moi.AppendChild(dia_chi);

            DialogResult res = MessageBox.Show("Bạn có chắc chắn sửa không?", "Xác nhận sửa", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                goc.ReplaceChild(nv_moi, nv_cu);
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK);
            }

            doc.Save(tentep);
            HienThi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;
            XmlNode nv_xoa = goc.SelectSingleNode("/ds/nhanvien[@manv = '" + txtManv.Text + "']");

            if(nv_xoa == null)
            {
                MessageBox.Show("Không tìm thấy mã nhân viên!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            DialogResult res = MessageBox.Show("Bạn có chắc chắn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                goc.RemoveChild(nv_xoa);
            }

            doc.Save(tentep);
            HienThi();
        }


        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            doc.Load(tentep);
            XmlElement goc = doc.DocumentElement;
            XmlNodeList DS = doc.SelectNodes("/ds/nhanvien");
            XmlNode nhanVien = goc.SelectSingleNode("/ds/nhanvien[@manv='" + txtTim.Text + "']");
            datanhanvien.Rows.Clear();
            datanhanvien.Rows.Add();
            int sd = 0;

            foreach (XmlNode nv in DS)
            {
                if (nhanVien.SelectSingleNode("@manv").InnerText == nv.SelectSingleNode("@manv").InnerText)
                {
                    XmlNode manv = nv.SelectSingleNode("@manv");
                    datanhanvien.Rows[sd].Cells[0].Value = manv.InnerText;

                    XmlNode ho = nv.SelectSingleNode("hoten/ho");
                    datanhanvien.Rows[sd].Cells[1].Value = ho.InnerText;

                    XmlNode ten = nv.SelectSingleNode("hoten/ten");
                    datanhanvien.Rows[sd].Cells[2].Value = ten.InnerText;

                    XmlNode gioitinh = nv.SelectSingleNode("gioitinh");
                    datanhanvien.Rows[sd].Cells[3].Value = gioitinh.InnerText;

                    XmlNode trinhdo = nv.SelectSingleNode("trinhdo");
                    datanhanvien.Rows[sd].Cells[4].Value = trinhdo.InnerText;

                    XmlNode diachi = nv.SelectSingleNode("diachi");
                    datanhanvien.Rows[sd].Cells[5].Value = diachi.InnerText;

                    datanhanvien.Rows.Add();
                    sd++;
                }
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);
            if(res == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string path = @"E:\Documents\Giao trinh hoc online\4th year\Tich hop HTPM\Codes\TX2\WindowsFormsApp1\dsnhanvien.xml";
            System.Diagnostics.Process.Start("Explorer.exe", path);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtManv.Clear();
            txtHo.Clear();
            txtTen.Clear();
            txtDiachi.Clear();
            txtTim.Clear();
            ActiveControl = txtManv;
        }
    }
}
