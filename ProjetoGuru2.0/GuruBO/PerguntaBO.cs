using GuruADO;
using GuruDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuruBO
{
    public class PerguntaBO
    {
		PerguntaADO ado;
		public PerguntaBO()
		{
			//Instancia a ADO de pergunta para acesso ao banco de dados
			ado = new PerguntaADO();
		}
		//Lista TODAS as perguntas inclusive as deletadas
		public List<Pergunta> ListarPerguntas()
		{
			return ado.ListarPerguntas();
		}
		//Lista TODAS as perguntas de UM usuário pelo seu ID 
		public List<Pergunta> ConsultarPerguntas(int id)
		{
			return ado.ConsultaPerguntasUsuario(id);
		}
		public Boolean CreatePergunta(Pergunta Pergunta)
		{
			return ado.CreatePergunta(Pergunta);
		}
		public Boolean UpdatePergunta(Pergunta Pergunta)
		{
			return ado.UpdatePergunta(Pergunta);
		}
		public Boolean DeletePergunta(int id)
		{
			return ado.DeletePergunta(id);
		}
    }
}
