using School.Data;
using School.Models;
using School.Repository.Abstract;
using School.Repository.Shared.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Repository.Concrete
{
    public class ClassroomRepository : Repository<Classroom>, IClassroomRepository
    {
        private readonly ApplicationDbContext _db;
        public ClassroomRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public ICollection<Classroom> FindClasses(List<Classroom> list)
        {
            //List<Classroom> classroomsDb = _db.Classrooms.ToList();
            //ICollection<Classroom> classroom = new HashSet<Classroom>();

            //foreach (var incominClass in list)
            //{
            //    foreach (var classroomDb in classroomsDb)
            //    {
            //        if (incominClass.Id == classroomDb.Id)
            //        {
            //            classroom.Add(classroomDb);
            //        }
            //    }
            //}
            ICollection<Classroom> classroom = _db.Classrooms.Where(c => list.Contains(c)).ToList();
            return classroom;

        }
    }
}
