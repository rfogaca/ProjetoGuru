using GuruDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuruADO
{
    public class PerguntaADO
    {
		Context db = new Context();
		public List<Pergunta> ListAll(int usuarioID, string status = "D")
		{
			return db.Pergunta.Where(pergunta => pergunta.PerguntaID == usuarioID && status == "D").OrderBy(x => x.Data).ToList();
		}
    }
}
