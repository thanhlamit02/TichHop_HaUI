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
            LoadComboBox();
        }

        public void LoadData()
        {
            string link = "http://localhost/Lan2/api/sanpham";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            object data = js.ReadObject(response.GetResponseStream());
            SanPham[] arr = (SanPham[])data;
            bang.DataSource = arr;
        }

        public void LoadComboBox()
        {
            string link = "http://localhost/Lan2/api/danhmuc";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DanhMuc[]));
            object data = js.ReadObject(response.GetResponseStream());
            DanhMuc[] arr = (DanhMuc[])data;
            cboDanhMuc.DataSource = arr;
            cboDanhMuc.ValueMember = "MaDanhMuc";
            cboDanhMuc.DisplayMember = "TenDanhMuc";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        public void ClearText()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtGia.Clear();
            ActiveControl = txtMa;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?ma={0}&ten={1}&dg={2}&madm={3}",
                txtMa.Text,txtTen.Text,txtGia.Text,cboDanhMuc.SelectedValue);
            string link = "http://localhost/Lan2/api/sanpham/" + postString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytes = Encoding.UTF8.GetBytes(postString);
            request.ContentLength = bytes.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(bytes,0, bytes.Length);
            stream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadData();
                MessageBox.Show("Lưu sản phẩm thành công");
                ClearText();
            }
            else
            {
                MessageBox.Show("Trùng mã sản phẩm");
            }
        }

        private void bang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMa.Text = bang.Rows[d].Cells[0].Value.ToString();
            txtTen.Text = bang.Rows[d].Cells[1].Value.ToString();
            txtGia.Text = bang.Rows[d].Cells[2].Value.ToString();
            cboDanhMuc.Text = bang.Rows[d].Cells[3].Value.ToString();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?ma={0}&ten={1}&dg={2}&madm={3}",
               txtMa.Text, txtTen.Text, txtGia.Text, cboDanhMuc.SelectedValue);
            string link = "http://localhost/Lan2/api/sanpham/" + postString;
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
                MessageBox.Show("Sửa sản phẩm thành công");
                ClearText();
            }
            else
            {
                MessageBox.Show("Không đúng mã sản phẩm");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bang.SelectedRows.Count == 0) return;
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn xóa?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.Yes) {
                DataGridViewRow row = bang.SelectedRows[0];
                string ma = row.Cells[0].Value.ToString();
                string postString = string.Format("?ma={0}", ma);
                string link = "http://localhost/Lan2/api/sanpham/" + postString;
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
                    MessageBox.Show("Xóa sản phẩm thành công");
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Không đúng mã sản phẩm");
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string a = txtMin.Text;
            string b = txtMax.Text;
            string link = "http://localhost/Lan2/api/sanpham?a=" + a +"&b=" + b;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            object data = js.ReadObject(response.GetResponseStream());
            SanPham[] arr = (SanPham[])data;
            if(arr.Length <= 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm");
            }
            else
            {
                bang.DataSource = arr;
            }
        }
    }
}
