﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CSDLTestEntities : DbContext
    {
        public CSDLTestEntities()
            : base("name=CSDLTestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DanhMuc> DanhMuc { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public List<SanPham> Sanphams { get; internal set; }
    }
}
