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
        SobrenomeRepositorio sobrenomesRepositorio = new SobrenomeRepositorio();
        EmailRepositorio emailsRepositorio = new EmailRepositorio();
        DepoimentoRepositorio depoimentosRepositorio = new DepoimentoRepositorio();
        HomeViewModel homeViewModel = new HomeViewModel();
            [HttpGet]
        public IActionResult Index()
        {
            ViewData["User"] = HttpContext.Session.GetString(SESSION_EMAIL);
            ViewData["NomeView"] = "Home";

            var listaDeSobrenome = sobrenomesRepositorio.ListarSobrenomes();
            var listaDeEmails = emailsRepositorio.ListarEmails();

            homeViewModel.Sobrenomes = listaDeSobrenome;
            homeViewModel.Emails = listaDeEmails ;

            return View(homeViewModel);
        }
        [HttpPost]
        public IActionResult RegistrarDepoimentos(IFormCollection form){
            DepoimentoModel depoimentos = new DepoimentoModel();
            depoimentos.Nome = form["nome"];
            depoimentos.Email = form["email"];
            depoimentos.Sobrenome = form["sobrenome"];
            depoimentos.Mensagem = form["mensagem"];

            depoimentosRepositorio.RegistrarNoCSV(depoimentos);

            return RedirectToAction("Index","Home");
        }

        public IActionResult ListarRegistros(){
            homeViewModel.Emails = emailsRepositorio.ListarEmails();
            homeViewModel.Depoimentos = depoimentosRepositorio.Listar();

            return View(homeViewModel);
        } 

        public IActionResult BuscarRegistros(IFormCollection form){
            string email = form["email"];
            string dataForm = form["data"];
            DateTime data;

            if(string.IsNullOrEmpty(email) && string.IsNullOrEmpty(dataForm)){
                return RedirectToAction("ListarDepoimentos");
            }else if(string.IsNullOrEmpty(email)){
                data = DateTime.Parse(dataForm);
                homeViewModel.Depoimentos = depoimentosRepositorio.Filtrar(data);
            }else if(string.IsNullOrEmpty(dataForm)){
                homeViewModel.Depoimentos = depoimentosRepositorio.Filtrar(email);
            }else{
                data = DateTime.Parse(dataForm);
                homeViewModel.Depoimentos = depoimentosRepositorio.Filtrar(data, email);
            }
            
            homeViewModel.Emails = emailsRepositorio.ListarEmails();
            
            return View(homeViewModel);
        }
    }
}
