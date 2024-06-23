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
            var list = from e in appDbContext.Produtos
                       from i in appDbContext.Produtos
                       orderby e.ValorProduto ascending
                       select new { i.Nome, e.ValorProduto };

            return (List<Produto>)list;
        }

        public void AtualizarProduto(Produto produto)
        {
            appDbContext.Produtos.Update(produto);
            appDbContext.SaveChanges();
        }

        public void ExcluirProduto(int id)
        {
            appDbContext.Produtos.Remove(new Produto { Id = id });
            appDbContext.SaveChanges();
        }

        public Produto? ObterPorId(int id)
        {
            Produto? produto = appDbContext.Produtos.Where(u => u.Id == id).SingleOrDefault();

            return produto;
        }
    }
}
