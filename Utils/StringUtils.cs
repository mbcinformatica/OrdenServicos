using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjetoTeste.Utils
{
    public static class StringUtils
    {
        public static string FormatPhoneNumber(string phoneNumber)
        {
            phoneNumber = phoneNumber.Trim().Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            if (phoneNumber.Length == 10)
            {
                return string.Format("({0}) {1}-{2}", phoneNumber.Substring(0, 2), phoneNumber.Substring(2, 4), phoneNumber.Substring(6, 4));
            }
            else if (phoneNumber.Length == 11)
            {
                return string.Format("({0}) {1}-{2}", phoneNumber.Substring(0, 2), phoneNumber.Substring(2, 5), phoneNumber.Substring(7, 4));
            }
            return phoneNumber; // Retorna o número sem formatação se não for de 10 ou 11 dígitos
        }

        public static string FormatCNPJ(string CNPJ)
        {
            try
            {
                return Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00");
            }
            catch
            {
                return "";
            }
        }

        public static string FormatCPF(string CPF)
        {
            try
            {
                return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
            }
            catch
            {
                return "";
            }
        }

        public static string FormatCEP(string cep)
        {
            try
            {
                return Convert.ToUInt64(cep).ToString(@"00000\-000");
            }
            catch
            {
                return "";
            }
        }

        public static async Task<string> BuscarCEP(string cep)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://viacep.com.br/ws/{cep}/json/";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return json;
                }
                else
                {
                    return null;
                }
            }
        }

        public static string SemFormatacao(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
            {
                return string.Empty;
            }

            return codigo.Replace(".", string.Empty)
                         .Replace("-", string.Empty)
                         .Replace("/", string.Empty)
                         .Replace(")", string.Empty)
                         .Replace("(", string.Empty)
                         .Replace("R", string.Empty)
                         .Replace("$", string.Empty)
                         .Replace(" ", string.Empty);
        }

        public static string FormatValorMoeda(string valor)
        {
            if (decimal.TryParse(valor, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal result))
            {
                return result.ToString("C2", new CultureInfo("pt-BR"));
            }
            return valor;
        }

        public static string FormatValorUnidade(string valor)
        {
            if (decimal.TryParse(valor, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal result))
            {
                return result.ToString("N4", new CultureInfo("pt-BR"));
            }
            return valor;
        }
    }
}
