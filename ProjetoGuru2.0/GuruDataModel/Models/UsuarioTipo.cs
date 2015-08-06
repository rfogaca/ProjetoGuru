namespace GuruDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsuarioTipo")]
    public partial class UsuarioTipo
    {
        public int UsuarioTipoID { get; set; }

        [StringLength(30)]
        public string NomeTipo { get; set; }
    }
}
