using System;

namespace ProjetoTeste.Model
{
    public class LancamentoServicoInfo
    {
        //Banco de Dados
        public int IDOrdenServico { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataConclucao { get; set; }
        public int IDCliente { get; set; }
        public int IDMarca { get; set; }
        public int IDProduto { get; set; }
        public string NumeroSerie { get; set; }
        public string DescricaoDefeito { get; set; }
        public string GarantiaServico { get; set; }
        public string GarantiaMaterial { get; set; }
        public decimal ValorTotalServico { get; set; }
        public decimal ValorTotalMaterial { get; set; }
        public byte[] Imagem { get; set; }

        //Variaveis
        public string Cliente { get; internal set; }
        public string Marca { get; internal set; }
        public string Produto { get; internal set; }
    }
}
