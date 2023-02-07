using Domain_Layer.Models;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<RentMaster>().HasKey(r => new { r.ownerid, r.propertyid });
            //builder.Entity<RentDetails>().HasKey(r => new { r.rentid });
            //builder.Entity<Subtable>().HasKey(r => new { r.messageid });

            
        }

        public void SaveChanges(string messageid)
        {
            throw new NotImplementedException();
        }
        public DbSet<Users> users { get; set; }
        public DbSet<Owners> owners { get; set; }
        public DbSet<PropertyInfo> propertyInfos { get; set; }
        public DbSet<Tenant> tenants { get; set; }
        public DbSet<AssignedProperties> assignedproperties { get; set; } 
        public DbSet<Queries> queries { get; set; }
        //public DbSet<Subtable> subtables { get; set; }
        public DbSet<RentMaster> rentMasters { get; set; }
        public DbSet<RentDetails> rentTables { get;set; }
    }
}
