using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SanPhamController : ApiController
    {
        QLBanHangEntities db = new QLBanHangEntities();

        [HttpGet]
        public List<SanPham> LayDM()
        {
            return db.SanPhams.ToList();
        }
        [HttpGet]
        public SanPham GetPham(int id)
        {
            return db.SanPhams.FirstOrDefault(x => x.Ma == id);
        }
        [HttpPost]
        public bool LuuSp(int ma, string ten,int gia,int madm)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.Ma == ma);
            if (sp == null)
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

        [HttpPut]
        public bool SuaSP(int ma, string ten, int gia, int madm)
        {
            SanPham sp1 = db.SanPhams.FirstOrDefault(x => x.Ma == ma);
            if (sp1 != null)
            {
                sp1.Ma = ma;
                sp1.Ten = ten;
                sp1.DonGia = gia;
                sp1.MaDanhMuc = madm;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool DeleteSP(int ma)
        {
            SanPham sp1 = db.SanPhams.FirstOrDefault(x => x.Ma == ma);
            if (sp1 != null)
            {
                db.SanPhams.Remove(sp1);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
