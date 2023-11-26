using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class NhanVien
    {
        public int manv { get; set; }
        public string hoten { get; set; }
        public string gioitinh { get; set; }
        public string trinhdo { get; set; }
        public string diachi { get; set; }

        public NhanVien()
        {
        }

        public NhanVien(int manv, string hoten, string gioitinh, string trinhdo, string diachi)
        {
            this.manv = manv;
            this.hoten = hoten;
            this.gioitinh = gioitinh;
            this.trinhdo = trinhdo;
            this.diachi = diachi;
        }
    }
}
