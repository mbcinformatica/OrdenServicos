using OrdenServicos.DAL;
using OrdenServicos.Model;
using System.Collections.Generic;

namespace OrdenServicos.BLL
{
    public class ServicoBLL
    {
        public List<ServicoInfo> Listar()
        {
            ServicoDAL servicoDAL = new ServicoDAL();
            return servicoDAL.Listar();
        }
        public ServicoInfo GetServico(int IDServico)
        {
            ServicoDAL servicoDAL = new ServicoDAL();
            return servicoDAL.GetServico(IDServico);
        }
        public void AtualizarServico(ServicoInfo Servico)
        {
            ServicoDAL servicoDAL = new ServicoDAL();
            servicoDAL.AtualizarServico(Servico);
        }
        public void InserirServico(ServicoInfo Servico)
        {
            ServicoDAL servicoDAL = new ServicoDAL();
            servicoDAL.InserirServico(Servico);
        }
        public void ExcluirServico(int IdServico)
        {
            ServicoDAL servicoDAL = new ServicoDAL();
            servicoDAL.ExcluirServico(IdServico);
        }
    }
}
