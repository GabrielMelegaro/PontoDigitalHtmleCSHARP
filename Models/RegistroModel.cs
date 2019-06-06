using System;

namespace PontoDigital.Models
{
    public class RegistroModel
    {
        public ulong Id {get;set;}
        public ClienteModel Cliente {get;set;}
        public DateTime DataNascimento {get;set;}
    }
}