using System.Collections.Generic;
using System.IO;
using PontoDigital.Models;

namespace PontoDigital.Repositorio
{
    public class SobrenomeRepositorio
    {
        private const string PATH = "Database/Sobrenomes.csv";

        private List<SobrenomeModel> listaDeSobrenomes = new List<SobrenomeModel>();

        public List<SobrenomeModel> ListarSobrenomes(){

            string[] marcas = File.ReadAllLines(PATH);
            
            foreach (var item in marcas)
            {
                if(item != null){
                    string[] dados = item.Split(";");
                    var sobrenome = new SobrenomeModel();
                    sobrenome.Id = int.Parse(dados[0]);
                    sobrenome.Nome = dados[1];
                    
                    listaDeSobrenomes.Add(sobrenome);
                }//fim if
            }// fim foreach
            return listaDeSobrenomes;
        }
    }
}