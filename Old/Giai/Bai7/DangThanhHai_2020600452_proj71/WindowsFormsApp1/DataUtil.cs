using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    internal class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;

        public DataUtil()
        {
            filename = "Nganhang.xml";
            doc = new XmlDocument();
            if (!File.Exists(filename))
            {
                XmlElement nganhang = doc.CreateElement("nganhang");
                doc.AppendChild(nganhang);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }

        public bool ThemTK(Taikhoan tk)
        {
            XmlNode tkct = root.SelectSingleNode("taikhoan[sotaikhoan='" + tk.sotk + "']");
            if (tkct != null)
            {
                MessageBox.Show("Trùng mã");
                return false;
            }
            else
            {
                XmlElement tk1 = doc.CreateElement("taikhoan");
                XmlElement stk = doc.CreateElement("sotaikhoan");
                stk.InnerText = tk.sotk;
                XmlElement ttk = doc.CreateElement("tentaikhoan");
                ttk.InnerText = tk.tentk;
                XmlElement diachi = doc.CreateElement("diachi");
                diachi.InnerText = tk.diachi;
                XmlElement dt = doc.CreateElement("dienthoai");
                dt.InnerText = tk.dt;
                XmlElement st = doc.CreateElement("sotien");
                st.InnerText = tk.sotien.ToString();
                tk1.AppendChild(stk);
                tk1.AppendChild(ttk);
                tk1.AppendChild(diachi);
                tk1.AppendChild(dt);
                tk1.AppendChild(st);
                root.AppendChild(tk1);
                doc.Save(filename);
                return true;
            }
        }

        public List<Taikhoan> GetTK()
        {
            XmlNodeList li = root.SelectNodes("taikhoan");
            List<Taikhoan> tks = new List<Taikhoan>();
            foreach(XmlNode node in li)
            {
                Taikhoan tk = new Taikhoan();
                tk.sotk = node.SelectSingleNode("sotaikhoan").InnerText;
                tk.tentk = node.SelectSingleNode("tentaikhoan").InnerText;
                tk.diachi = node.SelectSingleNode("diachi").InnerText;
                tk.dt = node.SelectSingleNode("dienthoai").InnerText;
                tk.sotien = int.Parse(node.SelectSingleNode("sotien").InnerText);
                tks.Add(tk);
            }
            return tks;
        }

        public bool XoaTK(string tk)
        {
            XmlNode tkct = root.SelectSingleNode("taikhoan[sotaikhoan='" + tk + "']");
            if(tkct != null)
            {
                root.RemoveChild(tkct);
                doc.Save(filename);
                return true;
            }
            return false;
        }

        public Taikhoan TimKiemTK(string tk)
        {
            XmlNode tkct = root.SelectSingleNode("taikhoan[sotaikhoan='" + tk + "']");
            Taikhoan taikhoan = null;
            if(tkct != null)
            {
                taikhoan = new Taikhoan();
                taikhoan.sotk = tkct.SelectSingleNode("sotaikhoan").InnerText;
                taikhoan.tentk = tkct.SelectSingleNode("tentaikhoan").InnerText;
                taikhoan.diachi = tkct.SelectSingleNode("diachi").InnerText;
                taikhoan.dt = tkct.SelectSingleNode("dienthoai").InnerText;
                taikhoan.sotien = int.Parse(tkct.SelectSingleNode("sotien").InnerText);
            }
            return taikhoan;
        }

        public List<Taikhoan> TimKiemDC(string dc)
        {
            XmlNodeList tks = root.SelectNodes("taikhoan[diachi='" + dc + "']");
            List<Taikhoan> li = new List<Taikhoan>();
            foreach(XmlNode item in tks)
            {
                Taikhoan tk = new Taikhoan();
                tk.sotk = item.SelectSingleNode("sotaikhoan").InnerText;
                tk.tentk = item.SelectSingleNode("tentaikhoan").InnerText;
                tk.diachi = item.SelectSingleNode("diachi").InnerText;
                tk.dt = item.SelectSingleNode("dienthoai").InnerText;
                tk.sotien = int.Parse(item.SelectSingleNode("sotien").InnerText);
                li.Add(tk);
            }
            return li;
        }
    }
}
