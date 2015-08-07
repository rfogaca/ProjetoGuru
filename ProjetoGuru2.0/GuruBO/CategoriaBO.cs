using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuruADO;
using GuruDataModel;

namespace GuruBO
{
	public class CategoriaBO
	{
		CategoriaADO ado;
		public CategoriaBO ()
		{
			//Instancia a ADO de categoria para acesso ao banco de dados
			ado = new CategoriaADO();
		}
		//Lista TODAS as categorias
		public List<Categoria> ListarCategorias()
		{
			return ado.ListarCategorias();
		}
		//Retorna UMA categoria a partir do seu ID
		public Categoria ConsultarCategorias(int id)
		{
			return ado.ConsultarCategorias(id);
		}
		public Boolean CreateCategoria(Categoria categoria)
		{
			return ado.CreateCategoria(categoria);
		}
		public Boolean UpdateCategoria(Categoria categoria)
		{
			return ado.UpdateCategoria(categoria);
		}
		public Boolean DeleteCategoria(int id)
		{
			return ado.DeleteCategoria(id);
		}
	}
}
