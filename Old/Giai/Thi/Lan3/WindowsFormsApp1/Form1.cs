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
            HienThiData();
            HienThiComboBox();
        }

        public void HienThiData()
        {
            string link = "http://localhost/Lan3/api/nhanvien";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] arr = (NhanVien[])data;
            bang.DataSource = arr;
        }
        public void HienThiComboBox()
        {
            string link = "http://localhost/Lan3/api/donvi";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DonVi[]));
            object data = js.ReadObject(response.GetResponseStream());
            DonVi[] arr = (DonVi[])data;
            cboDonVi.DataSource = arr;
            cboDonVi.ValueMember = "MaDonVi";
            cboDonVi.DisplayMember = "TenDonVi";
        }

        private void bang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMa.Text = bang.Rows[d].Cells[0].Value.ToString();
            txtTen.Text = bang.Rows[d].Cells[1].Value.ToString();
            txtGT.Text = bang.Rows[d].Cells[2].Value.ToString();
            txtHsl.Text = bang.Rows[d].Cells[3].Value.ToString();
            cboDonVi.Text = bang.Rows[d].Cells[4].Value.ToString();

        }
        public void ClearText()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtGT.Clear();
            txtHsl.Clear();
            ActiveControl = txtMa;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?manv={0}&ten={1}&gt={2}&hsl={3}&madv={4}",
                txtMa.Text, txtTen.Text, txtGT.Text, txtHsl.Text, cboDonVi.SelectedValue);
            string link = "http://localhost/Lan3/api/nhanvien" + postString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytes = Encoding.UTF8.GetBytes(postString);
            request.ContentLength = bytes.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(bytes,0,bytes.Length);
            stream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                HienThiData();
                MessageBox.Show("Thêm thành công");
                ClearText();
            }
            else
            {
                MessageBox.Show("Trùng mã nhân viên!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?manv={0}&ten={1}&gt={2}&hsl={3}&madv={4}",
               txtMa.Text, txtTen.Text, txtGT.Text, txtHsl.Text, cboDonVi.SelectedValue);
            string link = "http://localhost/Lan3/api/nhanvien" + postString;
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
                HienThiData();
                MessageBox.Show("Sửa thành công");
                ClearText();
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã nhân viên!");
            }
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
                string link = "http://localhost/Lan3/api/nhanvien" + postString;
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
                    HienThiData();
                    MessageBox.Show("Xóa thành công");
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã nhân viên!");
                }
            }
        }

        private void btnTimGT_Click(object sender, EventArgs e)
        {
            string gt = txtGT.Text;
            string link = "http://localhost/Lan3/api/nhanvien?gt=" + gt;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] arr = (NhanVien[])data;
            bang.DataSource = arr;
        }

        private void btnTimHsl_Click(object sender, EventArgs e)
        {

            string hsl = string.Format("?a={0}&b={1}",txtMin.Text,txtMax.Text);
            string link = "http://localhost/Lan3/api/nhanvien" + hsl;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] arr = (NhanVien[])data;
            bang.DataSource = arr;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            HienThiData();
        }
    }
}
