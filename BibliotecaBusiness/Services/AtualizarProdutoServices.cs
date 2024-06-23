using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;


namespace BibliotecaBusiness.Services
{
    public class AtualizarProdutoServices
    {

        private readonly IProdutoRepository produtoRepository;

        public AtualizarProdutoServices(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository; 
        }

        public ServiceResult AtualizarProduto(Produto produto)
        {
            var produtoAtualizado = produtoRepository.ObterPorId(produto.Id);

            if(produtoAtualizado == null)
            {
                return new ServiceResult(false, "O produto não foi encontrado");
            }

            produtoAtualizado.Nome = produto.Nome;
            produtoAtualizado.Descricao = produto.Descricao;
            produtoAtualizado.ValorProduto = produto.ValorProduto;
            produtoAtualizado.DisponivelVenda = produto.DisponivelVenda;

            produtoRepository.AtualizarProduto(produtoAtualizado);

            return new ServiceResult(true, "Produto Atualizado!");                                
        }
    }
}
