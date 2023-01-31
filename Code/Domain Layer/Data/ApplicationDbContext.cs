using Domain_Layer.Models;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        public void SaveChanges(string messageid)
        {
            throw new NotImplementedException();
        }

        public DbSet<Owners> owners { get; set; }
        public DbSet<PropertyInfo> propertyInfos { get; set; }
        public DbSet<Tenant> tenants { get; set; }
        public DbSet<Assigned> assignedproperties { get; set; } 
        public DbSet<Queries> queries { get; set; }
        public DbSet<Subtable> subtables { get; set; }
    }
}
