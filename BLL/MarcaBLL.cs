using OrdenServicos.DAL;
using OrdenServicos.Model;
using System.Collections.Generic;

namespace OrdenServicos.BLL
{
    public class MarcaBLL
    {
        public List<MarcaInfo> Listar()
        {
            MarcaDAL marcaDAL = new MarcaDAL();
            return marcaDAL.Listar();
        }
        public MarcaInfo GetMarca(int IDMarca)
        {
            MarcaDAL marcaDAL = new MarcaDAL();
            return marcaDAL.GetMarca(IDMarca);
        }
        public void AtualizarMarca(MarcaInfo Marca)
        {
            MarcaDAL marcaDAL = new MarcaDAL();
            marcaDAL.AtualizarMarca(Marca);
        }
        public void InserirMarca(MarcaInfo Marca)
        {
            MarcaDAL marcaDAL = new MarcaDAL();
            marcaDAL.InserirMarca(Marca);
        }
        public void ExcluirMarca(int IdMarca)
        {
            MarcaDAL marcaDAL = new MarcaDAL();
            marcaDAL.ExcluirMarca(IdMarca);
        }
    }
}
