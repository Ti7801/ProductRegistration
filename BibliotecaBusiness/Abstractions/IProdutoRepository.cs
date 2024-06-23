using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Abstractions
{
    public interface IProdutoRepository
    {
        public void AtualizarProduto(Produto produto);
        public void CadastrarProduto(Produto produto);
        public void ExcluirProduto(int id);
        public List<Produto> ListarProduto();
        public Produto? ObterPorId(int id);
    }
}
