using System.Collections.Generic;
using PontoDigital.Models;

namespace PontoDigital.ViewModels
{
    public class HomeViewModel
    {
        public List<DepoimentoModel> Depoimentos{get;set;}
        public List<ClienteModel> Cliente {get;set;}
        public List<AdminModel> Admin {get;set;}
    }
}