using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    [Table("AppUserRoles")]
    public class AppUserRole : BaseModel
    {
        public string RoleName { get; set; }

    }
}
