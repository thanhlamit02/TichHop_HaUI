using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class LopHocController : ApiController
    {
        QLSVEntities db = new QLSVEntities();
        [HttpGet]

        public List<LopHoc> LayLH()
        {
            return db.LopHocs.ToList();
        }
    }
}
