using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
namespace UseAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void Showdata()
        {
            string link = "http://localhost/hocrestful/api/nhanvien";

            HttpWebRequest request = WebRequest.CreateHttp(link);

            WebResponse response = request.GetResponse();

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanViencs[]));

            object data = js.ReadObject(response.GetResponseStream());

            NhanViencs[] arr = data as NhanViencs[];

            dataGridView1.DataSource = arr;
        }
        public void LoadCBO()
        {
            string link = "http://localhost/hocrestful/api/donvi";

            HttpWebRequest  request = HttpWebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DonVi[]));
            object data = js.ReadObject(response.GetResponseStream());
            DonVi[] arr1 = data as DonVi[];
            cbo_DonVi.DataSource = arr1;
            cbo_DonVi.ValueMember = "MaDonVi";
            cbo_DonVi.DisplayMember = "TenDonVi";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Showdata();
            LoadCBO();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txt_MaNV.Text = dataGridView1.Rows[d].Cells[0].Value.ToString();
            txt_Hoten.Text = dataGridView1.Rows[d].Cells[1].Value.ToString();
            txt_Gioitinh.Text = dataGridView1.Rows[d].Cells[2].Value.ToString();
            txt_hsluong.Text = dataGridView1.Rows[d].Cells[3].Value.ToString();
            cbo_DonVi.Text = dataGridView1.Rows[d].Cells[4].Value.ToString();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?manv={0}&ten={1}&gioitinh={2}&hsluong={3}&madv={4}", txt_MaNV.Text, txt_Hoten.Text, txt_Gioitinh.Text, txt_hsluong.Text, cbo_DonVi.SelectedValue);
            string link = "http://localhost/hocrestful/api/nhanvien/" + postString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "POST";
            Stream dataStream = request.GetRequestStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                Showdata();
                MessageBox.Show("Thêm Nhân viên thành công"); 
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string putString = string.Format("?manv={0}&ten={1}&gioitinh={2}&hsluong={3}&madv={4}", txt_MaNV.Text, txt_Hoten.Text, txt_Gioitinh.Text, txt_hsluong.Text, cbo_DonVi.SelectedValue);
            string link = "http://localhost/hocrestful/api/nhanvien/" + putString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "PUT";
            Stream dataStream = request.GetRequestStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                Showdata();
                MessageBox.Show("Sửa Nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string manv = txt_MaNV.Text;
            string deleteString = string.Format("?id={0}", manv);
            string link = "http://localhost/hocrestful/api/nhanvien/" + deleteString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "DELETE";
            Stream dataStream = request.GetRequestStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                Showdata();
                MessageBox.Show("Xóa Nhân viên thành công!");
            }
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string gioitinh = txt_Gioitinh.Text;
            string link = "http://localhost/hocrestful/api/nhanvien?gioitinh=" + gioitinh;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanViencs[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanViencs[] arr = data as NhanViencs[];
            dataGridView1.DataSource = arr;

        }

    }
}
