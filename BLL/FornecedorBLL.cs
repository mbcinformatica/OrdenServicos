using ProjetoTeste.DAL;
using ProjetoTeste.Model;
using System.Collections.Generic;

namespace ProjetoTeste.BLL
{
    public class FornecedorBLL
    {
        public List<FornecedorInfo> Listar()
        {
            FornecedorDAL fornecedorDAL = new FornecedorDAL();
            return fornecedorDAL.Listar();
        }
        public FornecedorInfo GetFornecedor(int IDFornecedor)
        {
            FornecedorDAL fornecedorDAL = new FornecedorDAL();
            return fornecedorDAL.GetFornecedor(IDFornecedor);
        }
        public void AtualizarFornecedor(FornecedorInfo Fornecedor)
        {
            FornecedorDAL fornecedorDAL = new FornecedorDAL();
            fornecedorDAL.AtualizarFornecedor(Fornecedor);
        }
        public void InserirFornecedor(FornecedorInfo Fornecedor)
        {
            FornecedorDAL fornecedorDAL = new FornecedorDAL();
            fornecedorDAL.InserirFornecedor(Fornecedor);
        }
        public void ExcluirFornecedor(int IdFornecedor)
        {
            FornecedorDAL fornecedorDAL = new FornecedorDAL();
            fornecedorDAL.ExcluirFornecedor(IdFornecedor);
        }
    }
}
