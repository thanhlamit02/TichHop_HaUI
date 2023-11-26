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
            string link = "http://localhost/restful/api/donvi";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DonVi[]));
            object data = js.ReadObject(response.GetResponseStream());
            DonVi[] kq = (DonVi[])data;
            cbDonVi.DataSource = kq;
            cbDonVi.ValueMember = "MaDonVi";
            cbDonVi.DisplayMember = "TenDonVi";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?ma={0}&ten={1}&ngaysinh={2}&gioitinh={3}&hsluong={4}&madv={5}",
                txtManv.Text, txtHoTen.Text, "2002-11-03T00:00:00", txtGioiTinh.Text, txtHsluong.Text, cbDonVi.SelectedValue);
            string link = "http://localhost/restful/api/nhanvien/" + postString;
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
                MessageBox.Show("Lưu nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Lưu nhân viên thất bại");
            }
        }
    }
}
