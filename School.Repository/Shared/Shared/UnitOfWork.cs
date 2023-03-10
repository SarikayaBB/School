using School.Data;
using School.Models;
using School.Repository.Abstract;
using School.Repository.Concrete;
using School.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Repository.Shared.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IRepository<Student> Students { get; private set; }

        public IRepository<Teacher> Teachers { get; private set; }

        public IClassroomRepository Classrooms { get; private set; }

        public IRepository<AppUser> AppUsers { get; private set; }

        public IRepository<AppUserRole> AppUserRoles { get; private set; }
        public IRepository<Assistant> Assistants { get; private set; }


        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Students = new Repository<Student>(_db);
            Teachers = new Repository<Teacher>(_db);
            AppUsers = new Repository<AppUser>(_db);
            AppUserRoles = new Repository<AppUserRole>(_db);
            Classrooms = new ClassroomRepository(_db);
            Assistants = new Repository<Assistant>(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
