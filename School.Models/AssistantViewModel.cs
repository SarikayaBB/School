using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace School.Models
{
    public class AssistantViewModel
    {
       public List<Teacher> Teachers { get; set; }
        public Assistant Assistant { get; set; }
    }
}
