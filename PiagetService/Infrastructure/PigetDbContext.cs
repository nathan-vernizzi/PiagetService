using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class PigetDbContext : DbContext
    {

        public PigetDbContext(DbContextOptions<PigetDbContext> options) : base(options) { }

        public DbSet<Escola> Escolas => Set<Escola>();
        public DbSet<Professor> Professores => Set<Professor>();
        public DbSet<Aluno> Alunos => Set<Aluno>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Escola>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Nome).HasMaxLength(200).IsRequired();
                e.Property(x => x.Endereco).HasMaxLength(300).IsRequired();
            });

            modelBuilder.Entity<Professor>(e =>
            {
                e.HasOne(p => p.Escola)
                 .WithMany(e => e.Professores)
                 .HasForeignKey(p => p.EscolaId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Aluno>(e =>
            {
                e.HasOne(a => a.Escola)
                 .WithMany(e => e.Alunos)
                 .HasForeignKey(a => a.EscolaId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
        }


    }
}
