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
        public List<SanPham> laySP()
        {
            return db.SanPhams.ToList();
        }

        [HttpGet]
        public List<SanPham> LaySPTheoDG(int a,int b)
        {
            return db.SanPhams.Where(x => x.DonGia >= a && x.DonGia <= b).ToList();
        }

        [HttpPost]
        public bool ThemSp(int ma,string ten,int dg,int madm)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.Ma == ma);
            if (sp == null)
            {
                SanPham spm = new SanPham();
                spm.Ma = ma;
                spm.Ten = ten;
                spm.DonGia = dg;
                spm.MaDanhMuc = madm;
                db.SanPhams.Add(spm);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPut]
        public bool Suasp(int ma, string ten, int dg, int madm)
        {
            SanPham spm = db.SanPhams.FirstOrDefault(x => x.Ma == ma);
            if (spm != null)
            {
                spm.Ma = ma;
                spm.Ten = ten;
                spm.DonGia = dg;
                spm.MaDanhMuc = madm;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool XoaSp(int ma)
        {
            SanPham spm = db.SanPhams.FirstOrDefault(x => x.Ma == ma);
            if (spm != null)
            {
                db.SanPhams.Remove(spm); db.SaveChanges(); return true;
            }
            return false;
        }
    }
}
