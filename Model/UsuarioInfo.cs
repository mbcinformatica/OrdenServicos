using System;

namespace ProjetoTeste.Model
{
    public class UsuarioInfo
    {
        public int IDUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public string Cep { get; set; }
        public string Fone_1 { get; set; }
        public string Fone_2 { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public byte[] Imagem { get; set; }

    }
}
