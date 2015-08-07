using GuruADO;
using GuruDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuruBO
{
	public class UsuarioTipoBO
	{
		UsuarioTipoADO ado;
		public UsuarioTipoBO ()
		{
			//Instancia a ADO de UsuarioTipo para acesso ao banco de dados
			ado = new UsuarioTipoADO();
		}
		//Lista TODAS os tipos de usuario
		public List<UsuarioTipo> ListarUsuarioTipos()
		{
			return ado.ListarUsuarioTipos();
		}
		//Retorna UM tipo de usuario a partir do seu ID
		public UsuarioTipo ConsultarUsuarioTipo(int id)
		{
			return ado.ConsultarUsuarioTipo(id);
		}
		public Boolean CreateUsuarioTipo(UsuarioTipo UsuarioTipo)
		{
			return ado.CreateUsuarioTipo(UsuarioTipo);
		}
		public Boolean UpdateUsuarioTipo(UsuarioTipo UsuarioTipo)
		{
			return ado.UpdateUsuarioTipo(UsuarioTipo);
		}
		public Boolean DeleteUsuarioTipo(int id)
		{
			return ado.DeleteUsuarioTipo(id);
		}
	}
}
