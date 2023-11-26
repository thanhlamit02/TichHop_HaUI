using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SinhVienController : ApiController
    {
        QLSV1Entities db = new QLSV1Entities();

        [HttpGet]
        public List<SinhVien> LaySV()
        {
            return db.SinhViens.ToList();
        }

        [HttpGet]
        public List<SinhVien> LaySV(int ma)
        {
            return db.SinhViens.Where(x => x.MaSV == ma).ToList();
        }

        [HttpPut]
        public bool SuaSV(int ma,string ten,string gt,float diem,int malop)
        {
            SinhVien sv = db.SinhViens.FirstOrDefault(x => x.MaSV == ma);
            if(sv != null)
            {
                sv.HoTen = ten;
                sv.GioiTinh = gt;
                sv.DiemTB = diem;
                sv.MaLop = malop;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
