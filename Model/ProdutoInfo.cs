using System;

namespace OrdenServicos.Model
{
    public class ProdutoInfo
    {
        public int IDProduto { get; set; }
        public string IDProdutoInterno { get; set; }
        public string IDProdutoFabricante { get; set; }
        public string Descricao { get; set; }
        public int IDFornecedor { get; set; }
        public int IDMarca { get; set; }
        public int IDModelo { get; set; }
        public int IDUnidade { get; set; }
        public decimal PrecoCompra { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal EstoqueAtual { get; set; }
        public decimal EstoqueMinimo { get; set; }
        public DateTime DataUltimaCompra { get; set; }
        public string Garantia { get; set; }
        public byte[] Imagem { get; set; }
        public string Fornecedor { get; internal set; }
        public string Marca { get; internal set; }
        public string Modelo { get; internal set; }
        public string Unidade { get; internal set; }
    }
}
