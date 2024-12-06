using ProjetoTeste.DAL;
using ProjetoTeste.Model;
using System.Collections.Generic;

namespace ProjetoTeste.BLL
{
    public class LancamentoServicoBLL
    {
        public List<LancamentoServicoInfo> Listar()
        {
            LancamentoServicoDAL lancamentoServicoDAL = new LancamentoServicoDAL();
            return lancamentoServicoDAL.Listar();
        }

        public LancamentoServicoInfo GetLancamentoServico(int IDOrdenServico)
        {
            LancamentoServicoDAL lancamentoServicoDAL = new LancamentoServicoDAL();
            return lancamentoServicoDAL.GetLancamentoServico(IDOrdenServico);
        }

        public void AtualizarLancamentoServico(LancamentoServicoInfo lancamentoServico)
        {
            LancamentoServicoDAL lancamentoServicoDAL = new LancamentoServicoDAL();
            lancamentoServicoDAL.AtualizarLancamentoServico(lancamentoServico);
        }

        public void InserirLancamentoServico(LancamentoServicoInfo lancamentoServico)
        {
            LancamentoServicoDAL lancamentoServicoDAL = new LancamentoServicoDAL();
            lancamentoServicoDAL.InserirLancamentoServico(lancamentoServico);
        }

        public void ExcluirLancamentoServico(int idOrdenServico)
        {
            LancamentoServicoDAL lancamentoServicoDAL = new LancamentoServicoDAL();
            lancamentoServicoDAL.ExcluirLancamentoServico(idOrdenServico);
        }
    }
}
