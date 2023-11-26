using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCbo();
        }

        public void LoadData()
        {
            string link = "http://localhost/Lan1/api/nhanvien";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] arr = (NhanVien[])data;
            bang.DataSource = arr;
        }
        public void LoadCbo()
        {
            string link = "http://localhost/Lan1/api/donvi";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DonVi[]));
            object data = js.ReadObject(response.GetResponseStream());
            DonVi[] arr = (DonVi[])data;
            cboDonVi.DataSource = arr;
            cboDonVi.ValueMember = "MaDonVi";
            cboDonVi.DisplayMember = "TenDonVi";
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?ma={0}&ten={1}&gt={2}&hsl={3}&madv={4}",
                txtMa.Text, txtHoTen.Text, txtGioiTinh.Text, txtHsluong.Text, cboDonVi.SelectedValue);
            string link = "http://localhost/Lan1/api/nhanvien/" + postString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytes = Encoding.UTF8.GetBytes(postString);
            request.ContentLength = bytes.Length;
            Stream stream = request.GetRequestStream();         
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadData();
                MessageBox.Show("Thêm thành công!");
                ClearText();
            }
            else
            {
                MessageBox.Show("Trùng mã nhân viên!");
            }
        }

        public void ClearText()
        {
            txtMa.Clear();
            txtHoTen.Clear();
            txtGioiTinh.Clear();
            txtHsluong.Clear();
            ActiveControl = txtMa;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?ma={0}&ten={1}&gt={2}&hsl={3}&madv={4}",
                txtMa.Text, txtHoTen.Text, txtGioiTinh.Text, txtHsluong.Text, cboDonVi.SelectedValue);
            string link = "http://localhost/Lan1/api/nhanvien/" + postString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "PUT";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytes = Encoding.UTF8.GetBytes(postString);
            request.ContentLength = bytes.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadData();
                MessageBox.Show("Sửa thành công!");
                ClearText();
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã nhân viên cần sửa!");
            }
        }

        private void bang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMa.Text = bang.Rows[d].Cells[0].Value.ToString();
            txtHoTen.Text = bang.Rows[d].Cells[1].Value.ToString();
            txtGioiTinh.Text = bang.Rows[d].Cells[2].Value.ToString();
            txtHsluong.Text = bang.Rows[d].Cells[3].Value.ToString();
            cboDonVi.Text = bang.Rows[d].Cells[4].Value.ToString();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bang.SelectedRows.Count == 0) return;
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn xóa?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                DataGridViewRow row = bang.SelectedRows[0];
                string ma = row.Cells[0].Value.ToString();
                string postString = string.Format("?ma={0}", ma);
                string link = "http://localhost/Lan1/api/nhanvien/" + postString;
                HttpWebRequest request = HttpWebRequest.CreateHttp(link);
                request.Method = "DELETE";
                request.ContentType = "application/json;charset=UTF-8";
                byte[] bytes = Encoding.UTF8.GetBytes(postString);
                request.ContentLength = bytes.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
                object data = js.ReadObject(request.GetResponse().GetResponseStream());
                bool kq = (bool)data;
                if (kq)
                {
                    LoadData();
                    MessageBox.Show("Xóa thành công!");
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã nhân viên cần xóa!");
                }
            }
        }

        private void txtTimGT_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = bang.SelectedRows[0];
            string gt = row.Cells[2].Value.ToString();
            string link = "http://localhost/Lan1/api/nhanvien?gt=" + gt;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] arr = (NhanVien[])data;
            bang.DataSource = arr;
        }

        private void btnTimHsluong_Click(object sender, EventArgs e)
        {
            string a = txtMin.Text;
            string b = txtMax.Text;
            string getString = string.Format("?a={0}&b={1}",a,b);
            string link = "http://localhost/Lan1/api/nhanvien/" + getString;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] arr = (NhanVien[])data;
            bang.DataSource = arr;
        }
    }
}
