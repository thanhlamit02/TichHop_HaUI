using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
namespace API.Controllers
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
        public List<NhanVien> TimNVTheoDV(string madv)
        {
            return db.NhanViens.Where(x => x.MaDonVi == madv).ToList();
        }
        [HttpGet]
        public List<NhanVien> TimNVTheoGT(string gioitinh)
        {
            return db.NhanViens.Where(x => x.GioiTinh == gioitinh).ToList();
        }
        [HttpGet]
        public List<NhanVien> TimNVTheoHsluong (int a, int b)
        {
            return db.NhanViens.Where(x => x.Hsluong >= a && x.Hsluong <= b ).ToList();
        }
        [HttpPost] 
        public bool ThemNV(string manv, string ten, string gioitinh, int hsluong, string madv)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x  => x.MaNV == manv);
            if(nv == null)
            {
                NhanVien nv1 = new NhanVien();
                nv1.MaNV = manv;
                nv1.HoTen = ten;
                nv1.GioiTinh = gioitinh;
                nv1.Hsluong = hsluong;
                nv1.MaDonVi = madv;
                db.NhanViens.Add(nv1);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpPut]
        public bool Update(string manv, string ten, string gioitinh, int hsluong, string madv)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x =>x.MaNV == manv);
            if(nv != null)
            {
                nv.HoTen = ten;
                nv.GioiTinh= gioitinh;
                nv.Hsluong= hsluong;
                nv.MaDonVi = madv;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpDelete]
        public bool Delete(string id)
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
