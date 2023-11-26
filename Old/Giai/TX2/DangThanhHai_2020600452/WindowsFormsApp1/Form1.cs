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
        DataUntil data = new DataUntil();
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
            bang.DataSource = data.getNV();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtMaNV.Text == "" || txtHoTen.Text == "" || cbTrinhDo.Text == "" || txtDiaChi.Text == "")
                {
                    throw new Exception("Dữ liệu không được để trống");
                }
                NhanVien nv = new NhanVien();
                nv.maNV = txtMaNV.Text;
                nv.hoTen = txtHoTen.Text;
                if (rdoNam.Checked == true)
                {
                    nv.gioiTinh = rdoNam.Text;
                }
                if (rdoNu.Checked == true)
                {
                    nv.gioiTinh = rdoNu.Text;
                }
                nv.trinhDo = cbTrinhDo.Text;
                nv.diaChi = txtDiaChi.Text;
                if (data.ThemNv(nv))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo");
                    HienThi();
                    ClearText();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearText()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            ActiveControl = txtMaNV;
        }

        private void bang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMaNV.Text = bang.Rows[d].Cells[0].Value.ToString();
            txtHoTen.Text = bang.Rows[d].Cells[1].Value.ToString();
            cbTrinhDo.Text = bang.Rows[d].Cells[3].Value.ToString();
            txtDiaChi.Text = bang.Rows[d].Cells[4].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string gt = "";
            if (rdoNam.Checked == true)
            {
                gt = rdoNam.Text;
            }
            if (rdoNu.Checked == true)
            {
                gt = rdoNu.Text;
            }
            data.SuaNv(txtMaNV.Text, txtHoTen.Text, gt, cbTrinhDo.Text, txtDiaChi.Text);
            HienThi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            data.XoaNv(txtMaNV.Text);
            ClearText();
            HienThi();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string id = txtMaNV.Text;
            List<NhanVien> list = new List<NhanVien>();
            NhanVien tk = data.TimNv(id);
            if(tk != null)
            {
                list.Add(tk);
                bang.DataSource = list;
            }
        }

        private void btnPr_Click(object sender, EventArgs e)
        {
            string path = @"E:\KI1_Nam4\THHT\Giai\DangThanhHai_2020600452\WindowsFormsApp1\dsnhanvien.xml";
            System.Diagnostics.Process.Start("Explorer.exe", path);
        }
    }
}
