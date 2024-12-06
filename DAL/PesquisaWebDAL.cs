using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static ProjetoTeste.Model.PesquisaWebInfo;


namespace ProjetoTeste.DAL
{
    public class PesquisaWebDAL
    {

        public class ReceitaFederalApi
        {
            private static readonly HttpClient client = new HttpClient();

            public static async Task<CnpjInfo> PesquisarCnpjAsync(string cnpj)
            {
                string url = $"https://www.receitaws.com.br/v1/cnpj/{cnpj}";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseBody);

                    CnpjInfo info = new CnpjInfo
                    {
                        Cpf_Cnpj = json["cnpj"].ToString(),
                        Nome_RazaoSocial = json["nome"].ToString(),
                        //         Nome_Fantasia = json["fantasia"].ToString(),
                        Endereco = json["logradouro"].ToString(),
                        Numero = json["numero"].ToString(),
                        Bairro = json["bairro"].ToString(),
                        Municipio = json["municipio"].ToString(),
                        UF = json["uf"].ToString(),
                        Cep = json["cep"].ToString(),
                        Contato = json["telefone"].ToString(),
                        Fone_1 = json["telefone"].ToString(),
                        Fone_2 = json["telefone"].ToString(), // Supondo que o telefone pode ser repetido aqui
                        Email = json["email"].ToString(),
                        DataCadastro = json["ultima_atualizacao"].ToString(),
                        //       Nat_Juridica = json["natureza_juridica"].ToString()
                    };

                    return info;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Erro ao pesquisar CNPJ: {e.Message}");
                    return null;
                }
            }
        }
    }
}
