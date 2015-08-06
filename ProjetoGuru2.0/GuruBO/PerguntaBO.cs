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
		PerguntaADO ado = new PerguntaADO();
		public List<Pergunta> Listar (int usuarioID)
		{
			return ado.ListAll (usuarioID);

		}
    }
}
