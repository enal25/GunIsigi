﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KasifBusiness.DB_Operations.EntityObject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GN_KASIFEntities : DbContext
    {
        public GN_KASIFEntities()
            : base("name=GN_KASIFEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<USER_USER> USER_USER { get; set; }
        public virtual DbSet<MENU_TREE> MENU_TREE { get; set; }
        public virtual DbSet<USER_ROLE> USER_ROLE { get; set; }
        public virtual DbSet<USER_ROLE_MENU> USER_ROLE_MENU { get; set; }
        public virtual DbSet<USER_ROLE_OWNERSHIP> USER_ROLE_OWNERSHIP { get; set; }
        public virtual DbSet<USER_SESSION_INFO> USER_SESSION_INFO { get; set; }
        public virtual DbSet<USER_STATUS> USER_STATUS { get; set; }
        public virtual DbSet<OGR_BILGI> OGR_BILGI { get; set; }
        public virtual DbSet<MENU_TILES> MENU_TILES { get; set; }
        public virtual DbSet<BOLGE_INFO> BOLGE_INFO { get; set; }
        public virtual DbSet<HOCA_BILGI> HOCA_BILGI { get; set; }
        public virtual DbSet<QUERY_TABLE> QUERY_TABLE { get; set; }
        public virtual DbSet<DERS_KONU_BILGI> DERS_KONU_BILGI { get; set; }
        public virtual DbSet<DEVAMSIZLIK_BILGI> DEVAMSIZLIK_BILGI { get; set; }
        public virtual DbSet<HAFTA_BILGI> HAFTA_BILGI { get; set; }
        public virtual DbSet<MUFREDAT_TAKIP> MUFREDAT_TAKIP { get; set; }
        public virtual DbSet<OGR_TEST_REL> OGR_TEST_REL { get; set; }
        public virtual DbSet<TEST_BILGI> TEST_BILGI { get; set; }
        public virtual DbSet<DERS_BILGI> DERS_BILGI { get; set; }
    }
}
