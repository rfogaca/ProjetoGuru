namespace ProjetoGuru.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsuarioCategoria")]
    public partial class UsuarioCategoria
    {
        public int UsuarioCategoriaID { get; set; }

        public int? UsuarioID { get; set; }

        public int? CategoriaID { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
