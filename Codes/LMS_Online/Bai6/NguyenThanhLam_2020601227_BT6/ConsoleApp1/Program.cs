using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            XmlDocument doc = new XmlDocument();
            doc.Load("Sanpham.xml");
            XmlElement root = doc.DocumentElement;
            XmlNodeList li = root.SelectNodes("sanpham");
            int i = 1;
            foreach (XmlNode item in li)
            {
                Console.WriteLine("------------------\nPhần tử thứ: " + i);
                Console.WriteLine("Mã sản phẩm: " + item.SelectSingleNode("masp").InnerText);
                Console.WriteLine("Tên sản phẩm: " + item.SelectSingleNode("tensp").InnerText);
                Console.WriteLine("Số lượng: " + item.SelectSingleNode("soluong").InnerText);
                i++;
            }
            Console.ReadKey();
        }
    }
}
