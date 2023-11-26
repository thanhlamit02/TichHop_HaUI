using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class SanPham
    {
        public int Ma { get; set; }
        public string Ten { get; set; }
        public int DonGia { get; set; }
        public int MaDanhMuc { get; set; }

        public SanPham()
        {
        }

        public SanPham(int ma, string ten, int donGia, int maDanhMuc)
        {
            Ma = ma;
            Ten = ten;
            DonGia = donGia;
            MaDanhMuc = maDanhMuc;
        }
    }
}
