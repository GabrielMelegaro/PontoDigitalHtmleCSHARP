using System;
using System.Collections.Generic;
using System.IO;
using PontoDigital.Models;
using PontoDigital.ViewModels;

namespace PontoDigital.Repositorio
{
        public class AdminRepositorio : BaseRepositorio 
    {
        public static uint CONT = 0;
        private const string PATH = "Database/Admin.csv";
        private const string PATH_INDEX = "Database/Admin_Id.csv";
        private List<AdminModel> admin = new List<AdminModel> ();

        public AdminRepositorio()
        {
            if (!File.Exists(PATH_INDEX)){
                File.Create(PATH_INDEX).Close();
            }

            var ultimoIndice = File.ReadAllText(PATH_INDEX);
            uint indice = 0;
            uint.TryParse(ultimoIndice, out indice);
            CONT = indice;
        }

        public bool Inserir (AdminModel admin) {
            CONT++;
            File.WriteAllText(PATH_INDEX, CONT.ToString());

            string linha = PrepararRegistroCSV (admin);
            File.AppendAllText (PATH, linha);

            return true;
        }

        public bool Atualizar (AdminModel admin) {
            var adminRecuperado = ObterRegistrosCSV (PATH);
            var adminString = PrepararRegistroCSV (admin);
            var linhaAdmin = -1;
            var resultado = false;

            for (int i = 0; i < adminRecuperado.Length; i++) {
                if (adminString.Equals (adminRecuperado[i])) {
                    linhaAdmin = i;
                    resultado = true;
                }
            }
            if (linhaAdmin >= 0) {
                adminRecuperado[linhaAdmin] = adminString;
                File.WriteAllLines (PATH, adminRecuperado);
            }

            return resultado;

        }

        public bool Apagar (ulong id) {

            var adminRecuperado = ObterRegistrosCSV (PATH);
            var linhaAdmin = -1;
            var resultado = false;

            for (int i = 0; i < adminRecuperado.Length; i++) {
                if (id.Equals (adminRecuperado[i])) {
                    linhaAdmin = i;
                    resultado = true;
                }
            }

            if (linhaAdmin >= 0) {
                adminRecuperado[linhaAdmin] = "";
                try {
                    File.WriteAllLines (PATH, adminRecuperado);

                } catch(DirectoryNotFoundException dnfe) {
                    System.Console.WriteLine("Diretório não encontrado. Favor verificar.");
                } catch (PathTooLongException ptle) {
                    System.Console.WriteLine("Nome do arquivo é muito grande.");
                }
            }

            return resultado;
        }

        public AdminModel ObterPor (ulong id) {

            foreach (var item in ObterRegistrosCSV (PATH)) {
                if (id.Equals (ExtrairCampo (id.ToString(), item))) {
                    return ConverterEmObjeto (item);
                }
            }
            return null;
        }

        public AdminModel ObterPor (string email) {
            if(email != null){  
                foreach (var item in ObterRegistrosCSV (PATH)) 
                {
                    if (email.Equals (ExtrairCampo ("email", item))) 
                    {
                        return ConverterEmObjeto (item);
                    }
                }
            }
                return null;
        }

        public List<AdminModel> ListarTodos () {
            var linhas = ObterRegistrosCSV (PATH);
            foreach (var item in linhas) {

                AdminModel admin = ConverterEmObjeto (item);

                this.admin.Add (admin);
            }
            return this.admin;
        }

        private AdminModel ConverterEmObjeto (string registro) {

            AdminModel admin = new AdminModel();
            System.Console.WriteLine("REGISTRO:" + registro);
            admin.Id = ulong.Parse(ExtrairCampo("id", registro));
            admin.Nome = ExtrairCampo("nome", registro);
            admin.Email = ExtrairCampo("email", registro);
            admin.Senha = ExtrairCampo("senha", registro);
            admin.DataNascimento = DateTime.Parse(ExtrairCampo("data_nascimento", registro));

            return admin;
        }

        private string PrepararRegistroCSV (AdminModel admin) {
            return $"id={CONT};nome={admin.Nome};email={admin.Email};senha={admin.Senha};data_nascimento={admin.DataNascimento}\n";
        }
    }
}