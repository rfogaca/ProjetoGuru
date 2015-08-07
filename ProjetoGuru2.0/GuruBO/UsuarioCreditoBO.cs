using GuruADO;
using GuruDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuruBO
{
	public class UsuarioCreditoBO
	{
		UsuarioCreditoADO ado;
		public UsuarioCreditoBO ()
		{
			//Instancia a ADO de UsuarioCredito para acesso ao banco de dados
			ado = new UsuarioCreditoADO();
		}
		//Lista TODAS os creditos de todos os usuarios
		public List<UsuarioCredito> ListarUsuarioCreditos()
		{
			return ado.ListarUsuarioCreditos();
		}
		//Retorna TODOS os creditos de UM usuario a partir do seu ID
		public List<UsuarioCredito> ConsultarUsuarioCreditos(int id)
		{
			return ado.ConsultarUsuarioCreditos(id);
		}
		public Boolean CreateUsuarioCredito(UsuarioCredito UsuarioCredito)
		{
			return ado.CreateUsuarioCredito(UsuarioCredito);
		}
		public Boolean UpdateUsuarioCredito(UsuarioCredito UsuarioCredito)
		{
			return ado.UpdateUsuarioCredito(UsuarioCredito);
		}
		public Boolean DeleteUsuarioCredito(int id)
		{
			return ado.DeleteUsuarioCredito(id);
		}
	}
}
