using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bai1.Models;
namespace Bai1.Controllers
{
    public class NhanVienController : ApiController
    {
        QLLuongEntities db = new QLLuongEntities();
        [HttpGet]
        public List<NhanVien> LayNV()
        {
            return db.NhanViens.ToList();
        }
        [HttpGet]
        public List<NhanVien> LayNVTheoDV(int madv)
        {
            return db.NhanViens.Where(x => x.MaDonVi == madv).ToList();
        }
        [HttpGet]
        public List<NhanVien> LayNVTheoHs(float a, float b)
        {
            return db.NhanViens.Where(x => x.Hsluong >= a && x.Hsluong <= b).ToList();
        }

        [HttpPost]
        public bool ThemNv(int ma,string ten,float hsluong,int madv)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x => x.MaNV == ma);
            if(nv == null)
            {
                NhanVien nv1 = new NhanVien();
                nv1.MaNV = ma;
                nv1.HoTen = ten;
                nv1.Hsluong = hsluong;
                nv1.MaDonVi = madv;
                db.NhanViens.Add(nv1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPut]

        public bool SuaNv(int ma, string ten, float hsluong, int madv)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x => x.MaNV == ma);
            if (nv != null)
            {
                nv.MaNV = ma;
                nv.HoTen = ten;
                nv.Hsluong = hsluong;
                nv.MaDonVi = madv;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool XoaNV(int id)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x => x.MaNV == id);
            if(nv != null)
            {
                db.NhanViens.Remove(nv);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
