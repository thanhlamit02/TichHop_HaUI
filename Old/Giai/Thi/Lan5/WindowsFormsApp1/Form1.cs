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
            HienThi();
            HienThiCBO();
        }

        public void HienThi()
        {
            string link = "http://localhost/Lan5/api/sinhvien";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SinhVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            SinhVien[] arr = (SinhVien[])data;
            bang.DataSource = arr;
        }

        public void HienThiCBO()
        {
            string link = "http://localhost/Lan5/api/lophoc";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(LopHoc[]));
            object data = js.ReadObject(response.GetResponseStream());
            LopHoc[] arr = (LopHoc[])data;
            cboLop.DataSource = arr;
            cboLop.ValueMember = "MaLop";
            cboLop.DisplayMember = "TenLop";
        }

        private void bang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMa.Text = bang.Rows[d].Cells[0].Value.ToString();
            txtTen.Text = bang.Rows[d].Cells[1].Value.ToString();
            txtGt.Text = bang.Rows[d].Cells[2].Value.ToString();
            txtDiem.Text = bang.Rows[d].Cells[3].Value.ToString();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string post = string.Format("?ma={0}&ten={1}&gt={2}&diem={3}&malop={4}",
                txtMa.Text, txtTen.Text, txtGt.Text, txtDiem.Text, cboLop.SelectedValue);
            string link = "http://localhost/Lan5/api/sinhvien" + post;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "PUT";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytes = Encoding.UTF8.GetBytes(post);    
            request.ContentLength = bytes.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(bytes,0, bytes.Length);
            stream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                HienThi();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string link = "http://localhost/Lan5/api/sinhvien?ma=" + txtMa.Text;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SinhVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            SinhVien[] arr = (SinhVien[])data;
            bang.DataSource = arr;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            HienThi();
        }
    }
}
