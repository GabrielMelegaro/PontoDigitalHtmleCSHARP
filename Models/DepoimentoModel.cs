using System;

namespace PontoDigital.Models
{
    public class DepoimentoModel
    {
        public int Id{get;set;}
        public string Nome{get;set;}
        public string Sobrenome {get;set;}
        public string Email {get;set;}
        public string Mensagem {get;set;}
        public DateTime DataEntrada{get;set;}
        public string Botao {get;set;}
    }
}