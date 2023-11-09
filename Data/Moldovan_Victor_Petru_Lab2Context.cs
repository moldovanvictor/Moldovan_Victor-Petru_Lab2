using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moldovan_Victor_Petru_Lab2.Models;

namespace Moldovan_Victor_Petru_Lab2.Data
{
    public class Moldovan_Victor_Petru_Lab2Context : DbContext
    {
        public Moldovan_Victor_Petru_Lab2Context (DbContextOptions<Moldovan_Victor_Petru_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Moldovan_Victor_Petru_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Moldovan_Victor_Petru_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Moldovan_Victor_Petru_Lab2.Models.Author>? Author { get; set; }

        public DbSet<Moldovan_Victor_Petru_Lab2.Models.Category>? Category { get; set; }

        public DbSet<Moldovan_Victor_Petru_Lab2.Models.Member>? Member { get; set; }

        public DbSet<Moldovan_Victor_Petru_Lab2.Models.Borrowing>? Borrowing { get; set; }
    }
}
