namespace GuruDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Categoria")]
    public partial class Categoria
    {
        public Categoria()
        {
            Categoria1 = new HashSet<Categoria>();
            Pergunta = new HashSet<Pergunta>();
            Usuario = new HashSet<Usuario>();
        }

        public int CategoriaID { get; set; }

        public int? CategoriaParent { get; set; }

        [StringLength(200)]
        public string NomeCategoria { get; set; }

        public virtual ICollection<Categoria> Categoria1 { get; set; }

        public virtual Categoria Categoria2 { get; set; }

        public virtual ICollection<Pergunta> Pergunta { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
