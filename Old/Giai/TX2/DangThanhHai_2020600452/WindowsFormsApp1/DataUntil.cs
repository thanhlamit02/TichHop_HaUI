using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApp1
{
    class DataUntil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;

        public DataUntil()
        {
            filename = @"E:\KI1_Nam4\THHT\Giai\DangThanhHai_2020600452\WindowsFormsApp1\dsnhanvien.xml";
            doc = new XmlDocument();
            doc.Load(filename);
            root = doc.DocumentElement;
        }

        public List<NhanVien> getNV()
        {
            XmlNodeList li = root.SelectNodes("nhanvien");
            List<NhanVien> nvs = new List<NhanVien>();
            foreach(XmlNode node in li)
            {
                NhanVien nv = new NhanVien();
                nv.maNV = node.SelectSingleNode("@manv").InnerText;
                nv.hoTen = node.SelectSingleNode("hoten").InnerText;
                nv.gioiTinh = node.SelectSingleNode("gioitinh").InnerText;
                nv.trinhDo = node.SelectSingleNode("trinhdo").InnerText;
                nv.diaChi = node.SelectSingleNode("diachi").InnerText;
                nvs.Add(nv);
            }
            return nvs;
        }

        public bool ThemNv(NhanVien nv)
        {
            XmlNode nvt = root.SelectSingleNode("nhanvien[@manv='" + nv.maNV + "']");
            if (nvt != null)
            {
                return false;
            }
            else
            {
                XmlElement nv1 = doc.CreateElement("nhanvien");
                nv1.SetAttribute("manv", nv.maNV);
                XmlElement hoten = doc.CreateElement("hoten");
                hoten.InnerText = nv.hoTen;
                XmlElement gioitinh = doc.CreateElement("gioitinh");
                gioitinh.InnerText = nv.gioiTinh;
                XmlElement trinhdo = doc.CreateElement("trinhdo");
                trinhdo.InnerText = nv.trinhDo;
                XmlElement diachi = doc.CreateElement("diachi");
                diachi.InnerText = nv.diaChi;
                nv1.AppendChild(hoten);
                nv1.AppendChild(gioitinh);
                nv1.AppendChild(trinhdo);
                nv1.AppendChild(diachi);
                root.AppendChild(nv1);
                doc.Save(filename);
                return true;
            }
        }

        public bool SuaNv(string ma, string hoten,string gioitinh,string trinhdo, string diachi)
        {
            XmlNode nvt = root.SelectSingleNode("nhanvien[@manv='" + ma + "']");
            if (nvt != null)
            {
                nvt.SelectSingleNode("hoten").InnerText = hoten;
                nvt.SelectSingleNode("gioitinh").InnerText = gioitinh;
                nvt.SelectSingleNode("trinhdo").InnerText = trinhdo;
                nvt.SelectSingleNode("diachi").InnerText = diachi;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void XoaNv(string ma)
        {
            XmlNode nvt = root.SelectSingleNode("nhanvien[@manv='" + ma + "']");
            if(nvt != null)
            {
                root.RemoveChild(nvt);
                doc.Save(filename);
            }
        }

        public NhanVien TimNv(string ma)
        {
            XmlNode nvt = root.SelectSingleNode("nhanvien[@manv='" + ma + "']");
            NhanVien nv = null;
            if(nvt != null)
            {
                nv = new NhanVien();
                nv.maNV = nvt.SelectSingleNode("@manv").InnerText;
                nv.hoTen = nvt.SelectSingleNode("hoten").InnerText;
                nv.gioiTinh = nvt.SelectSingleNode("gioitinh").InnerText;
                nv.trinhDo = nvt.SelectSingleNode("trinhdo").InnerText;
                nv.diaChi = nvt.SelectSingleNode("diachi").InnerText;
            }
            return nv;
        }
    }
}
