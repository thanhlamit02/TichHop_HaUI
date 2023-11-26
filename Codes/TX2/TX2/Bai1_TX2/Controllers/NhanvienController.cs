using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bai1_TX2.Models;

namespace Bai1_TX2.Controllers
{
    public class NhanvienController : ApiController
    {
        QLLuongEntities db = new QLLuongEntities();
        [HttpGet]
        public List<NhanVien> LayNV()
        {
            return db.NhanViens.ToList();
        }

        [HttpGet]
        public List<NhanVien> LayDSTheoDV(string madv)
        {
            return db.NhanViens.Where(x => x.MaDV == madv).ToList();
        }

        [HttpGet]
        public List<NhanVien> LayDSTheoGT(string gioitinh)
        {
            return db.NhanViens.Where(x => x.GioiTinh == gioitinh).ToList();
        }

        [HttpGet]
        public List<NhanVien> TimTheoHSL(decimal a, decimal b)
        {
            return db.NhanViens.Where(x => x.Hsluong >= a && x.Hsluong <= b).ToList();
        }

        [HttpPost]
        public bool ThemMoi(string manv, string hoten, string gioitinh, decimal hsluong, string madv)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x => x.MaNV == manv);
            if(nv == null)
            {
                NhanVien nv1 = new NhanVien();
                nv1.MaNV = manv;
                nv1.HoTen = hoten;
                nv1.GioiTinh = gioitinh;
                nv1.Hsluong = hsluong;
                nv1.MaDV = madv;
                db.NhanViens.Add(nv1);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpPut]
        public bool Sua(string manv, string hoten, string gioitinh, decimal hsluong, string madv)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x => x.MaNV == manv);
            if (nv != null)
            {
                nv.MaNV = manv;
                nv.HoTen = hoten;
                nv.GioiTinh = gioitinh;
                nv.Hsluong = hsluong;
                nv.MaDV = madv;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool Xoa(string id)
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
