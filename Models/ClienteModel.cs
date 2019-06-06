using System;

namespace PontoDigital.Models
{
    public class ClienteModel
    {
        public ulong Id {get;set;}
        public string NomeCompleto {get;set;}
        public string Email {get;set;}
        public string Senha {get;set;}
        public DateTime DataNascimento {get;set;}
    }
}