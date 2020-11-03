using BOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Domain
{
    public class Category : BaseEntity
    {
        public Category()
        {
            this.services = new HashSet<Service>();

        }
        public virtual ICollection<Service> services { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
