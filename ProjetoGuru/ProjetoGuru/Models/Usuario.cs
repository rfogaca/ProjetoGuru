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
            Resposta = new HashSet<Resposta>();
            UsuarioCategoria = new HashSet<UsuarioCategoria>();
            UsuarioCredito = new HashSet<UsuarioCredito>();
        }

        public int UsuarioID { get; set; }

        [Required(ErrorMessage = "O campo 'E-Mail' obrigatório")]
        [StringLength(200)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' obrigatório")]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'Imagem' obrigatório")]
        [StringLength(50)]
        public string Imagem { get; set; }

        [Required(ErrorMessage = "O campo 'Senha' obrigatório")]
        [StringLength(100)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo 'Data de Nascimento' obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }

        [StringLength(200)]
        public string PaypalToken { get; set; }

        [Required(ErrorMessage = "O campo 'Tipo de Usuário' obrigatório")]
        public int? UsuarioTipoID { get; set; }

        public virtual ICollection<Pergunta> Pergunta { get; set; }

        public virtual ICollection<Resposta> Resposta { get; set; }

        public virtual UsuarioTipo UsuarioTipo { get; set; }

        public virtual ICollection<UsuarioCategoria> UsuarioCategoria { get; set; }

        public virtual ICollection<UsuarioCredito> UsuarioCredito { get; set; }
    }
}
