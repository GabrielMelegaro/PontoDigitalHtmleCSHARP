using System;

namespace PontoDigital.Models
{
    public class RegistroModel
    {
        public ulong Id {get;set;}
        public ClienteModel Cliente {get;set;}
        public SobrenomeModel sobrenome {get;set;}
        public EmailModel email {get;set;}
        public DateTime DataNascimento {get;set;}
        public double PrecoTotal {get;set;}
        public PlanoModel Plano {get;set;}
    }
}