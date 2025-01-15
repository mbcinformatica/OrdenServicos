using OrdenServicos.DAL;
using OrdenServicos.Model;
using System.Collections.Generic;

namespace OrdenServicos.BLL
{
    public class ProdutoBLL
    {
        public List<ProdutoInfo> Listar()
        {
            ProdutoDAL produtoDAL = new ProdutoDAL();
            return produtoDAL.Listar();
        }
        public List<ProdutoInfo> ListarPorMarca(int idMarca)
        {
            ProdutoDAL produtoDAL = new ProdutoDAL();
            return produtoDAL.ListarPorMarca(idMarca);
        }
        public ProdutoInfo GetProduto(int IDProduto)
        {
            ProdutoDAL produtoDAL = new ProdutoDAL();
            return produtoDAL.GetProduto(IDProduto);
        }
        public void AtualizarProduto(ProdutoInfo Produto)
        {
            ProdutoDAL produtoDAL = new ProdutoDAL();
            produtoDAL.AtualizarProduto(Produto);
        }
        public void InserirProduto(ProdutoInfo Produto)
        {
            ProdutoDAL produtoDAL = new ProdutoDAL();
            produtoDAL.InserirProduto(Produto);
        }
        public void ExcluirProduto(int IdProduto)
        {
            ProdutoDAL produtoDAL = new ProdutoDAL();
            produtoDAL.ExcluirProduto(IdProduto);
        }
    }
}
