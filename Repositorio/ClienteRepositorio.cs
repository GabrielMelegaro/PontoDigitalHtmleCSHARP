using System;
using System.Collections.Generic;
using System.IO;
using PontoDigital.Models;

namespace PontoDigital.Repositorio
{
    public class ClienteRepositorio : BaseRepositorio 
    {
        public static uint CONT = 0;
        private const string PATH = "Database/Cliente.csv";
        private const string PATH_INDEX = "Database/Cliente_Id.csv";
        private List<ClienteModel> clientes = new List<ClienteModel> ();

        public ClienteRepositorio()
        {
            if (!File.Exists(PATH_INDEX)){
                File.Create(PATH_INDEX).Close();
            }

            var ultimoIndice = File.ReadAllText(PATH_INDEX);
            uint indice = 0;
            uint.TryParse(ultimoIndice, out indice);
            CONT = indice;
        }

        public bool Inserir (ClienteModel cliente) {
            CONT++;
            File.WriteAllText(PATH_INDEX, CONT.ToString());

            string linha = PrepararRegistroCSV (cliente);
            File.AppendAllText (PATH, linha);

            return true;
        }

        public bool Atualizar (ClienteModel cliente) {
            var clientesRecuperados = ObterRegistrosCSV (PATH);
            var clienteString = PrepararRegistroCSV (cliente);
            var linhaCliente = -1;
            var resultado = false;

            for (int i = 0; i < clientesRecuperados.Length; i++) {
                if (clienteString.Equals (clientesRecuperados[i])) {
                    linhaCliente = i;
                    resultado = true;
                }
            }
            if (linhaCliente >= 0) {
                clientesRecuperados[linhaCliente] = clienteString;
                File.WriteAllLines (PATH, clientesRecuperados);
            }

            return resultado;

        }

        public bool Apagar (ulong id) {

            var clientesRecuperados = ObterRegistrosCSV (PATH);
            var linhaCliente = -1;
            var resultado = false;

            for (int i = 0; i < clientesRecuperados.Length; i++) {
                if (id.Equals (clientesRecuperados[i])) {
                    linhaCliente = i;
                    resultado = true;
                }
            }

            if (linhaCliente >= 0) {
                clientesRecuperados[linhaCliente] = "";
                try {
                    File.WriteAllLines (PATH, clientesRecuperados);

                } catch(DirectoryNotFoundException dnfe) {
                    System.Console.WriteLine("Diretório não encontrado. Favor verificar.");
                } catch (PathTooLongException ptle) {
                    System.Console.WriteLine("Nome do arquivo é muito grande.");
                }
            }

            return resultado;
        }

        public ClienteModel ObterPor (ulong id) {

            foreach (var item in ObterRegistrosCSV (PATH)) {
                if (id.Equals (ExtrairCampo (id.ToString(), item))) {
                    return ConverterEmObjeto (item);
                }
            }
            return null;
        }

        public ClienteModel ObterPor (string email) {
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

        public List<ClienteModel> ListarTodos () {
            var linhas = ObterRegistrosCSV (PATH);
            foreach (var item in linhas) {

                ClienteModel cliente = ConverterEmObjeto (item);

                this.clientes.Add (cliente);
            }
            return this.clientes;
        }

        private ClienteModel ConverterEmObjeto (string registro) {

            ClienteModel cliente = new ClienteModel();
            System.Console.WriteLine("REGISTRO:" + registro);
            cliente.Id = ulong.Parse(ExtrairCampo("id", registro));
            cliente.Nome = ExtrairCampo("nome", registro);
            cliente.Email = ExtrairCampo("email", registro);
            cliente.Senha = ExtrairCampo("senha", registro);
            cliente.DataNascimento = DateTime.Parse(ExtrairCampo("data_nascimento", registro));

            return cliente;
        }

        private string PrepararRegistroCSV (ClienteModel cliente) {
            return $"id={CONT};nome={cliente.Nome};email={cliente.Email};senha={cliente.Senha};data_nascimento={cliente.DataNascimento}\n";
        }
    }
}