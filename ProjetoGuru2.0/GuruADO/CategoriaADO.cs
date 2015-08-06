using GuruDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuruADO
{
	public class CategoriaADO : BaseADO
	{
		public CategoriaADO() : base () {}
		public List<Categoria> ListarCategorias ()
		{
			return db.Categoria.ToList();
		}
		public Categoria ConsultarCategorias (int id)
		{
			return db.Categoria.Where(categoria => categoria.CategoriaID == id).FirstOrDefault();
		}
		//pai de cat
		public Boolean CreateCategoria(Categoria categoria)
		{
			try
			{
				db.Categoria.Add(categoria);
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
		public Boolean UpdateCategoria(Categoria categoria)
		{
			try
			{
				Categoria updating = db.Categoria.Find(categoria.CategoriaID);
				updating.CategoriaID = categoria.CategoriaID;
				updating.CategoriaParent = categoria.CategoriaParent;
				updating.NomeCategoria = categoria.NomeCategoria;
				db.SaveChanges(); 
				return true;
			}
			catch
			{
				return false;
			}
		}
		public Boolean DeleteCategoria(int id)
		{
			try
			{
				db.Categoria.Remove(db.Categoria.Find(id));
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
