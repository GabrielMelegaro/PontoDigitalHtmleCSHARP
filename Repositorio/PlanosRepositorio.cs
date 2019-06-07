using System.Collections.Generic;
using System.IO;
using PontoDigital.Models;

namespace PontoDigital.Repositorio
{
    public class PlanosRepositorio
    {
        private const string PATH = "Database/Planos.csv";

        private List<PlanoModel> planos = new List<PlanoModel>();
            public List<PlanoModel> Listar(){
                var registros = File.ReadAllLines(PATH);
                foreach(var item in registros){
                    var valores = item.Split(";");
                    PlanoModel plano = new PlanoModel();
                    plano.Nome = valores[1];
                    plano.Preco = double.Parse(valores[2]);
            
                    planos.Add(plano);
            }

            return planos;
        }
        public double ObterPrecoDe(string nomePlano){
            var lista = Listar();
            var preco = 0.0;

            foreach(var item in lista){
                if(item.Nome.Equals(nomePlano)){
                    preco = item.Preco;
                }
            }

            return preco;
        }
    }
}