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
using static System.Net.WebRequestMethods;

namespace B1_TX2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void LoadDataGridView()
        {
            string links = "http://localhost/restapi/api/nhanvien";
            HttpWebRequest request = WebRequest.CreateHttp(links);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] arr = data as NhanVien[];
            dataGridView1.DataSource = arr;
        }

        public void LoadComboBox()
        {
            string link = "http://localhost/restapi/api/donvi";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DonVi[]));
            object data = js.ReadObject(response.GetResponseStream());
            DonVi[] arr1 = data as DonVi[];
            dataGridView1.DataSource = arr1;
            cbxDonvi.DataSource = arr1;
            cbxDonvi.ValueMember = "MaDV";
            cbxDonvi.DisplayMember = "TenDV";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadComboBox();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?manv={0} & hoten={1} & gt={2} & hsl={3} & madv={4}", txtManv.Text, txtHoten.Text, txtGioitinh.Text, txtHsluong.Text, cbxDonvi.SelectedValue);
            string link = "http://localhost/restapi/api/nhanvien" + postString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "POST";

            Stream dataStream = request.GetRequestStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadDataGridView();
                MessageBox.Show("Thêm nhân viên thành công !");
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại!");
            }

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtManv.Text = dataGridView1.Rows[d].Cells[0].Value.ToString();
            txtHoten.Text = dataGridView1.Rows[d].Cells[1].Value.ToString();
            txtGioitinh.Text = dataGridView1.Rows[d].Cells[2].Value.ToString();
            txtHsluong.Text = dataGridView1.Rows[d].Cells[3].Value.ToString();
            cbxDonvi.Text = dataGridView1.Rows[d].Cells[4].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string putString = string.Format("?manv={0} & hoten={1} & gt={2} & hsl={3} & madv={4}", txtManv.Text, txtHoten.Text, txtGioitinh.Text, txtHsluong.Text, cbxDonvi.SelectedValue);
            string link = "http://localhost/restapi/api/nhanvien" + putString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "PUT";

            Stream dataStream = request.GetRequestStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                MessageBox.Show("Sửa thành công!");
                LoadDataGridView();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string manv = txtManv.Text;
            string deleteString = string.Format("?id={0}", manv);
            string link = "http://localhost/restapi/api/nhanvien";
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "DELETE";
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                LoadDataGridView();
                MessageBox.Show("Xóa thành công!");
            }
        }

        private void btnFindbysex_Click(object sender, EventArgs e)
        {
            string gt = txtGioitinh.Text;
            string link = "http://localhost/restapi/api/nhanvien?gioitinh=" + gt;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] arr = data as NhanVien[];
            dataGridView1.DataSource = arr;
        }
    }
}
