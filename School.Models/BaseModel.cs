using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateModified { get; set; } = DateTime.Now;
    }
}
