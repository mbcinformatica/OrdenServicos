using ProjetoTeste.DAL;

namespace ProjetoTeste.BLL
{
    public class DBSetupBLL
    {
        public bool CheckAndSetupDatabase()
        {
            DBSetupDAL dbsetupDAL = new DBSetupDAL();
            return dbsetupDAL.CheckAndSetupDatabase();
        }
        public bool VerificarSeCadastrado(object valor, string tabela, string coluna)
        {
            DBSetupDAL dbsetupDAL = new DBSetupDAL();
            return dbsetupDAL.VerificarSeCadastrado(valor, tabela, coluna);
        }
    }
}
