using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoDigital.Models;
using PontoDigital.Repositorio;
using PontoDigital.ViewModels;

namespace PontoDigital.Controllers
{
    public class HomeController : Controller
    {
        private const string SESSION_EMAIL = "_EMAIL";
        private const string SESSION_CLIENTE = "_CLIENTE";
        ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
        DepoimentoRepositorio depoimentosRepositorio = new DepoimentoRepositorio();
        HomeViewModel homeViewModel = new HomeViewModel();
            [HttpGet]
        public IActionResult Index()
        {
            ViewData["User"] = HttpContext.Session.GetString(SESSION_EMAIL);
            ViewData["NomeView"] = "Home";

            return View(homeViewModel);
        }
        [HttpPost]
        public IActionResult RegistrarDepoimentos(IFormCollection form){
            DepoimentoModel depoimentos = new DepoimentoModel();
            depoimentos.Nome = form["nome"];
            depoimentos.Sobrenome = form["sobrenome"];
            depoimentos.Email = form["email"];
            depoimentos.Mensagem = form["mensagem"];
            depoimentos.DataEntrada = DateTime.Now;

            depoimentosRepositorio.RegistrarNoCSV(depoimentos);

            return RedirectToAction("Index","Home");
        }

        public IActionResult ListarDepoimentos(){
            homeViewModel.Cliente = clienteRepositorio.ListarTodos();
            homeViewModel.Depoimentos = depoimentosRepositorio.Listar();
            return View(homeViewModel);
        } 

        public IActionResult BuscarDepoimentos(IFormCollection form){
            string dataForm = form["data"];
            DateTime data;
            if ( string.IsNullOrEmpty(dataForm))
            {
                return RedirectToAction("ListarDepoimentos");
            }else if(string.IsNullOrEmpty(dataForm)){
               data = DateTime.Parse(dataForm);
               homeViewModel.Depoimentos = depoimentosRepositorio.Filtrar(data);
            }
            homeViewModel.Depoimentos = depoimentosRepositorio.Listar();

            return View(homeViewModel);
        }
    }
}
