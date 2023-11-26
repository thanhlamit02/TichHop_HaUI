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
using System.Runtime.Serialization.Json;
using System.IO;
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
            HienThiComboBox();
            HienThiData();
        }
        public void HienThiData()
        {
            string link = "http://localhost/Bai3/api/nhanvien";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] arr = (NhanVien[])data;
            bang.DataSource = arr;
        }

        public void HienThiComboBox()
        {
            string link = "http://localhost/Bai3/api/donvi";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DonVi[]));
            object data = js.ReadObject(response.GetResponseStream());
            DonVi[] arr = (DonVi[])data;
            cboDonVi.DataSource = arr;
            cboDonVi.ValueMember = "MaDonVi";
            cboDonVi.DisplayMember = "TenDonVi";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            HienThiData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string postLink = string.Format("?ma={0}&ten={1}&ns={2}&gt={3}&hsl={4}&madv={5}",
                txtMa.Text, txtHoTen.Text, txtNgaySinh.Text, txtGioiTinh.Text, txtHsluong.Text, cboDonVi.SelectedValue);
            string link = "http://localhost/Bai3/api/nhanvien" + postLink;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytes = Encoding.UTF8.GetBytes(postLink);
            request.ContentLength = bytes.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                HienThiData();
                MessageBox.Show("Thêm nhân viên thành công");
                clearText();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại");
            }
        }

        private void bang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMa.Text = bang.Rows[d].Cells[0].Value.ToString();
            txtHoTen.Text = bang.Rows[d].Cells[1].Value.ToString();
            txtNgaySinh.Text = bang.Rows[d].Cells[2].Value.ToString();
            txtGioiTinh.Text = bang.Rows[d].Cells[3].Value.ToString();
            txtHsluong.Text = bang.Rows[d].Cells[4].Value.ToString();
            cboDonVi.Text = bang.Rows[d].Cells[5].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string postLink = string.Format("?ma={0}&ten={1}&ns={2}&gt={3}&hsl={4}&madv={5}",
                txtMa.Text, txtHoTen.Text, txtNgaySinh.Text, txtGioiTinh.Text, txtHsluong.Text, cboDonVi.SelectedValue);
            string link = "http://localhost/Bai3/api/nhanvien" + postLink;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "PUT";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytes = Encoding.UTF8.GetBytes(postLink);
            request.ContentLength = bytes.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                HienThiData();
                MessageBox.Show("Sửa nhân viên thành công");
                clearText();
            }
            else
            {
                MessageBox.Show("Sửa nhân viên thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bang.SelectedRows.Count == 0) return;
            DataGridViewRow row = bang.SelectedRows[0];
            string ma = row.Cells[0].Value.ToString();
            string postLink = string.Format("?ma={0}",ma);
            string link = "http://localhost/Bai3/api/nhanvien" + postLink;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "DELETE";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytes = Encoding.UTF8.GetBytes(postLink);
            request.ContentLength = bytes.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                HienThiData();
                MessageBox.Show("Xóa nhân viên thành công");
                clearText();
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại");
            }
        }

        public void clearText()
        {
            txtMa.Clear();
            txtHoTen.Clear();
            txtNgaySinh.Clear();
            txtGioiTinh.Clear();
            txtHsluong.Clear();
            ActiveControl = txtMa;
        }
    }
}
