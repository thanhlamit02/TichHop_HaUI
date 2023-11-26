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
            string link = "http://localhost/Bai1/api/DonVi";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DonVi[]));
            object data = js.ReadObject(response.GetResponseStream());
            DonVi[] arr = data as DonVi[];
            cbDonVi.DataSource = arr;
            cbDonVi.ValueMember = "MaDonVi";
            cbDonVi.DisplayMember = "TenDonVi";
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            string poststring = string.Format("?ma={0}&ten={1}&hsluong={2}&madv={3}",
                txtMa.Text, txtHoTen.Text, txtHsLuong.Text, cbDonVi.SelectedValue);
            string link = "http://localhost/Bai1/api/nhanvien/" + poststring;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytes = Encoding.UTF8.GetBytes(poststring);
            request.ContentLength = bytes.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if(kq)
            {
                MessageBox.Show("Lưu thành công nhân viên");
            }
            else
            {
                MessageBox.Show("Lưu nhân viên thất bại!");
            }
        }
    }
}
