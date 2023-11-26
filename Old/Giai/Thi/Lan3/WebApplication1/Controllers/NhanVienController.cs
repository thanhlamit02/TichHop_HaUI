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
        QLLuong2Entities db = new QLLuong2Entities();

        [HttpGet]
        public List<NhanVien> LayDV()
        {
            return db.NhanViens.ToList();
        }

        [HttpGet]
        public List<NhanVien> LayNVTheoGT(string gt)
        {
            return db.NhanViens.Where(x => x.GioiTinh == gt).ToList();
        }

        [HttpGet]
        public List<NhanVien> LayNVTheoLuong(float a,float b)
        {
            return db.NhanViens.Where(x => x.Hsluong >= a && x.Hsluong <= b).ToList();
        }

        [HttpPost]
        public bool ThemNV(int manv,string ten,string gt,float hsl,int madv)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x => x.MaNV == manv);
            if(nv == null)
            {
                NhanVien nvm = new NhanVien();
                nvm.MaNV = manv;
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
        public bool SuaNV(int manv, string ten, string gt, float hsl, int madv)
        {
            NhanVien nvm = db.NhanViens.FirstOrDefault(x => x.MaNV == manv);
            if (nvm != null)
            {
                nvm.MaNV = manv;
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
        public bool XoaNV(int ma)
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
