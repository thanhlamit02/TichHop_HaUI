using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class NhanVien
    {
        public string manv { get; set; }
        public string ho { get; set; }
        public string ten { get; set; }
        public string diachi { get; set; }

        public NhanVien()
        {
        }

        public NhanVien(string manv, string ho, string ten, string diachi)
        {
            this.manv = manv;
            this.ho = ho;
            this.ten = ten;
            this.diachi = diachi;
        }

        public NhanVien(string ho, string ten, string diachi)
        {
            this.ho = ho;
            this.ten = ten;
            this.diachi = diachi;
        }
    }
}
