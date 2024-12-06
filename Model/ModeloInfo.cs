namespace ProjetoTeste.Model
{
    public class ModeloInfo
    {
        public int IDModelo { get; set; }
        public int IDMarca { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; internal set; }

    }
}