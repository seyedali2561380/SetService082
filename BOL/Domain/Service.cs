using BOL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Domain
{
    public class Service : BaseEntity
    {
        public Service()
        {
            this.UserServices = new HashSet<UserService>();
        }
        public virtual ICollection<UserService> UserServices { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public string Intro { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company company { get; set; }
        public int categoryId { get; set; }
        [ForeignKey("categoryId")]
        public virtual Category category { get; set; }
    }
}
