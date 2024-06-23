using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;
using System.Linq;

namespace BibliotecaData.Data
{
    public class ProdutoRespository : IProdutoRepository
    {
        private readonly AppDbContext appDbContext;

        public ProdutoRespository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void CadastrarProduto(Produto produto)
        {
            appDbContext.Produtos.Add(produto);
            appDbContext.SaveChanges();
        }

        public List<Produto> ListarProduto()
        {
            var result = from produto in appDbContext.Produtos
                       orderby produto.ValorProduto ascending
                       select new Produto 
                       {
                           Id = produto.Id,
                           Nome = produto.Nome,
                           ValorProduto = produto.ValorProduto,
                           Descricao = produto.Descricao,
                           DisponivelVenda = produto.DisponivelVenda,
                       };

            return result.ToList();
        }

        public void AtualizarProduto(Produto produto)
        {
            appDbContext.Produtos.Update(produto);
            appDbContext.SaveChanges();
        }

        public void ExcluirProduto(Produto produto)
        {
            appDbContext.Produtos.Remove(produto);
            appDbContext.SaveChanges();
        }

        public Produto? ObterPorId(int id)
        {
            Produto? produto = appDbContext.Produtos.Where(u => u.Id == id).SingleOrDefault();

            return produto;
        }
    }
}
