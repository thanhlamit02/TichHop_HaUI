using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        DataUntil db = new DataUntil();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
        }
        public void HienThi()
        {
            bang.DataSource = db.GetNV();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int num1;
                bool ktrama = Int32.TryParse(txtMa.Text, out num1);
                if (txtMa.Text == "" || txtTen.Text == "" || (rdoNam.Checked == false & rdoNu.Checked == false)
                    || cboTrinhDo.Text == "" || txtDiaChi.Text == "")
                {
                    throw new Exception("Phải nhập đủ dữ kiện!");
                }
                if(!ktrama)
                {
                    throw new Exception("Phải nhập đúng kiểu dữ liệu!");
                }
                int ma = Int32.Parse(txtMa.Text);
                string hoten = txtTen.Text;
                string gt = (rdoNam.Checked == true) ? "Nam" : "Nữ";
                string td = cboTrinhDo.Text;
                string diachi = txtDiaChi.Text;
                NhanVien nv = new NhanVien(ma,hoten,gt,td,diachi);
                if (db.ThemNV(nv))
                {
                    HienThi();
                    MessageBox.Show("Thêm nhân viên thành công");
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Trùng mã nhân viên");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void ClearText()
        {
            txtMa.Clear();
            txtTen.Clear();
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            cboTrinhDo.Text = "";
            txtDiaChi.Clear();
            ActiveControl = txtMa;
        }

        private void bang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMa.Text = bang.Rows[d].Cells[0].Value.ToString();
            txtTen.Text = bang.Rows[d].Cells[1].Value.ToString();
            if(bang.Rows[d].Cells[2].Value.ToString() == "Nam")
            {
                rdoNam.Checked = true;
            }
            else
            {
                rdoNu.Checked = true;
            }
            cboTrinhDo.Text = bang.Rows[d].Cells[3].Value.ToString();
            txtDiaChi.Text = bang.Rows[d].Cells[4].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int num1;
                bool ktrama = Int32.TryParse(txtMa.Text, out num1);
                if (txtMa.Text == "" || txtTen.Text == "" || (rdoNam.Checked == false & rdoNu.Checked == false)
                    || cboTrinhDo.Text == "" || txtDiaChi.Text == "")
                {
                    throw new Exception("Phải nhập đủ dữ kiện!");
                }
                if (!ktrama)
                {
                    throw new Exception("Phải nhập đúng kiểu dữ liệu!");
                }
                int ma = Int32.Parse(txtMa.Text);
                string hoten = txtTen.Text;
                string gt = (rdoNam.Checked == true) ? "Nam" : "Nữ";
                string td = cboTrinhDo.Text;
                string diachi = txtDiaChi.Text;
                NhanVien nv = new NhanVien(ma, hoten, gt, td, diachi);
                if (db.SuaNV(nv))
                {
                    HienThi();
                    MessageBox.Show("Sửa thông tin nhân viên thành công");
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã nhân viên");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            NhanVien nv = db.TimNV(ma);
            if (nv != null)
            {
                List<NhanVien> nvs = new List<NhanVien>();
                nvs.Add(nv);
                bang.DataSource = nvs;
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã nhân viên");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn xóa?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if(!db.XoaNv(txtMa.Text))
                {
                    MessageBox.Show("Không tìm thấy mã nhân viên để xóa!", "Thông báo");
                }
                HienThi();
                ClearText();
            }
        }
    }
}
