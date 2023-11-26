using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class NhanVienController : ApiController
    {
        QLLuong2Entities db = new QLLuong2Entities();
        [HttpGet]
        public List<NhanVien> LayNV()
        {
            return db.NhanViens.ToList();
        }

        [HttpPost]
        
        public bool ThemNV(int ma,string ten,string gt,string hsl,int madv)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x => x.Ma == ma);
            if(nv == null) {
                NhanVien nv1 = new NhanVien();
                nv1.Ma = ma;
                nv1.HoTen = ten;
                nv1.NgaySinh = gt;  
                nv1.GioiTinh = gt;
                nv1.Hsluong = hsl;
                nv1.MaDonVi = madv;
                db.NhanViens.Add(nv1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPut]

        public bool SuaNV(int ma, string ten, string gt, string hsl, int madv)
        {
            NhanVien nv1 = db.NhanViens.FirstOrDefault(x => x.Ma == ma);
            if (nv1 != null)
            {
                nv1.Ma = ma;
                nv1.HoTen = ten;
                nv1.GioiTinh = gt;
                nv1.Hsluong = hsl;
                nv1.MaDonVi = madv;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool XoaNV(int ma)
        {
            NhanVien nv1 = db.NhanViens.FirstOrDefault(x => x.Ma == ma);
            if (nv1 != null)
            {
                db.NhanViens.Remove(nv1);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
