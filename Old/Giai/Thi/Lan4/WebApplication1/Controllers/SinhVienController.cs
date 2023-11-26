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
        QLSVEntities db = new QLSVEntities();

        [HttpGet]
        public List<SinhVien> LayLH()
        {
            return db.SinhViens.ToList();
        }

        [HttpGet]
        public List<SinhVien> LaSV(int ma)
        {
            return db.SinhViens.Where(x => x.MaSV == ma).ToList();
        }

        [HttpPut]
        public bool Sua(int ma,string ten,string gt,double diem,int malop)
        {
            SinhVien svm = db.SinhViens.FirstOrDefault(x => x.MaSV == ma);
            if(svm != null)
            {
                svm.HoTen = ten;
                svm.GioiTinh = gt;
                svm.DiemTB = diem;
                svm.MaLop = malop;
                db.SaveChanges();
                return true;
            }
            return false;
        }


    }
}
