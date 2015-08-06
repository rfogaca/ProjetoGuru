namespace GuruDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resposta")]
    public partial class Resposta
    {
        [Key]
        [Column(Order = 0)]
        public int RespostaID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PerguntaID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UsuarioID { get; set; }

        [Column(TypeName = "text")]
        public string Texto { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Data { get; set; }

        public bool? Avaliacao { get; set; }

        public virtual Pergunta Pergunta { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
