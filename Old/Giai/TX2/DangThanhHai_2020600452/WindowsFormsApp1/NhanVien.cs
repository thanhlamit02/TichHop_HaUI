using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class NhanVien
    {
        public string maNV { get; set; }
        public string hoTen { get; set; }
        public string gioiTinh { get; set; }
        public string trinhDo { get; set; }
        public string diaChi { get; set; }

        public NhanVien()
        {
        }

        public NhanVien(string maNV, string hoTen, string gioiTinh, string trinhDo, string diaChi)
        {
            this.maNV = maNV;
            this.hoTen = hoTen;
            this.gioiTinh = gioiTinh;
            this.trinhDo = trinhDo;
            this.diaChi = diaChi;
        }
    }
}
