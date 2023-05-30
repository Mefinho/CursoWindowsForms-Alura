using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class Fichario
    {
        public string diretorio;
        public string mensagem;
        public bool status;
        public Fichario(string Diretorio)
        {
            status = true;
            diretorio = Diretorio;
            try
            {
                if (!Directory.Exists(Diretorio))
                    Directory.CreateDirectory(Diretorio);
                status = true;
                mensagem = "Conexão com o fichario foi bem sucedida.";
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o fichario teve erro." + ex.Message;
            }
        }

        public void Incluir(string id, string jsonUnit)
        {
            status = true;
            try
            {
                if (!File.Exists($"{diretorio}\\{id}.json"))
                {
                    File.WriteAllText($"{diretorio}\\{id}.json", jsonUnit);
                    status = true;
                    mensagem = $"Inclusão efetuada com sucesso. Identificador: {id}";
                    return;
                }
                status = false;
                mensagem = "Inclusão não permitida. Identificador já existente.";
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o fichario com erro: " + ex.Message;
            }
        }

        public string Buscar(string id)
        {
            status = true;
            try
            {
                if (File.Exists($"{diretorio}\\{id}.json"))
                {
                    string conteudo = File.ReadAllText($"{diretorio}\\{id}.json");
                    status = true;
                    return conteudo;
                }
                status = false;
                mensagem = "Identificador não existente.";
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar conteúdo: " + ex.Message;

            }
            return "";
        }

        public List<string> BuscarTodos()
        {
            status = true;
            List<string> list = new List<string>();
            try
            {
                var arquivos = Directory.GetFiles(diretorio, "*.json");
                for (int i = 0; i < arquivos.Length - 1; i++)
                {
                    string conteudo = File.ReadAllText(arquivos[i]);
                    list.Add(conteudo);
                }
                    return list;

            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar conteúdo: " + ex.Message;

            }
            return list;
        }


        public void Apagar(string id)
        {

            status = true;
            try
            {
                if (File.Exists($"{diretorio}\\{id}.json"))
                {
                    File.Delete($"{diretorio}\\{id}.json");
                    status = true;
                    mensagem = "Cliente excluído com sucesso.";
                    return;
                }
                status = false;
                mensagem = "Identificador não existente.";
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao apagar conteúdo: " + ex.Message;

            }
        }


        public void Alterar(string id, string jsonUnit)
        {
            status = true;
            try
            {
                if (File.Exists($"{diretorio}\\{id}.json"))
                {
                    File.Delete($"{diretorio}\\{id}.json");
                    File.WriteAllText($"{diretorio}\\{id}.json", jsonUnit);
                    status = true;
                    mensagem = $"Alteração efetuada com sucesso. Identificador: {id}";
                    return;
                }
                status = false;
                mensagem = "Alteração não permitida. Identificador não existente.";
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o fichario com erro: " + ex.Message;
            }
        }
    }
}
