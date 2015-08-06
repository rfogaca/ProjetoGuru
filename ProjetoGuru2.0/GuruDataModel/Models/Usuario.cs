namespace GuruDataModel
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
            Resposta = new HashSet<Resposta>();
            UsuarioCredito = new HashSet<UsuarioCredito>();
            Categoria = new HashSet<Categoria>();
        }

        public int UsuarioID { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(200)]
        public string NomeUsuario { get; set; }

        [StringLength(50)]
        public string Imagem { get; set; }

        [StringLength(100)]
        public string Senha { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }

        [StringLength(200)]
        public string PaypalToken { get; set; }

        public int? UsuarioTipoID { get; set; }

        public virtual ICollection<Pergunta> Pergunta { get; set; }

        public virtual ICollection<Resposta> Resposta { get; set; }

        public virtual ICollection<UsuarioCredito> UsuarioCredito { get; set; }

        public virtual ICollection<Categoria> Categoria { get; set; }
    }
}
