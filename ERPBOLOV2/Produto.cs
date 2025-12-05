namespace ERPBOLOV2
{
    public class Produto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public TipoModelo Modelo  { get; set; }
        public string Cor { get; set; }
        public decimal Altura { get; set; }
        public decimal Topo { get; set; }
        public decimal Base { get; set; }
        public decimal ValorLocacao { get; set; }


    }

    public enum TipoModelo
    {
        Outro = 0,
        Boleira = 1,
        Bolo = 2,
        Topo = 3,
    }
}