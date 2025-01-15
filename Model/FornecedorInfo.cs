using System;

namespace OrdenServicos.Model
{
    public class FornecedorInfo
    {
        public int IDFornecedor { get; set; }
        public string TipoPessoa { get; set; }
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
        public DateTime DataCadastro { get; set; }
    }
}
