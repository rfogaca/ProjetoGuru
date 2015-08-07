using GuruADO;
using GuruDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GuruBO
{
	public class RespostaBO
	{
        RespostaADO ado;
		public RespostaBO()
		{
			//Instancia a ADO de resposta para acesso ao banco de dados
			ado = new RespostaADO();
		}

		//Lista TODAS as respostas de UMA pergunta pelo seu ID 
		public List<Resposta> ConsultarRespostas(int id)
		{
			return ado.ConsultarRespostas(id);
		}
		public Boolean CreateResposta(Resposta resposta)
		{
			return ado.CreateResposta(resposta);
		}
		public Boolean UpdateResposta(Resposta resposta)
		{
			return ado.UpdateResposta(resposta);
		}
		public Boolean DeleteResposta(int id)
		{
			return ado.DeleteResposta(id);
		}
	}
}
