using System;
using System.Collections.Generic;
using System.IO;
using PontoDigital.Models;

namespace PontoDigital.Repositorio
{
    public class DepoimentoRepositorio
    {
        private const string PATH = "Database/Depoimentos.csv";
        private const string PATH_APROVADO = "Database/Depoimentos_Aprovados.csv";
        private const string PATH_REPROVADO = "Database/Depoimentos_Reprovados.csv";
        public void RegistrarNoCSV(DepoimentoModel depoimento){
            if(File.Exists(PATH)){
                depoimento.Id = File.ReadAllLines(PATH).Length + 1;
            }else{
                depoimento.Id = 1;
            }
            StreamWriter sw = new StreamWriter(PATH, true);

            sw.WriteLine($"{depoimento.Id};{depoimento.Nome};{depoimento.Sobrenome};{depoimento.Email};{depoimento.Mensagem};{DateTime.Now}\n");
            sw.Close();
        }

        public List<DepoimentoModel> Listar(){

        List<DepoimentoModel> listaDeDepoimentos = new List<DepoimentoModel>();
            
            string[] linhas = File.ReadAllLines(PATH);
            
            foreach (var item in linhas)
            {
                if(string.IsNullOrEmpty(item)){
                    continue;
                }   
                string[] dados = item.Split(";");
                DepoimentoModel depoimento = new DepoimentoModel();

                depoimento.Id = int.Parse(dados[0]);
                depoimento.Nome = dados[1];
                depoimento.Sobrenome = dados[2];
                depoimento.Email = dados[3];
                depoimento.Mensagem = dados[4];
                depoimento.DataEntrada = DateTime.Parse(dados[5]);
            
                listaDeDepoimentos.Add(depoimento);
            }
            return listaDeDepoimentos;
        }

        public List<DepoimentoModel> Filtrar(DateTime data){
            List<DepoimentoModel> listaFiltrada = new List<DepoimentoModel>();
            List<DepoimentoModel> listaDeDepoimentos = Listar();

            foreach (var item in listaDeDepoimentos){
                if (item.DataEntrada.ToShortDateString() == data.ToShortDateString()){
                    listaFiltrada.Add(item);
                }else{
                    continue;
                }
            }//fim foreach
            return listaFiltrada;
        }
    }
}