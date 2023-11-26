using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            LoadDataGridview();
            LoadComboBox();
        }

        public void LoadDataGridview()
        {
            string link = "http://localhost/Bai1/api/nhanvien";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] arr = data as NhanVien[];
            bang.DataSource = arr;
        }

        public void LoadComboBox()
        {
            string link = "http://localhost/Bai1/api/donvi";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DonVi[]));
            object data = js.ReadObject(response.GetResponseStream());
            DonVi[] arr = data as DonVi[];
            cbDonVi.DataSource = arr;
            cbDonVi.ValueMember = "MaDonVi";
            cbDonVi.DisplayMember = "TenDonVi";
        }

        private void bang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMa.Text = bang.Rows[d].Cells[0].Value.ToString();
            txtHoTen.Text = bang.Rows[d].Cells[1].Value.ToString();
            txtHsLuong.Text = bang.Rows[d].Cells[2].Value.ToString();
            cbDonVi.Text = bang.Rows[d].Cells[3].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?ma={0}&ten={1}&hsluong={2}&madv={3}",
                txtMa.Text, txtHoTen.Text, txtHsLuong.Text, cbDonVi.SelectedValue);
            string link = "http://localhost/Bai1/api/nhanvien/" + postString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] byteArray = Encoding.UTF8.GetBytes(postString);
            request.ContentLength = byteArray.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(byteArray, 0, byteArray.Length);
            stream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadDataGridview();
                MessageBox.Show("Thêm thành công");
                ClearText();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string madv = cbDonVi.SelectedValue.ToString();
            string link = "http://localhost/Bai1/api/nhanvien?madv=" + madv;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] arr = data as NhanVien[];
            bang.DataSource = arr;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?ma={0}&ten={1}&hsluong={2}&madv={3}",
                txtMa.Text, txtHoTen.Text, txtHsLuong.Text, cbDonVi.SelectedValue);
            string link = "http://localhost/Bai1/api/nhanvien/" + postString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "PUT";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] byteArray = Encoding.UTF8.GetBytes(postString);
            request.ContentLength = byteArray.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(byteArray, 0, byteArray.Length);
            stream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadDataGridview();
                MessageBox.Show("Sửa thành công");
                ClearText();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bang.SelectedRows.Count == 0) return;
            DataGridViewRow row = bang.SelectedRows[0];
            string manv = row.Cells[0].Value.ToString();
            string deleteString = string.Format("?id={0}", manv);
            string link = "http://localhost/Bai1/api/nhanvien";
            HttpWebRequest request = HttpWebRequest.CreateHttp(link + deleteString);
            request.Method = "DELETE";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytes = Encoding.UTF8.GetBytes(deleteString);
            request.ContentLength = bytes.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if(kq)
            {
                LoadDataGridview();
                MessageBox.Show("Xóa thành công");
                ClearText();
            }
        }

        public void ClearText()
        {
            txtMa.Clear();
            txtHoTen.Clear();
            txtHsLuong.Clear();
            ActiveControl = txtMa;
        }
    }
}
