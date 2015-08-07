using GuruDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuruADO
{
	public class UsuarioTipoADO : BaseADO
	{
		public UsuarioTipoADO() : base() { }
		//Lista todos os tipos de usuario
		public List<UsuarioTipo> ListarUsuarioTipos()
		{
			return db.UsuarioTipo.ToList();
		}
		public UsuarioTipo ConsultarUsuarioTipo(int id)
		{
			return db.UsuarioTipo.Where(tipo => tipo.UsuarioTipoID == id).FirstOrDefault();
		}
		public Boolean CreateUsuarioTipo(UsuarioTipo tipo)
		{
			try
			{
				db.UsuarioTipo.Add(tipo);
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
		public Boolean UpdateUsuarioTipo(UsuarioTipo tipo)
		{
			try
			{
				UsuarioTipo updating = db.UsuarioTipo.Find(tipo.UsuarioTipoID);
				updating.UsuarioTipoID = tipo.UsuarioTipoID;
				updating.NomeTipo = tipo.NomeTipo;
				db.SaveChanges(); 
				return true;
			}
			catch
			{
				return false;
			}
		}
		public Boolean DeleteUsuarioTipo(int id)
		{
			try
			{
				db.UsuarioTipo.Remove(db.UsuarioTipo.Find(id));
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
