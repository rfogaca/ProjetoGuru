using GuruDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GuruADO
{
	public class RespostaADO : BaseADO
	{
		public RespostaADO() : base() { }

        public List<Resposta> ConsultarRespostas(int PerguntaID)
        {
            return db.Resposta.Include(pergunta => pergunta.Pergunta).Where(resposta => resposta.PerguntaID == PerguntaID).OrderBy(data => data.Data).ToList();
        }
        public Boolean CriarResposta(Resposta resposta)
        {
            try
            {
                db.Resposta.Add(resposta);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean UpdateResposta(Resposta resposta)
        {
            try
            {
                Resposta updating = db.Resposta.Find(resposta.RespostaID);
                updating.Texto = resposta.Texto;
                updating.Avaliacao = resposta.Avaliacao;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean DeleteResposta(int id)
        {
            try
            {
                db.Resposta.Remove(db.Resposta.Find(id));
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