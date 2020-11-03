using BOL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Domain
{
    public class UserService : BaseEntity
    {
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User user { get; set; }
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public virtual Service service { get; set; }
    }
}
