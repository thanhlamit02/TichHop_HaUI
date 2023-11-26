using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("thuvien");
            CuonSach s1 = new CuonSach("s01","Giáo dục","Toán 4","100","Đỗ Tiến Đạt","03481568","42000");
            ThemSach(doc,root,s1);
            doc.AppendChild(root);
            doc.Save("ThuVien.xml");
        }

        private static void ThemSach(XmlDocument doc, XmlElement root, CuonSach s1)
        {
            XmlElement cuonsach = doc.CreateElement("cuonsach");
            cuonsach.SetAttribute("masach", s1.masach);
            cuonsach.SetAttribute("theloai", s1.theloai);
            XmlElement tensach = doc.CreateElement("tensach");
            XmlText ttensach = doc.CreateTextNode(s1.tensach);
            XmlElement sotrang = doc.CreateElement("sotrang");
            XmlText tsotrang = doc.CreateTextNode(s1.sotrang);
            XmlElement tacgia = doc.CreateElement("tacgia");
            XmlElement hoten = doc.CreateElement("hoten");
            XmlText thoten = doc.CreateTextNode(s1.hoten);
            XmlElement dienthoai = doc.CreateElement("dienthoai");
            XmlText tdienthoai = doc.CreateTextNode(s1.dienthoai);
            XmlElement giatien = doc.CreateElement("giatien");
            XmlText tgiatien = doc.CreateTextNode(s1.giatien);
            tensach.AppendChild(ttensach);
            sotrang.AppendChild(tsotrang);
            hoten.AppendChild(thoten);
            dienthoai.AppendChild(tdienthoai);
            giatien.AppendChild(tgiatien);
            root.AppendChild(cuonsach);
            cuonsach.AppendChild (tensach);
            cuonsach.AppendChild(sotrang);
            cuonsach.AppendChild(tacgia);
            tacgia.AppendChild(hoten);
            tacgia.AppendChild(dienthoai);
            cuonsach.AppendChild(giatien);
        }
    }
}
