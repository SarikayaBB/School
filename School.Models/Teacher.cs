using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    [Table("Teachers")]
    public class Teacher : BaseUser
    {
      public ICollection<Classroom>? Classrooms { get; set; }
    }
}
