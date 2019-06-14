using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoDigital.Repositorio;
using PontoDigital.ViewModels;

namespace PontoDigital.Controllers
{
    public class DashboardController : Controller
    {
        HomeViewModel homeViewModel = new HomeViewModel();
        private const string SESSION_EMAIL = "_EMAIL";
        private const string SESSION_CLIENTE = "_CLIENTE";
        public DepoimentoRepositorio depoimentoRepositorio = new DepoimentoRepositorio();
        public IActionResult Index(){
            var listaAva = depoimentoRepositorio.Listar();
            ViewData["Titulo"] = "Dashboard Administrador";
            ViewData["UserLogado"] = HttpContext.Session.GetString(SESSION_EMAIL);
            ViewData["ListaAva"] = listaAva;

            homeViewModel.Depoimentos = depoimentoRepositorio.Listar();

            return View(homeViewModel);
        }
    }
}