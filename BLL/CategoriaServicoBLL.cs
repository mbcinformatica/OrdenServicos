using ProjetoTeste.DAL;
using ProjetoTeste.Model;
using System.Collections.Generic;

namespace ProjetoTeste.BLL
{
    public class CategoriaServicoBLL
    {
        public List<CategoriaServicoInfo> Listar()
        {
            CategoriaServicoDAL categoriaServicoDAL = new CategoriaServicoDAL();
            return categoriaServicoDAL.Listar();
        }
        public CategoriaServicoInfo GetCategoriaServico(int IDCategoria)
        {
            CategoriaServicoDAL categoriaServicoDAL = new CategoriaServicoDAL();
            return categoriaServicoDAL.GetCategoriaServico(IDCategoria);
        }
        public void AtualizarCategoriaServico(CategoriaServicoInfo idCategoria)
        {
            CategoriaServicoDAL categoriaServicoDAL = new CategoriaServicoDAL();
            categoriaServicoDAL.AtualizarCategoriaServico(idCategoria);
        }
        public void InserirCategoriaServico(CategoriaServicoInfo idCategoria)
        {
            CategoriaServicoDAL categoriaServicoDAL = new CategoriaServicoDAL();
            categoriaServicoDAL.InserirCategoriaServico(idCategoria);
        }
        public void ExcluirCategoriaServico(int idCategoria)
        {
            CategoriaServicoDAL categoriaServicoDAL = new CategoriaServicoDAL();
            categoriaServicoDAL.ExcluirCategoriaServico(idCategoria);
        }
    }
}
