using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoDigital.Models;
using PontoDigital.Repositorio;

namespace PontoDigital.Controllers
{
    public class CadastroController : Controller
    {
        private ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
        public IActionResult Index(){
            ViewData["NomeView"] = "Cadastro";
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form){
            ClienteModel cliente = new ClienteModel();
            cliente.Nome = form["nome"];
            cliente.Email = form["email"];
            cliente.Senha = form["senha"];
            cliente.DataNascimento = DateTime.Parse(form["data-nascimento"]);

            clienteRepositorio.Inserir(cliente);

            ViewData["Action"] = "Cadastro";
            return View("Sucesso");
        }
    }
}