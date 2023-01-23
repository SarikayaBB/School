using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    [Table("Students")]
    public class Student : BaseUser
    {
    ICollection<Classroom>? Classrooms { get; set; }  
    }
}
