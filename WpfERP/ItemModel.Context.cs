﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfERP
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ItemModelContainer : DbContext
    {
        public ItemModelContainer()
            : base("name=ItemModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Keszlet> KeszletSet { get; set; }
        public virtual DbSet<Termekek> TermekekSet { get; set; }
        public virtual DbSet<Szeriaszamok> SzeriaszamokSet { get; set; }
        public virtual DbSet<Polcok> PolcokSet { get; set; }
    }
}