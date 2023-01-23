using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    [Table("Classrooms")]
    public class Classroom : BaseModel
    {
        public string? ClassName { get; set; }

        public ICollection<Student>? Students { get; set; }
        public ICollection<Teacher>? Teachers { get; set; }


    }
}
