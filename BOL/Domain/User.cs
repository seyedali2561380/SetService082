using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Domain
{
    public class User:IdentityUser
    {
        public User()
        {
            this.UserServices = new HashSet<UserService>();
        }
        public virtual ICollection<UserService> UserServices { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        [Required]
        public string NationalCode { get; set; }
        public async Task <ClaimsIdentity> GenerateUserIdentityAsync(UserManager <User> manager)
        {
            //Note the authenticationYype must the one defined in CookieAuthnticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            //Add custom user claims here
            return userIdentity;

        }
    }
}
