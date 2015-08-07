using GuruDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuruADO
{
	public class UsuarioCreditoADO : BaseADO
	{
		public UsuarioCreditoADO() : base() { }
		//Lista todos os creditos TODOS
		public List<UsuarioCredito> ListarUsuarioCreditos ()
		{
			return db.UsuarioCredito.ToList();
		}
		//Lista todos os creditos de um usuário
		public List<UsuarioCredito> ConsultarUsuarioCreditos(int id)
		{
			return db.UsuarioCredito.Where(credito => credito.UsuarioID == id).OrderBy(credito => credito.Data).ToList();
		}
		public Boolean CreateUsuarioCredito(UsuarioCredito credito)
		{
			try
			{
				db.UsuarioCredito.Add(credito);
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
		public Boolean UpdateUsuarioCredito(UsuarioCredito credito)
		{
			try
			{
				UsuarioCredito updating = db.UsuarioCredito.Find(credito.UsuarioCreditoID);
				updating.UsuarioCreditoID = credito.UsuarioCreditoID;
				updating.UsuarioID = credito.UsuarioID;
				updating.Usuario = credito.Usuario;
				updating.Data = credito.Data;
				updating.Valor = credito.Valor;
				db.SaveChanges(); 
				return true;
			}
			catch
			{
				return false;
			}
		}
		public Boolean DeleteUsuarioCredito(int id)
		{
			try
			{
				db.UsuarioCredito.Remove(db.UsuarioCredito.Find(id));
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
