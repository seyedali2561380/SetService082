using BOL.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.DbContext
{
    public class SetServiceDbContext : IdentityDbContext<User>
    {
        //public SetServiceDbContext()
        //    :base("SetServiceConnection",throwIfV1Schema:false)
        //{

        //}    

        public SetServiceDbContext()
            : base("SetServiceConnection", throwIfV1Schema: false)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<UserService> UserServices { get; set; }
        public static SetServiceDbContext Create()
        {
            return new SetServiceDbContext();
        }
    }
}
