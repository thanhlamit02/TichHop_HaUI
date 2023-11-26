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
            HienThiCBO();
        }
        public void HienThiData()
        {
            string link = "http://localhost/Lan4/api/sinhvien";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SinhVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            SinhVien[] arr = (SinhVien[])data;
            bang.DataSource = arr;
        }
        public void HienThiCBO()
        {
            string link = "http://localhost/Lan4/api/lophoc";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(LopHoc[]));
            object data = js.ReadObject(response.GetResponseStream());
            LopHoc[] arr = (LopHoc[])data;
            cboLop.DataSource = arr;
            cboLop.ValueMember = "MaLop";
            cboLop.DisplayMember = "TenLop";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            HienThiData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
                string postString = string.Format("?ma={0}&ten={1}&gt={2}&diem={3}&malop={4}",
                        txtMa.Text, txtHoTen.Text, txtGT.Text, txtDiem.Text, cboLop.SelectedValue);
                string link = "http://localhost/Lan4/api/sinhvien" + postString;
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
                    HienThiData();
                    MessageBox.Show("Sửa sinh viên thành công!");
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Trùng mã sinh viên!");
                }
         
           
        }

        private void ClearText()
        {
            txtMa.Clear();
            txtHoTen.Clear();
            txtGT.Clear();
            txtDiem.Clear();
            ActiveControl = txtMa;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string link = "http://localhost/Lan4/api/sinhvien?ma=" + txtMa.Text;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SinhVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            SinhVien[] arr = (SinhVien[])data;
            bang.DataSource = arr;
        }

        private void bang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMa.Text = bang.Rows[d].Cells[0].Value.ToString();
            txtHoTen.Text = bang.Rows[d].Cells[1].Value.ToString();
            txtGT.Text = bang.Rows[d].Cells[2].Value.ToString();
            txtDiem.Text = bang.Rows[d].Cells[3].Value.ToString();
            cboLop.Text = bang.Rows[d].Cells[4].Value.ToString();

        }
    }
}
