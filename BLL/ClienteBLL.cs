using ProjetoTeste.DAL;
using ProjetoTeste.Model;
using System.Collections.Generic;

namespace ProjetoTeste.BLL
{
    public class ClienteBLL
    {
        public List<ClienteInfo> Listar()
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            return clienteDAL.Listar();
        }
        public ClienteInfo GetCliente(int IDCliente)
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            return clienteDAL.GetCliente(IDCliente);
        }
        public void AtualizarCliente(ClienteInfo Cliente)
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            clienteDAL.AtualizarCliente(Cliente);
        }
        public void InserirCliente(ClienteInfo Cliente)
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            clienteDAL.InserirCliente(Cliente);
        }
        public void ExcluirCliente(int IdCliente)
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            clienteDAL.ExcluirCliente(IdCliente);
        }
    }
}
