using BibliotecaBusiness.Models;
using Microsoft.AspNetCore.Mvc;
using BibliotecaBusiness.Services;

namespace CadastroProdutosWebApi.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly CadastrarProdutoServices cadastrarProdutoServices;
        private readonly AtualizarProdutoServices atualizarProdutoServices;
        private readonly ListarProdutoServices listarProdutoServices;
        private readonly ExcluirProdutoServices excluirProdutoServices;

        public ProdutoController(CadastrarProdutoServices cadastrarProdutoServices,
            AtualizarProdutoServices atualizarProdutoServices,
            ListarProdutoServices listarProdutoServices,
            ExcluirProdutoServices excluirProdutoServices)
        {
            this.cadastrarProdutoServices = cadastrarProdutoServices;
            this.atualizarProdutoServices = atualizarProdutoServices;
            this.listarProdutoServices = listarProdutoServices;
            this.excluirProdutoServices = excluirProdutoServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var lista = listarProdutoServices.ListarProduto();
            return View(lista);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                cadastrarProdutoServices.CadastrarProduto(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var produto = listarProdutoServices.ListarProduto().FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Produto produto)
        {
            if (ModelState.IsValid)
            {
                var result = atualizarProdutoServices.AtualizarProduto(produto);
                if (result.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessage);
            }
            return View(produto);
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var produto = listarProdutoServices.ListarProduto().FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = excluirProdutoServices.ExcluirProduto(id);
            if (result.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", result.ErrorMessage);
            var produto = listarProdutoServices.ListarProduto().FirstOrDefault(p => p.Id == id);
            return View("Delete", produto);
        }
    }
}
