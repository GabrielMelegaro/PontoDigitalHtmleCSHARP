using System.Collections.Generic;
using System.IO;
using PontoDigital.Models;

namespace PontoDigital.Repositorio
{
    public class EmailRepositorio
    {
        private const string PATH = "Database/Emails.csv";

        private List<EmailModel> listaDeEmails = new List<EmailModel>();
    
        public List<EmailModel> ListarEmails(){
            string[] modelos = File.ReadAllLines(PATH);

            foreach(var item in modelos){
                if(item != null){
                    string[] dados = item.Split(";");
                    var email = new EmailModel();

                    email.Id = int.Parse(dados[0]);
                    email.Nome = dados[1];

                    listaDeEmails.Add(email);
                }//fim if
            }//fim foreach
            return listaDeEmails;
        }
    }
}