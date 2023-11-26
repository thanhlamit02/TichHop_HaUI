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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadList();
            LoadCombo();
        }

        public void LoadList()
        {
            string link = "http://localhost/Bai1/api/nhanvien";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] arr = (NhanVien[])data;
            listNhanVien.DataSource = arr;
            listNhanVien.ValueMember = "MaNV";
            listNhanVien.DisplayMember = "HoTen";
        }
        public void LoadCombo()
        {
            string link = "http://localhost/Bai1/api/donvi";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DonVi[]));
            object data = js.ReadObject(response.GetResponseStream());
            DonVi[] arr = (DonVi[])data;
            cbDonVi.DataSource = arr;
            cbDonVi.ValueMember = "MaDonVi";
            cbDonVi.DisplayMember = "TenDonVi";
        }

        private void listNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listNhanVien.SelectedIndex == -1) return;
            NhanVien nv = listNhanVien.SelectedItem as NhanVien;
            txtMa.Text = nv.MaNV + "";
            txtHoTen.Text = nv.HoTen;
            txtHsLuong.Text = nv.Hsluong + "";
            cbDonVi.Text = nv.MaDonVi + "";
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            string putString = string.Format("?ma={0}&ten={1}&hsluong={2}&madv={3}",
                txtMa.Text,txtHoTen.Text,txtHsLuong.Text,cbDonVi.SelectedValue);
            string link = "http://localhost/Bai1/api/nhanvien/" + putString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "PUT";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytes = Encoding.UTF8.GetBytes(putString);
            request.ContentLength = bytes.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(bytes,0, bytes.Length);
            stream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa Thất bại!");
            }
        }
    }
}
