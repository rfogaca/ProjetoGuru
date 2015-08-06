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
		public List<Pergunta> ListarPerguntas(int usuarioID, string status = "D")
		{
			return db.Pergunta.Include(x => x.Resposta).ToList();
		}
		public List<Pergunta> ConsiltaPerguntasUsuario (int usuarioID, string status = "D")
		{
			return db.Pergunta.Where(pergunta => pergunta.PerguntaID == usuarioID && status == "D").OrderBy(x => x.Data).ToList();
		}
    }
}
