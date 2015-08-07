using GuruDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuruADO
{
	public class UsuarioADO : BaseADO
	{
		public UsuarioADO() : base() { }

        public List<Usuario> ListarUsuarios()
        {
            return db.Usuario.ToList();
        }
        public Usuario ConsultarUsuarios(int UsuarioID)
        {
            return db.Usuario.Where(usuario => usuario.UsuarioID == UsuarioID).FirstOrDefault();
        }
        public Boolean CreateUsuario(Usuario usuario)
        {
            try
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean UpdateUsuario(Usuario usuario)
        {
            try
            {
                Usuario updating = db.Usuario.Find(usuario.UsuarioID);
                updating.Email = usuario.Email;
                updating.NomeUsuario = usuario.NomeUsuario;
                updating.Imagem = usuario.Imagem;
                updating.Senha = usuario.Senha;
                updating.DataNascimento = usuario.DataNascimento;
                updating.PaypalToken = usuario.PaypalToken;
                updating.UsuarioTipoID = usuario.UsuarioTipoID;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean DeleteUsuario(int UsuarioID)
        {
            try
            {
                db.Usuario.Remove(db.Usuario.Find(UsuarioID));
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
