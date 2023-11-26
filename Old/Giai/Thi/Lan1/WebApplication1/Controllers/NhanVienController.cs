using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class NhanVienController : ApiController
    {
        QLLuong1Entities db = new QLLuong1Entities();

        [HttpGet]
        public List<NhanVien> LayNV()
        {
            return db.NhanViens.ToList();
        }

        [HttpGet]
        public List<NhanVien> LayNVHsluong(float a,float b)
        {
            return db.NhanViens.Where(x=> Single.Parse(x.Hsluong) <= a && Single.Parse(x.Hsluong) >= b).ToList();
        }

        [HttpGet]
        public List<NhanVien> LayNVTheoGT(string gt)
        {
            return db.NhanViens.Where(x => x.GioiTinh == gt).ToList();
        }

        [HttpPost]
        public bool ThemNV(int ma,string ten,string gt,string hsl,int madv)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x => x.MaNV == ma);
            if(nv == null)
            {
                NhanVien nvm = new NhanVien();
                nvm.MaNV = ma;
                nvm.HoTen = ten;
                nvm.GioiTinh = gt;
                nvm.Hsluong = hsl;
                nvm.MaDonVi = madv;
                db.NhanViens.Add(nvm);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPut]
        public bool SuaNV(int ma, string ten, string gt, string hsl, int madv)
        {
            NhanVien nvm = db.NhanViens.FirstOrDefault(x => x.MaNV == ma);
            if (nvm != null)
            {
                nvm.MaNV = ma;
                nvm.HoTen = ten;
                nvm.GioiTinh = gt;
                nvm.Hsluong = hsl;
                nvm.MaDonVi = madv;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool XoaNv(int ma)
        {
            NhanVien nvm = db.NhanViens.FirstOrDefault(x => x.MaNV == ma);
            if (nvm != null)
            {
                db.NhanViens.Remove(nvm);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
