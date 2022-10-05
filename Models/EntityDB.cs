using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Shivam.Models.Domain;

namespace Shivam.Models
{
    public class EntityDB : DbContext
    {
        public EntityDB() : base ("name=EntityDB")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Emp>Emps { get; set; }
        public DbSet<User>Users { get; set; }
    }
}