using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExercicioRazorBanco.Model;

namespace ExercicioRazorBanco.Data
{
    public class ExercicioRazorBancoContext : DbContext
    {
        public ExercicioRazorBancoContext(DbContextOptions<ExercicioRazorBancoContext> options)
            : base(options)
        {
        }
       
        public DbSet<Movie> Movie { get; set; }
    }
}
