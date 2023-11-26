using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Congty_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            XmlDocument doc = new XmlDocument();
            doc.Load("Congty.xml");
            XmlElement root = doc.DocumentElement;
            XmlNodeList li = root.SelectNodes("nhanvien");
            int i = 1;
            foreach (XmlNode node in li)
            {
                Console.WriteLine("--------------\n Phần tử thứ " + i);
                Console.WriteLine("Mã nhân viên: " + node.Attributes[0].Value);
                Console.WriteLine("Họ tên: " + node.SelectSingleNode("hoten").InnerText);
                Console.WriteLine("Tuổi: " + node.SelectSingleNode("tuoi").InnerText);
                Console.WriteLine("Lương: " + node.SelectSingleNode("luong").InnerText);
                Console.Write("Địa chỉ: " + node.SelectSingleNode("diachi/xa").InnerText);
                Console.Write("," + node.SelectSingleNode("diachi/huyen").InnerText);
                Console.Write("," + node.SelectSingleNode("diachi/tinh").InnerText);
                Console.WriteLine("\nĐiện thoại: " + node.SelectSingleNode("dienthoai").InnerText);
            }
            Console.ReadKey();
        }
    }
}
