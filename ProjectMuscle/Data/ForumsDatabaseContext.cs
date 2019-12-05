using Microsoft.EntityFrameworkCore;
using ProjectMuscle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMuscle.Data
{
    public class ForumsDatabaseContext : DbContext
    {
        public ForumsDatabaseContext(DbContextOptions<ForumsDatabaseContext> options) : base(options)
        {

        }

        public DbSet<Forum> ForumTable { get; set; } // In EF, a DbSet corresponds to a DB table.
    }
}
