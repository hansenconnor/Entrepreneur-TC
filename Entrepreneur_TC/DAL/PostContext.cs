using System;
using Entrepreneur_TC.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Entrepreneur_TC.DAL
{
    public class PostContext : DbContext
    {
        public PostContext()
        {
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.99.100,32771; Database=PersonDb1;User=Root; Password=");
        }
    }
}
