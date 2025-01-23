using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendasWebMvc.Data;
using VendasWebMvc.Models;
using VendasWebMvc.Models.ViewModels;
using VendasWebMvc.Services;

namespace VendasWebMvc.Controllers
{
    public class VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService) : Controller
    {
        private readonly VendedorService _vendedorContexto = vendedorService;
        //private readonly VendasWebMvcContext _contexto = contexto;
        private readonly DepartamentoService _departamento = departamentoService;

        public async Task<IActionResult> Index()
        {
            return View(await _vendedorContexto.BuscaTudo());
        }

        public async Task<IActionResult> Adicionar()
        {
            var departamentos = await _departamento.BuscaTudo();
            var viewModel = new CadastrarVendedorViewModel()
            {
                Departamentos = departamentos
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adicionar(CadastrarVendedorViewModel viewer)
        {
            if (!ModelState.IsValid)
            {
                viewer.Departamentos = await _departamento.BuscaTudo();
                View(viewer);
            }
            await _vendedorContexto.Adicionar(viewer.Vendedor);


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detalhes(Vendedor vendedor)
        {
            Vendedor vendedorInterno = await _vendedorContexto.BuscaPorId(vendedor.Id);

            vendedorInterno.Departamento = await _departamento.BuscarPorId(vendedorInterno.DepartamentoId);

            return View(vendedorInterno);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            var vendedor = await _vendedorContexto.BuscaPorId(id.Value);
            List<Departamento> departamentos =  await _departamento.BuscaTudo();
            CadastrarVendedorViewModel view = new CadastrarVendedorViewModel { Departamentos = departamentos, Vendedor = vendedor};

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Vendedor vendedor)
        {
            await _vendedorContexto.Editar(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Excluir(int id)
        {
            var vendedor = await _vendedorContexto.BuscaPorId(id);
            return View(vendedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(Vendedor vendedor)
        {
            await _vendedorContexto.Excluir(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}
