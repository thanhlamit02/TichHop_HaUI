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
           HienThiComBo();
        }

        public void HienThiData()
        {
            string link = "http://localhost/Bai4/api/nhanvien";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] kq = (NhanVien[])data;
            bang.DataSource = kq;
        }
        public void HienThiComBo()
        {
            string link = "http://localhost/Bai4/api/donvi";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DonVi[]));
            object data = js.ReadObject(response.GetResponseStream());
            DonVi[] kq = (DonVi[])data;
            cboDonVi.DataSource = kq;
            cboDonVi.ValueMember = "MaDonVi";
            cboDonVi.DisplayMember = "TenDonVi";
        }
    }
}
