using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Taikhoan
    {
        public string sotk { get; set; }
        public string tentk { get; set; }
        public string diachi { get; set; }
        public string dt { get; set; }
        public int sotien { get; set; }

        public Taikhoan()
        {
        }

        public Taikhoan(string sotk, string tentk, string diachi, string dt, int sotien)
        {
            this.sotk = sotk;
            this.tentk = tentk;
            this.diachi = diachi;
            this.dt = dt;
            this.sotien = sotien;
        }
    }
}
