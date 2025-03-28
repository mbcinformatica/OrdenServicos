using System.Dynamic;
using System.Net;

namespace OrdenServicos.Model
{
    public class PesquisaWebInfo
    {
        public class CnpjInfo
        {
            public string Cpf_Cnpj { get; set; }
            public string Nome_RazaoSocial { get; set; }
            public string Endereco { get; set; }
            public string Numero { get; set; }
            public string Bairro { get; set; }
            public string Municipio { get; set; }
            public string UF { get; set; }
            public string Cep { get; set; }
            public string Contato { get; set; }
            public string Fone_1 { get; set; }
            public string Fone_2 { get; set; }
            public string Email { get; set; }
            public string DataCadastro { get; set; }
        }

        public class CpfInfo
        {
            public string Cpf_Cnpj { get; set; }
            public string Nome_RazaoSocial { get; set; }
            public string DataCadastro { get; set; }
            public string Endereco { get; set; }
            public string Bairro { get; set; }
            public string Municipio { get; set; }
            public string UF { get; set; }
            public string Cep { get; set; }
            public string Contato { get; set; }
            public string Email { get; set; }
        }
    
        public class GenericoResponse<T> where T : class
        {

            public HttpStatusCode CodHttp { get; set; }
            public T DadosRetorno { get; set; }
            public ExpandoObject ErroRetorno { get; set; }

        }

    }
}

