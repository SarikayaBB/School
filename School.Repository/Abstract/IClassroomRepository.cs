using School.Models;
using School.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Repository.Abstract
{
    public interface IClassroomRepository : IRepository<Classroom>
    {
        ICollection<Classroom> FindClasses(List<Classroom> list);
    }
}
