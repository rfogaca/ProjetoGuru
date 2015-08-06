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
		internal Context db;
		public BaseADO ()
		{
			db = new Context();
		}
	}
}
