﻿using System;
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
        QLSV1Entities db = new QLSV1Entities();

        [HttpGet]
        public List<LopHoc> LaySV()
        {
            return db.LopHocs.ToList();
        }
    }
}
