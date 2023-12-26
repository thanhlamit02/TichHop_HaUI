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
namespace Cau2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void ShowData()
        {
            string link = "http://localhost/resf/api/sanpham";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
            WebResponse response = (WebResponse)request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            object data = js.ReadObject(response.GetResponseStream());
            SanPham[] arr = data as SanPham[];
            dataGridView1.DataSource = arr;
        }

        public void LoadCBO()
        {
            string link = "http://localhost/resf/api/danhmuc";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
            WebResponse response = (WebResponse)request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DanhMuc[]));
            object data = js.ReadObject(response.GetResponseStream());
            DanhMuc[] arr1 = data as DanhMuc[];
            cbo_danhmuc.DataSource = arr1;
            cbo_danhmuc.ValueMember = "MaDanhMuc";
            cbo_danhmuc.DisplayMember = "TenDanhMuc";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowData();
            LoadCBO();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txt_masp.Text = dataGridView1.Rows[d].Cells[0].Value.ToString();
            txt_tensp.Text = dataGridView1.Rows[d].Cells[1].Value.ToString();
            txt_dongia.Text = dataGridView1.Rows[d].Cells[2].Value.ToString();
            cbo_danhmuc.Text = dataGridView1.Rows[d].Cells[3].Value.ToString();

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?ma={0}&ten={1}&dongia={2}&madm={3}",txt_masp.Text,txt_tensp.Text,txt_dongia.Text,cbo_danhmuc.SelectedValue);

            string link = "http://localhost/resf/api/sanpham/" + postString;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
            request.Method = "POST";
            Stream dataStream = request.GetRequestStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                ShowData();
                MessageBox.Show("Them done");
            }
            else
            {
                MessageBox.Show("Them Fail");
            }
            
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {

            int dau = int.Parse(txt_tim.Text);
            int cuoi = int.Parse(txt_Timtren.Text);


            string search = string.Format("?a={0}&b={1}", dau, cuoi);

            string link = "http://localhost/resf/api/sanpham/"+search;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
            WebResponse response = (WebResponse)request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            object data = js.ReadObject(response.GetResponseStream());
            SanPham[] arr = data as SanPham[];
            dataGridView1.DataSource = arr;


        }
    }
}
