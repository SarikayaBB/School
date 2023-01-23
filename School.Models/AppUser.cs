using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    [Table("AppUser")]
    public class AppUser : BaseUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid AppUserRoleId { get; set; }
        public virtual AppUserRole? AppUserRole { get; set; }
        
    }
}
