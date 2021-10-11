using EnraChallenge.Application;
using EnraChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnraChallenge.Persistence
{
    public class DatabaseContext:DbContext , IDataBaseContext
    {
        public DbSet<Book> Books { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
           
        }
        


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
           

        }
    }

}
