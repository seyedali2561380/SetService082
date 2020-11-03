using BOL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Domain
{
    public class Company : BaseEntity
    {
        public Company()
        {
            this.services = new HashSet<Service>();
        }
        public virtual ICollection<Service> services { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
