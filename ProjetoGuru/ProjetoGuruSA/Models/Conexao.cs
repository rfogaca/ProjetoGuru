namespace ProjetoGuruSA.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Conexao : DbContext
    {
        public Conexao()
            : base("name=Conexao")
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Pergunta> Pergunta { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioCredito> UsuarioCredito { get; set; }
        public virtual DbSet<UsuarioTipo> UsuarioTipo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Categoria1)
                .WithOptional(e => e.Categoria2)
                .HasForeignKey(e => e.CategoriaParent);

            modelBuilder.Entity<Pergunta>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<Pergunta>()
                .Property(e => e.Texto)
                .IsUnicode(false);

            modelBuilder.Entity<Pergunta>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.PaypalToken)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioTipo>()
                .Property(e => e.Tipo)
                .IsUnicode(false);
        }
    }
}
