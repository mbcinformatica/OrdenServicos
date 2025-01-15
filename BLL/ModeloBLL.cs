using OrdenServicos.DAL;
using OrdenServicos.Model;
using System.Collections.Generic;

namespace OrdenServicos.BLL
{
    public class ModeloBLL
    {
        public List<ModeloInfo> Listar()
        {
            ModeloDAL modeloDAL = new ModeloDAL();
            return modeloDAL.Listar();
        }
        public List<ModeloInfo> ListarPorMarca(int idMarca)
        {
            ModeloDAL modeloDAL = new ModeloDAL();
            return modeloDAL.ListarPorMarca(idMarca);
        }
        public ModeloInfo GetModelo(int IDModelo)
        {
            ModeloDAL modeloDAL = new ModeloDAL();
            return modeloDAL.GetModelo(IDModelo);
        }
        public void AtualizarModelo(ModeloInfo Modelo)
        {
            ModeloDAL modeloDAL = new ModeloDAL();
            modeloDAL.AtualizarModelo(Modelo);
        }
        public void InserirModelo(ModeloInfo Modelo)
        {
            ModeloDAL modeloDAL = new ModeloDAL();
            modeloDAL.InserirModelo(Modelo);
        }
        public void ExcluirModelo(int IdModelo)
        {
            ModeloDAL modeloDAL = new ModeloDAL();
            modeloDAL.ExcluirModelo(IdModelo);
        }
    }
}