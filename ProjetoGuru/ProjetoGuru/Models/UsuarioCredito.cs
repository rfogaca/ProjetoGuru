namespace ProjetoGuru.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsuarioCredito")]
    public partial class UsuarioCredito
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioCreditoID { get; set; }

        public double? Valor { get; set; }

        public int? UsuarioID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Data { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
