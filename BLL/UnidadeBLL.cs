using OrdenServicos.DAL;
using OrdenServicos.Model;
using System.Collections.Generic;

namespace OrdenServicos.BLL
{
    public class UnidadeBLL
    {
        public List<UnidadeInfo> Listar()
        {
            UnidadeDAL unidadeDAL = new UnidadeDAL();
            return unidadeDAL.Listar();
        }
        public UnidadeInfo GetUnidade(int IDUnidade)
        {
            UnidadeDAL unidadeDAL = new UnidadeDAL();
            return unidadeDAL.GetUnidade(IDUnidade);
        }
        public void AtualizarUnidade(UnidadeInfo Unidade)
        {
            UnidadeDAL unidadeDAL = new UnidadeDAL();
            unidadeDAL.AtualizarUnidade(Unidade);
        }
        public void InserirUnidade(UnidadeInfo Unidade)
        {
            UnidadeDAL unidadeDAL = new UnidadeDAL();
            unidadeDAL.InserirUnidade(Unidade);
        }
        public void ExcluirUnidade(int IdUnidade)
        {
            UnidadeDAL unidadeDAL = new UnidadeDAL();
            unidadeDAL.ExcluirUnidade(IdUnidade);
        }
    }
}