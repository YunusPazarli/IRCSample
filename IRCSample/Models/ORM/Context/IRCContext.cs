using IRCSample.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRCSample.Models.ORM.Context
{
    public class IRCContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=localhost\SQLEXPRESS;database=IRCDB;trusted_connection=true;");
        }

        public DbSet<ChatUsers> ChatUsers { get; set; }
    }

}
