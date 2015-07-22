namespace ProjetoGuru.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pergunta")]
    public partial class Pergunta
    {
        public Pergunta()
        {
            Resposta = new HashSet<Resposta>();
        }

        public int PerguntaID { get; set; }

        public int? UsuarioID { get; set; }

        public int? CategoriaID { get; set; }

        [StringLength(50)]
        public string Imagem { get; set; }

        [StringLength(300)]
        public string Texto { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Data { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Resposta> Resposta { get; set; }
    }
}
