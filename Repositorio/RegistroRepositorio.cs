using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using PontoDigital.Models;

namespace PontoDigital.Repositorio
{
    public class RegistroRepositorio
    {
        private const string PATH = "Database/Cadastro.csv";
       public bool Inserir(RegistroModel cadastrar)
       {
           try{

           if(!File.Exists(PATH)){
               //Codigo de criação do arquivo
               File.Create(PATH).Close();
           }
           var cadastro = $"{cadastrar.Id};{cadastrar.Cliente.Nome};{cadastrar.Cliente.Email};{cadastrar.Cliente.Senha};{cadastrar.DataNascimento}\n";
               //Codigo de gravação
           File.AppendAllText(PATH,cadastro);
           }catch(Exception e){
               System.Console.WriteLine("Chegou no catch!");
               System.Console.WriteLine(e.StackTrace);
           }

           return true;
       }
    }
}