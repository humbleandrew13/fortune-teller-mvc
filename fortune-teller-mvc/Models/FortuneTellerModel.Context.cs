﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fortune_teller_mvc.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FortuneTellerMVCEntities : DbContext
    {
        public FortuneTellerMVCEntities()
            : base("name=FortuneTellerMVCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BirthMonth> BirthMonths { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<FavoriteColor> FavoriteColors { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}