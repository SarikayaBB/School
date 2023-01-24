using School.Models;
using School.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Repository.Shared.Abstract
{
    public interface IUnitOfWork 
    {
        IRepository<Student> Students { get; }
        IRepository<Teacher> Teachers { get; }
        IClassroomRepository Classrooms { get; }
        IRepository<AppUser> AppUsers { get; }
        IRepository<AppUserRole> AppUserRoles { get; }
        void Save();

    }
}
