using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;

namespace BibliotecaBusiness.Services
{
    public class ExcluirProdutoServices
    {
        private readonly IProdutoRepository produtoRepository;

        public ExcluirProdutoServices(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;   
        }

        public ServiceResult ExcluirProduto(int id)
        {
            var produtoDeletado =  produtoRepository.ObterPorId(id);

            if (produtoDeletado == null)
            {
                return new ServiceResult(false, "O produto não foi encontrado");
            }

            produtoRepository.ExcluirProduto(produtoDeletado);

            return new ServiceResult(true, "O produto foi excluido");

           
        }
    }
}
