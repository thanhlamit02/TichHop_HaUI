using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DataUntil dataUntil = new DataUntil();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
        }
        private void HienThi()
        {
            bang.DataSource = dataUntil.GetNhanViens();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMa.Text = bang.Rows[d].Cells[0].Value.ToString();
            txtHo.Text = bang.Rows[d].Cells[1].Value.ToString();
            txtTen.Text = bang.Rows[d].Cells[2].Value.ToString();
            txtDiaChi.Text = bang.Rows[d].Cells[3].Value.ToString();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            HienThi();
            ClearText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMa.Text == "" || txtHo.Text == "" || txtTen.Text == "" || txtDiaChi.Text == "")
                throw new Exception("Không để trống dữ liệu!");
                NhanVien nv = new NhanVien();
                nv.manv = txtMa.Text;
                nv.ho = txtHo.Text;
                nv.ten = txtTen.Text;
                nv.diachi = txtDiaChi.Text;
                if (dataUntil.ThemNv(nv))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo");
                    HienThi();
                    ClearText();
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void ClearText()
        {
            txtMa.Clear();
            txtHo.Clear();
            txtTen.Clear();
            txtDiaChi.Clear();
            ActiveControl = txtMa;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMa.Text == "" || txtHo.Text == "" || txtTen.Text == "" || txtDiaChi.Text == "")
                    throw new Exception("Không để trống dữ liệu!");
                NhanVien nv = new NhanVien(txtMa.Text,txtHo.Text,txtTen.Text,txtDiaChi.Text);
                if(dataUntil.SuaNv(nv))
                {
                    MessageBox.Show("Sửa thành công!");
                    HienThi();
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Lỗi khi sửa!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            dataUntil.XoaNv(txtMa.Text);
            HienThi();
            ClearText();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            List<NhanVien> nvs = dataUntil.TimDiaChi(txtDiaChi.Text);
            if(nvs.Count > 0)
            {
                bang.DataSource = nvs;
            }
        }

        private void btnPr_Click(object sender, EventArgs e)
        {
            string path = @"E:\KI1_Nam4\THHT\Giai\DangThanhHai_2020600452_bai3\WindowsFormsApp1\nhanvien.xml";
            System.Diagnostics.Process.Start("Explorer.exe", path);
        }
    }
}
