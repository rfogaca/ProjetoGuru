using GuruDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GuruADO
{
    public class PerguntaADO : BaseADO
	{
		public PerguntaADO() : base() { }
		//Lista todas as perguntas inclusive as deletadas
		public List<Pergunta> ListarPerguntas(int usuarioID)
		{
			return db.Pergunta.Include(x => x.Resposta).ToList();
		}
		//Pesquisa pelas peguntas do susuários não deletadas
		public List<Pergunta> ConsultaPerguntasUsuario (int usuarioID)
		{
			//return db.Pergunta.Where(pergunta => pergunta.PerguntaID == usuarioID && status != "D").OrderBy(x => x.Data).ToList();
		}
		//Pesquisa pelas perguntas do usuário de acordo com o status
    }
}
