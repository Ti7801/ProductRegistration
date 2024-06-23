using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class CadastrarProdutoServices
    {
        private readonly IProdutoRepository produtoRepository;

        public CadastrarProdutoServices(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public void CadastrarProduto(Produto produto)
        {
            produtoRepository.CadastrarProduto(produto);
        }
    }
}
