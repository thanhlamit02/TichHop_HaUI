using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cau1.Models;
namespace Cau1.Controllers
{
    public class SanPhamController : ApiController
    {
        NhapEntities1 db = new NhapEntities1 ();
        [HttpGet]
        public List<SanPham> LaySP()
        {
            return db.SanPham.ToList();

        }
        [HttpGet]
        public List<SanPham> LaySPtheoDM(int madm)
        {
            return db.SanPham.Where(x=>x.MaDanhMuc==madm).ToList();
        }
        [HttpGet]

        public List<SanPham> TimSPtheokhoang(int a, int b)
        {
            return db.SanPham.Where(x => x.MaDanhMuc >= a && x.MaDanhMuc <= b).ToList();
        }
        [HttpPost]
        public bool ThemSP(int ma, string ten, int dongia, int madm)
        {
            SanPham sp = db.SanPham.FirstOrDefault(x=>x.Ma==ma);

            if (sp==null)
            {
                SanPham sp1 = new SanPham ();
                sp1.Ma=ma;
                sp1.Ten=ten;
                sp1.DonGia=dongia;
                sp1.MaDanhMuc=madm;
                db.SanPham.Add(sp1);
                db.SaveChanges();
                return true;
            }
            return  false;
        }
        [HttpPut]
        public bool SuaSP(int ma, string ten, int dongia, int madm)
        {
            SanPham sp = db.SanPham.FirstOrDefault(x=>x.Ma==ma);
            if (sp!=null) 
            {   
                sp.Ma=ma;
                sp.Ten = ten;
                sp.DonGia =dongia;  
                sp.MaDanhMuc=madm;
                db.SaveChanges ();  
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool XoaSP(int id)
        {
            SanPham sp = db.SanPham.FirstOrDefault(x=>x.Ma==id);
            if (sp!=null)
            {
                db.SanPham.Remove(sp);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
