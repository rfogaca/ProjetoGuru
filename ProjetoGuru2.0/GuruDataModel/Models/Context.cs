namespace GuruDataModel
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class Context : DbContext
	{
		public Context()
			: base("name=LocalContext")
		{
			this.Configuration.LazyLoadingEnabled = false;
		}

		public virtual DbSet<Categoria> Categoria { get; set; }
		public virtual DbSet<Pergunta> Pergunta { get; set; }
		public virtual DbSet<Usuario> Usuario { get; set; }
		public virtual DbSet<UsuarioCredito> UsuarioCredito { get; set; }
		public virtual DbSet<UsuarioTipo> UsuarioTipo { get; set; }
		public virtual DbSet<Resposta> Resposta { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Categoria>()
				.Property(e => e.NomeCategoria)
				.IsUnicode(false);

			modelBuilder.Entity<Categoria>()
				.HasMany(e => e.Categoria1)
				.WithOptional(e => e.Categoria2)
				.HasForeignKey(e => e.CategoriaParent);

			modelBuilder.Entity<Categoria>()
				.HasMany(e => e.Usuario)
				.WithMany(e => e.Categoria)
				.Map(m => m.ToTable("UsuarioCategoria").MapLeftKey("CategoriaID").MapRightKey("UsuarioID"));

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

			modelBuilder.Entity<Pergunta>()
				.HasMany(e => e.Resposta)
				.WithRequired(e => e.Pergunta)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Usuario>()
				.Property(e => e.Email)
				.IsUnicode(false);

			modelBuilder.Entity<Usuario>()
				.Property(e => e.NomeUsuario)
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

			modelBuilder.Entity<Usuario>()
				.HasMany(e => e.Pergunta)
				.WithRequired(e => e.Usuario)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Usuario>()
				.HasMany(e => e.Resposta)
				.WithRequired(e => e.Usuario)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Usuario>()
				.HasMany(e => e.UsuarioCredito)
				.WithRequired(e => e.Usuario)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<UsuarioTipo>()
				.Property(e => e.NomeTipo)
				.IsUnicode(false);

			modelBuilder.Entity<Resposta>()
				.Property(e => e.Texto)
				.IsUnicode(false);
		}
	}
}
