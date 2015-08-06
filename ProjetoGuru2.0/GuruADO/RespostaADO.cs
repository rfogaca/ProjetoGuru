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

        public Resposta ConsultarRespostas(int id)
        {
            //Nesse caso o id representa o identificador da Pergunta
            return db.Resposta.Where(resposta => resposta.PerguntaID == id).FirstOrDefault();
        }
        //pai de cat
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
