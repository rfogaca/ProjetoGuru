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
		public List<Pergunta> ListarPerguntas()
		{
			return db.Pergunta.Include(pergunta => pergunta.Resposta).ToList();
		}
		//Pesquisa pelas peguntas do usuários não deletadas
		public List<Pergunta> ConsultaPerguntasUsuario (int usuarioID)
		{
			return db.Pergunta.Where(pergunta => pergunta.PerguntaID == usuarioID && pergunta.Status != "D").OrderBy(pergunta => pergunta.Data).ToList();
		}
		//Pesquisa pelas perguntas do usuário de acordo com o status
		public List<Pergunta> ConsultaPerguntasUsuario(int usuarioID, string status)
		{
			return db.Pergunta.Where(pergunta => pergunta.PerguntaID == usuarioID && pergunta.Status == status).OrderBy(pergunta => pergunta.Data).ToList();
		}
		public Boolean CreatePergunta(Pergunta pergunta)
		{
			try
			{
				db.Pergunta.Add(pergunta);
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
		public Boolean UpdatePergunta(Pergunta pergunta)
		{
			try
			{
				Pergunta updating = db.Pergunta.Find(pergunta.PerguntaID);
				
				updating.PerguntaID = pergunta.PerguntaID;
				updating.UsuarioID = pergunta.UsuarioID;
				updating.Usuario = pergunta.Usuario;
				updating.CategoriaID = pergunta.CategoriaID;
				updating.Categoria = pergunta.Categoria;
				updating.Data = pergunta.Data;
				updating.Imagem = pergunta.Imagem;
				updating.Status = pergunta.Status;
				updating.Texto = pergunta.Texto;
				updating.Resposta = pergunta.Resposta;
				return true;
			}
			catch
			{
				return false;
			}
		}
		public Boolean DeletePergunta(int id)
		{
			try
			{
				db.Pergunta.Remove(db.Pergunta.Find(id));
				db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
    }
}
