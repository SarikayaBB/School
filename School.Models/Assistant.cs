using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    [Table("Assistants")]
    public class Assistant : BaseUser
    {
        public Guid TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
