using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Reading_Event_DAO
{
    public class BookReadingContext : DbContext
    {
        public DbSet<Event> events { get; set; }

        public DbSet<Comment> comment { get; set; }

        public DbSet<Invitation> invitation { get; set; }

        public DbSet<User> user { get; set; }

    }
}