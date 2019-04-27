using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Entrepreneur_TC.Models;

namespace Entrepreneur_TC.DAL
{
    public class UserContext : DbContext
    {
        public DbSet<User> user { get; set; }
    }
}
