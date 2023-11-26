using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApp1
{
    internal class DataUntil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;

        public DataUntil()
        {
            filename = @"E:\KI1_Nam4\THHT\Giai\DangThanhHai_2020600452_bai3\WindowsFormsApp1\nhanvien.xml";
            doc = new XmlDocument();
            doc.Load(filename);
            root = doc.DocumentElement;
        }
        public List<NhanVien> GetNhanViens()
        {
            XmlNodeList li = root.SelectNodes("nhanvien");
            List<NhanVien> nvs = new List<NhanVien>();
            foreach (XmlNode node in li)
            {
                NhanVien nv = new NhanVien();
                nv.manv = node.SelectSingleNode("@manv").InnerText;
                nv.ho = node.SelectSingleNode("hoten/ho").InnerText;
                nv.ten = node.SelectSingleNode("hoten/ten").InnerText;
                nv.diachi = node.SelectSingleNode("diachi").InnerText;
                nvs.Add(nv);
            }
            return nvs;
        }

        public bool ThemNv(NhanVien nv)
        {
            XmlNode nvt = root.SelectSingleNode("nhanvien[@manv='" + nv.manv + "']");
            if (nvt != null)
            {
                return false;
            }
            else
            {
                XmlElement nv1 = doc.CreateElement("nhanvien");
                nv1.SetAttribute("manv", nv.manv);
                XmlElement hoten = doc.CreateElement("hoten");
                XmlElement ho = doc.CreateElement("ho");
                ho.InnerText = nv.ho;
                XmlElement ten = doc.CreateElement("ten");
                ten.InnerText = nv.ten;
                XmlElement diachi = doc.CreateElement("diachi");
                diachi.InnerText = nv.diachi;
                nv1.AppendChild(hoten);
                hoten.AppendChild(ho);
                hoten.AppendChild(ten);
                nv1.AppendChild(diachi);
                root.AppendChild(nv1);
                doc.Save(filename); return true;
            }
        }

        public bool SuaNv(NhanVien nv)
        {
            XmlNode nvt = root.SelectSingleNode("nhanvien[@manv='" + nv.manv + "']");
            if(nvt != null)
            {
                nvt.SelectSingleNode("hoten/ho").InnerText = nv.ho;
                nvt.SelectSingleNode("hoten/ten").InnerText = nv.ten;
                nvt.SelectSingleNode("diachi").InnerText = nv.diachi;
                return true;
            }
            return false;
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

        public List<NhanVien> TimDiaChi(string diachi)
        {
            XmlNodeList li = root.SelectNodes("nhanvien[diachi='" + diachi + "']");
            List<NhanVien> nvs = new List<NhanVien>();
            if (li != null)
            {
                foreach (XmlNode node in li)
                {
                    NhanVien nv = new NhanVien();
                    nv.manv = node.SelectSingleNode("@manv").InnerText;
                    nv.ho = node.SelectSingleNode("hoten/ho").InnerText;
                    nv.ten = node.SelectSingleNode("hoten/ten").InnerText;
                    nv.diachi = node.SelectSingleNode("diachi").InnerText;
                    nvs.Add(nv);
                }
                return nvs;
            }
            return null;
        }
    }
}
