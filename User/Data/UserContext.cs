using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace User.Models
{
    public class UserContext : DbContext

    {
        
        public virtual DbSet<NewUser> NewUsers { get; set; }
    }
}