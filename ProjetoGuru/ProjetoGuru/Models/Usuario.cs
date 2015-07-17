namespace ProjetoGuru.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        public Usuario()
        {
            Pergunta = new HashSet<Pergunta>();
            UsuarioCredito = new HashSet<UsuarioCredito>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioID { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Imagem { get; set; }

        [StringLength(100)]
        public string Senha { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }

        [StringLength(200)]
        public string PaypalToken { get; set; }

        public int? TipoID { get; set; }

        public virtual ICollection<Pergunta> Pergunta { get; set; }

        public virtual ICollection<UsuarioCredito> UsuarioCredito { get; set; }
    }
}
