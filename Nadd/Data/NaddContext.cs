using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nadd.Model;

namespace Nadd.Models
{
    public class NaddContext : DbContext
    {
        public NaddContext (DbContextOptions<NaddContext> options)
            : base(options)
        {
        }

        public DbSet<Nadd.Model.Area> Area { get; set; }
        public DbSet<Nadd.Model.Curso> Curso { get; set; }
        public DbSet<Nadd.Model.Disciplina> Disciplina { get; set; }
        public DbSet<Nadd.Model.Professor> Professor { get; set; }
        public DbSet<Nadd.Model.Avaliacao> Avaliacao { get; set; }
        public DbSet<Nadd.Model.Questao> Questao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>().ToTable("Area");
            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<Disciplina>().ToTable("Disciplina");
            modelBuilder.Entity<Professor>().ToTable("Professor");
            modelBuilder.Entity<Avaliacao>().ToTable("Avaliacao");
            modelBuilder.Entity<Questao>().ToTable("Questao");
        }

    }
}
