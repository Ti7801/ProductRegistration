namespace BibliotecaBusiness.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;   
        public string Descricao { get; set; } = string.Empty;
        public float ValorProduto { get; set; }
        public bool DisponivelVenda { get; set; }
    }
}
