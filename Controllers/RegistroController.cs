using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoDigital.Models;
using PontoDigital.Repositorio;
using PontoDigital.ViewModels;

namespace PontoDigital.Controllers
{
    public class RegistroController : Controller
    {
        private const string SESSION_EMAIL = "_EMAIL";
        private const string SESSION_CLIENTE = "CLIENTE";
        private ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
        private RegistroRepositorio Repositorio = new RegistroRepositorio();
        private PlanosRepositorio planosRepositorio = new PlanosRepositorio();
        [HttpGet]
        public IActionResult Index(){
            var cliente = clienteRepositorio.ObterPor(HttpContext.Session.GetString(SESSION_EMAIL));

            RegistroViewModel registro = new RegistroViewModel();
            registro.Cliente = cliente == null ? new ClienteModel() : cliente;
            
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarCliente(IFormCollection form){
            System.Console.WriteLine(form["nome"]);
            System.Console.WriteLine(form["email"]);
            System.Console.WriteLine(form["data-nascimento"]);
            System.Console.WriteLine(form["senha"]);
            System.Console.WriteLine(form["confirmar-senha"]);

            RegistroModel registro = new RegistroModel();

            ClienteModel cliente = new ClienteModel();
            cliente.Nome = form["nome"];
            cliente.Email = form["email"];

            registro.Cliente = cliente;

            ViewData["NomeView"] = "Registro";

            Repositorio.Inserir(registro);

            return View("Sucesso");
        }
    }
}