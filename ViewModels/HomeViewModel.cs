using System.Collections.Generic;
using PontoDigital.Models;

namespace PontoDigital.ViewModels
{
    public class HomeViewModel
    {
        public List<EmailModel> Emails{get;set;}
        public List<SobrenomeModel> Sobrenomes{get;set;}
        public List<DepoimentoModel> Depoimentos{get;set;}
    }
}