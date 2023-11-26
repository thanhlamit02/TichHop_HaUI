using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DataUtil dataUtil = new DataUtil();
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
            bang.DataSource = dataUtil.GetTK();
            bang.Columns[0].HeaderText = "Số TK";
            bang.Columns[1].HeaderText = "Tên TK";
            bang.Columns[2].HeaderText = "Địa chỉ";
            bang.Columns[3].HeaderText = "Điện thoại";
            bang.Columns[4].HeaderText = "Số tiền";
            bang.Columns[0].Width = 80;
            bang.Columns[1].Width = 150;
            bang.Columns[2].Width = 100;
            bang.Columns[3].Width = 100;
            bang.Columns[4].Width = 100;
        }

        private void loadFile_Click(object sender, EventArgs e)
        {
            HienThi();
        }

        private void themTK_Click(object sender, EventArgs e)
        {
            int num1;
            bool ktraMa = Int32.TryParse(txtSoTien.Text, out num1);
            try
            {
                if (txtSoTK.Text == "" || txtTenTK.Text == "" || txtDiaChi.Text == "" || txtSoDT.Text == "" || txtSoTien.Text == "")
                    throw new Exception("Không được để dữ liệu trống!");
                if (!ktraMa)
                    throw new Exception("Phải nhập đúng kiểu dữ liệu số tiền!");
                Taikhoan tk = new Taikhoan();
                tk.sotk = txtSoTK.Text;
                tk.tentk = txtTenTK.Text;
                tk.diachi = txtDiaChi.Text;
                tk.dt = txtSoDT.Text;
                tk.sotien = Int32.Parse(txtSoTien.Text);
                if (dataUtil.ThemTK(tk))
                {
                    ClearText();
                    MessageBox.Show("Thêm thành công", "Thông báo");
                    HienThi();
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
           
        }

        private void ClearText()
        {
            txtSoTK.Clear();
            txtTenTK.Clear();
            txtDiaChi.Clear();
            txtSoDT.Clear();
            txtSoTien.Clear();
            ActiveControl = txtSoTK;
        }

        private void bang_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                bool kt = dataUtil.XoaTK(txtSoTK.Text);
                if (!kt)
                {
                    MessageBox.Show("Có lỗi khi xóa!", "Thông báo");
                    return;
                }
                HienThi();
                ClearText();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string id = txtSoTK.Text;
            List<Taikhoan> list = new List<Taikhoan>();
            Taikhoan tk = dataUtil.TimKiemTK(id);
            if (tk != null)
            {
                list.Add(tk);
                bang.DataSource = list;
                txtSoTK.Text = tk.sotk;
                txtTenTK.Text = tk.tentk;
                txtDiaChi.Text = tk.diachi;
                txtSoDT.Text = tk.dt;
                txtSoTien.Text = tk.sotien.ToString();
            }
        }

        private void btnDC_Click(object sender, EventArgs e)
        {
            string dc = txtDiaChi.Text;
            bang.DataSource = dataUtil.TimKiemDC(dc);
        }
    }
}
