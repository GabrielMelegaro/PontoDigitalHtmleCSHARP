using System;

namespace PontoDigital.Models
{
    public class ClienteModel
    {
        public ulong Id {get;set;}
        public string Nome {get;set;}
        public string Sobrenome {get;set;}
        public string Email {get;set;}
        public string Senha {get;set;}
        public DateTime DataNascimento {get;set;}
    }
}