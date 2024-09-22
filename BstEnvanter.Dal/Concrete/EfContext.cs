using BstEnvanter.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Dal.Concrete
{
    public class EfContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-2FDAH6B\SQLEXPRESS;Database=BstEnvanter;Trusted_Connection=true");
        }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Campus> Campus { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CLocation> CLocation { get; set; }
        public DbSet<Common> Common { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Model> Model { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Sex> Sex { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Cpu> Cpu { get; set; }
        public DbSet<Gpu> Gpu { get; set; }
        public DbSet<HardDrive> HardDrive { get; set; }
        public DbSet<Ram> Ram { get; set; }
        public DbSet<Service> Service { get; set; }
    }
}
