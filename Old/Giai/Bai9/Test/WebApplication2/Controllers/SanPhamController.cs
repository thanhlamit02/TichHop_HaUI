using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SanPhamController : ApiController
    {
        CSDLTestEntities1 db = new CSDLTestEntities1();
        [HttpGet]

        public List<SanPham> LaySP()
        {
            return db.SanPhams.ToList();
        }

        [HttpGet]
        public SanPham LaySPTheoMa(int ma)
        {
            return db.SanPhams.SingleOrDefault(x => x.Ma == ma);
        }

        [HttpGet]
        public List<SanPham> LaySpTheoDM(int madm)
        {
            return db.SanPhams.Where(x => x.MaDanhMuc == madm).ToList();
        }

        [HttpPost]
        public bool ThemMoi(int ma,string ten,int gia,int madm)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(x => x.Ma == ma);
            if(sp == null)
            {
                SanPham sp1 = new SanPham();
                sp1.Ma = ma;
                sp1.Ten = ten;
                sp1.DonGia = gia;
                sp1.MaDanhMuc = madm;
                db.SanPhams.Add(sp1);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
