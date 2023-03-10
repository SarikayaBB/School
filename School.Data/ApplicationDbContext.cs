using Microsoft.EntityFrameworkCore;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace School.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Assistant> Assistants { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().Navigation(a => a.AppUserRole).AutoInclude();
            modelBuilder.Entity<Student>().Navigation(a => a.Classrooms).AutoInclude();
            modelBuilder.Entity<Teacher>().Navigation(a => a.Classrooms).AutoInclude();
            modelBuilder.Entity<Assistant>().Navigation(a=>a.Teacher).AutoInclude();
        }

    }
}
