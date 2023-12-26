using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cau1.Models;
namespace Cau1.Controllers
{
    public class DanhMucController : ApiController
    {
        NhapEntities1 db = new NhapEntities1(); 
        [HttpGet]    
        
        public List<DanhMuc> LayDM()
        {
            return db.DanhMuc.ToList();
        }
    }
}
