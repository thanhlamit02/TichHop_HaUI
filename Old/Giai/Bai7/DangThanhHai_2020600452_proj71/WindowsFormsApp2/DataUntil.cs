using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApp2
{
    public class DataUntil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;

        public DataUntil()
        {
            filename = "dsnhanvien.xml";
            doc = new XmlDocument();
            doc.Load(filename);
            root = doc.DocumentElement;
        }

        public List<NhanVien> GetNV()
        {
            XmlNodeList li = root.SelectNodes("nhanvien");
            List<NhanVien> nvs = new List<NhanVien>();
            foreach (XmlNode node in li)
            {
                NhanVien nv = new NhanVien();
                nv.manv = Int32.Parse(node.SelectSingleNode("@manv").InnerText);
                nv.hoten = node.SelectSingleNode("hoten").InnerText;
                nv.gioitinh = node.SelectSingleNode("gioitinh").InnerText;
                nv.trinhdo = node.SelectSingleNode("trinhdo").InnerText;
                nv.diachi = node.SelectSingleNode("diachi").InnerText;
                nvs.Add(nv);
            }
            return nvs;
        }

        public bool ThemNV(NhanVien nv)
        {
            XmlNode nv1 = root.SelectSingleNode("nhanvien[@manv='" + nv.manv + "']");
            if (nv1 == null)
            {
                XmlElement nvm = doc.CreateElement("nhanvien");
                nvm.SetAttribute("manv", nv.manv+"");
                XmlElement hoten = doc.CreateElement("hoten");
                hoten.InnerText = nv.hoten;
                XmlElement gioitinh = doc.CreateElement("gioitinh");
                gioitinh.InnerText = nv.gioitinh;
                XmlElement trinhdo = doc.CreateElement("trinhdo");
                trinhdo.InnerText = nv.trinhdo;
                XmlElement diachi = doc.CreateElement("diachi");
                diachi.InnerText = nv.diachi;
                nvm.AppendChild(hoten);
                nvm.AppendChild(gioitinh);
                nvm.AppendChild(trinhdo);
                nvm.AppendChild(diachi);
                root.AppendChild(nvm);
                doc.Save(filename);
                return true;
            }
            return false;
        }

        public bool SuaNV(NhanVien nv)
        {
            XmlNode nv1 = root.SelectSingleNode("nhanvien[@manv='" + nv.manv + "']");
            if(nv1 != null)
            {
                nv1.SelectSingleNode("hoten").InnerText = nv.hoten;
                nv1.SelectSingleNode("gioitinh").InnerText = nv.gioitinh;
                nv1.SelectSingleNode("trinhdo").InnerText = nv.trinhdo;
                nv1.SelectSingleNode("diachi").InnerText = nv.diachi;
                doc.Save(filename);
                return true;
            }
            return false;
        }

        public NhanVien TimNV(string ma)
        {
            XmlNode nv1 = root.SelectSingleNode("nhanvien[@manv='" + ma + "']");
            NhanVien nv = null;
            if(nv1 != null)
            {
                nv = new NhanVien();
                nv.manv = Int32.Parse(nv1.SelectSingleNode("@manv").InnerText);
                nv.hoten = nv1.SelectSingleNode("hoten").InnerText;
                nv.gioitinh = nv1.SelectSingleNode("gioitinh").InnerText;
                nv.trinhdo = nv1.SelectSingleNode("trinhdo").InnerText;
                nv.diachi = nv1.SelectSingleNode("diachi").InnerText;
            }
            return nv;
        }

        public bool XoaNv(string ma)
        {
            XmlNode nv1 = root.SelectSingleNode("nhanvien[@manv='" + ma + "']");
            if(nv1 != null)
            {
                root.RemoveChild(nv1);
                doc.Save(filename);
                return true;
            }
            return false;
        }
    }
}
