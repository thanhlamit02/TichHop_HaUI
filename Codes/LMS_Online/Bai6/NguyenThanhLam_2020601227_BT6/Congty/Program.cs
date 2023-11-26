using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Congty
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
            foreach (XmlNode item in li)
            {
                Console.WriteLine("------------------\nPhần tử thứ: " + i);
                Console.WriteLine("Mã nhân viên: " + item.Attributes[0].Value);
                Console.WriteLine("Tên nhân viên: " + item.SelectSingleNode("hoten").InnerText);
                Console.WriteLine("Tuổi: " + item.SelectSingleNode("tuoi").InnerText);
                Console.WriteLine("Lương: " + item.SelectSingleNode("luong").InnerText);
                Console.WriteLine("Địa chỉ: " + item.SelectSingleNode("diachi/xa").InnerText + "," + item.SelectSingleNode("diachi/huyen").InnerText + "," + item.SelectSingleNode("diachi/tinh").InnerText);
                Console.WriteLine("Số điện thoại: " + item.SelectSingleNode("dienthoai").InnerText);
                i++;
            }
            Console.ReadKey();
        }
    }
}
