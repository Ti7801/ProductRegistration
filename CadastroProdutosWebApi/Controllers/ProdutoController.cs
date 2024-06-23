using BibliotecaBusiness.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaBusiness.Services;



namespace CadastroProdutosWebApi.Controllers
{
    [ApiController]
    [Route("produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly CadastrarProdutoServices cadastrarProdutoServices;
        private readonly AtualizarProdutoServices atualizarProdutoServices; 
        private readonly ListarProdutoServices listarProdutoServices;
        private readonly ExcluirProdutoServices excluirProdutoServices;

        public ProdutoController(CadastrarProdutoServices cadastrarProdutoServices, AtualizarProdutoServices atualizarProdutoServices, ListarProdutoServices listarProdutoServices, ExcluirProdutoServices excluirProdutoServices)
        {
            this.cadastrarProdutoServices = cadastrarProdutoServices;
            this.atualizarProdutoServices = atualizarProdutoServices;
            this.listarProdutoServices = listarProdutoServices;
            this.excluirProdutoServices = excluirProdutoServices;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Produto> CadastrarProduto(Produto produto)
        {
            
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(error => error.ErrorMessage);

                return BadRequest(errors);
            }
            cadastrarProdutoServices.CadastrarProduto(produto);
           
            return CreatedAtAction(nameof(CadastrarProduto), produto);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        public ActionResult<List<Produto>> ObterProdutos()
        {             
            var lista = listarProdutoServices.ListarProduto();

            return Ok(lista);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Produto),StatusCodes.Status200OK)]
        public ActionResult<Produto> AtualizarProdutos(Produto produto)
        {           
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(error => error.ErrorMessage);

                return BadRequest(errors);
            }

            ServiceResult operationResult = atualizarProdutoServices.AtualizarProduto(produto);

            if (operationResult.Success)
            {
                return Ok(produto);
            }
            else
            {
                return BadRequest(operationResult.ErrorMessage);
            }          
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult ExcluirProduto(int id)
        {
            ServiceResult operationResult = excluirProdutoServices.ExcluirProduto(id);

            if (operationResult.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(operationResult.ErrorMessage);
            }
        }
    }
}
