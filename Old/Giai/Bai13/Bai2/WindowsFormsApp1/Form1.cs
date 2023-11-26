using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net;

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
            LoadCombo();
        }

        public void LoadData()
        {
            string link = "http://localhost/Bai2/api/sanpham";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            object data = js.ReadObject(response.GetResponseStream());
            SanPham[] kq = (SanPham[])data;
            bang.DataSource = kq;
        }

        public void LoadCombo()
        {
            string link = "http://localhost/Bai2/api/danhmuc";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DanhMuc[]));
            object data = js.ReadObject(response.GetResponseStream());
            DanhMuc[] kq = (DanhMuc[])data;
            cbDanhMuc.DataSource = kq;
            cbDanhMuc.ValueMember = "MaDanhMuc";
            cbDanhMuc.DisplayMember = "TenDanhMuc";
        }

        private void bang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMaSP.Text = bang.Rows[d].Cells[0].Value.ToString();
            txtTenSP.Text = bang.Rows[d].Cells[1].Value.ToString();
            txtDonGia.Text = bang.Rows[d].Cells[2].Value.ToString();
            cbDanhMuc.Text = bang.Rows[d].Cells[3].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?ma={0}&ten={1}&gia={2}&madm={3}",
                txtMaSP.Text,txtTenSP.Text,txtDonGia.Text,cbDanhMuc.SelectedValue);
            string link = "http://localhost/Bai2/api/sanpham/" + postString;
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
                MessageBox.Show("Lưu sản phẩm thành công");
            }
            else
            {
                MessageBox.Show("Lưu sản phẩm thất bại!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?ma={0}&ten={1}&gia={2}&madm={3}",
               txtMaSP.Text, txtTenSP.Text, txtDonGia.Text, cbDanhMuc.SelectedValue);
            string link = "http://localhost/Bai2/api/sanpham/" + postString;
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
            }
            else
            {
                MessageBox.Show("Sửa sản phẩm thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bang.SelectedRows.Count == 0) return;
            DataGridViewRow row = bang.SelectedRows[0];
            string masp = row.Cells[0].Value.ToString();
            string postString = string.Format("?ma={0}",masp);
            string link = "http://localhost/Bai2/api/sanpham/" + postString;
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
            }
        }
    }
}
