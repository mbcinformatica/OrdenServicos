using ProjetoTeste.DAL;
using ProjetoTeste.Model;
using System.Collections.Generic;

namespace ProjetoTeste.BLL
{
    public class UsuarioBLL
    {
        public List<UsuarioInfo> Listar()
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.Listar();
        }
        public UsuarioInfo GetUsuario(int IDUsuario)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.GetUsuario(IDUsuario);
        }
        public void AtualizarUsuario(UsuarioInfo Usuario)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.AtualizarUsuario(Usuario);
        }
        public void InserirUsuario(UsuarioInfo Usuario)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.InserirUsuario(Usuario);
        }
        public void ExcluirUsuario(int IdUsuario)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.ExcluirUsuario(IdUsuario);
        }
        public bool IsUsuariosEmpty()
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.IsUsuariosEmpty();
        }
    }
}