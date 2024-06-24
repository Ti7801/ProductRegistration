using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class ListarProdutoServices 
    {
        private readonly IProdutoRepository produtoRepository;

        public ListarProdutoServices(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;   
        }

        public List<Produto> ListarProduto() 
        {
           return produtoRepository.ListarProduto();
        }

    }
}
