using GuruDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuruADO
{
	public class BaseADO
	{
		//Cria uma variavel para armazenar o contexto do banco de dados
		//Essa variavel é compartilhada por todas as classes filhas
		internal Context db;
		public BaseADO ()
		{
			//Instancia o contexto para acesso ao banco de dados
			db = new Context();
		}
	}
}
