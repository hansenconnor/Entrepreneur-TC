using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Entrepreneur_TC.DAL
{
    public class mysqlContext:IdentityDbContext
    {
        public mysqlContext()
        {
        }
    }
}
