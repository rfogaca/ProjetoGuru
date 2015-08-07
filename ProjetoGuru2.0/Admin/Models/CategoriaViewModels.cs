using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Models
{
	public class CategoriaViewModels
	{
	}
	public class ListarCategoriaViewModel
	{
		public int CategoriaID {get; set;}
		public int CategoriaParentID { get; set; }
		public string NomeCategoria { get; set; }
	}
	public class CreateCategoriaViewModel
	{
		public int CategoriaParent { get; set; }
	}
}