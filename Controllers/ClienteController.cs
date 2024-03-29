using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoDigital.Models;
using PontoDigital.Repositorio;

namespace PontoDigital.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
        private const string SESSION_EMAIL = "_EMAIL";
        private const string SESSION_CLIENTE = "_CLIENTE";
        [HttpGet]
        public IActionResult Login(){
            return View();
        }
        [HttpPost]
        public IActionResult Login(IFormCollection form){
            var email = form["email"];
            var senha = form["senha"];
            List<ClienteModel> listaClientes = clienteRepositorio.ListarTodos();

            foreach (var item in listaClientes)
            {

                // if(item == null){
                //    System.Console.WriteLine("ta nulo CARAMBA");
                // }

                if (email.Equals(item.Email) && senha.Equals(item.Senha))
                {
                    //Criar Sessions                    
                    HttpContext.Session.SetString(SESSION_EMAIL, item.Email);
                    HttpContext.Session.SetString(SESSION_CLIENTE, item.Nome);

                    if (email.Equals("admin@agoravai.com") && senha.Equals("admin"))
                    {
                        return RedirectToAction("Index","Dashboard");
                    }
                    
                    return RedirectToAction("Index","Home");
                }
                
            }
            ViewData["ErroData"] = "ErroLogin";
            return View("Index");
        }

        public IActionResult Logout(){
            HttpContext.Session.Remove(SESSION_EMAIL);
            HttpContext.Session.Remove(SESSION_CLIENTE);
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}