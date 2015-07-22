namespace ProjetoGuru.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsuarioTipo")]
    public partial class UsuarioTipo
    {
        public UsuarioTipo()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int UsuarioTipoID { get; set; }

        [StringLength(30)]
        public string Tipo { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
