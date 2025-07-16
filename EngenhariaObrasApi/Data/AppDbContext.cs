using Microsoft.EntityFrameworkCore;
using EngenhariaObrasApi.Models;

namespace EngenhariaObrasApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Obra> Obras { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<MaoDeObra> MaoDeObras { get; set; }
        public DbSet<CustoAdicional> CustosAdicionais { get; set; }
        public DbSet<BDI> BDIs { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ObrasMateriais> ObrasMateriais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1:1 entre Obra e BDI
            modelBuilder.Entity<BDI>()
                .HasOne(b => b.Obra)
                .WithOne(o => o.BDI)
                .HasForeignKey<BDI>(b => b.ObraId)
                .OnDelete(DeleteBehavior.Cascade);

            // Chave composta e relacionamento N:N para ObraMaterial
            modelBuilder.Entity<ObrasMateriais>()
                .HasKey(om => new { om.ObraId, om.MaterialId });

            modelBuilder.Entity<ObrasMateriais>()
                .HasOne(om => om.Obra)
                .WithMany(o => o.ObrasMateriais)
                .HasForeignKey(om => om.ObraId);

            modelBuilder.Entity<ObrasMateriais>()
                .HasOne(om => om.Material)
                .WithMany(m => m.ObrasMateriais)
                .HasForeignKey(om => om.MaterialId);

            // 1:N com cascade delete
            modelBuilder.Entity<MaoDeObra>()
                .HasOne(m => m.Obra)
                .WithMany(o => o.MaoDeObras)
                .HasForeignKey(m => m.ObraId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CustoAdicional>()
                .HasOne(c => c.Obra)
                .WithMany(o => o.CustosAdicionais)
                .HasForeignKey(c => c.ObraId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
