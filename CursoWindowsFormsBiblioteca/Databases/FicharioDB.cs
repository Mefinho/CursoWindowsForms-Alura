using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class FicharioDB
    {
        public string mensagem;
        public bool status;
        public string tabela;
        public LocalDBClass db;

        public FicharioDB(string Tabela)
        {
            status = true;
            try
            {
                db = new LocalDBClass();
                tabela = Tabela;
                mensagem = "Conexão bem sucedida.";
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com erro." + ex.Message;
            }
        }

        public DataTable a = new DataTable();
        public void Incluir(string id, string jsonUnit)
        {
            status = true;
            try
            {
                //INSERT INTO CLIENTE (ID, JSON) VALUES (id, jsonUnit)

                var SQL = $"INSERT INTO {tabela} (Id, JSON) VALUES ('{id}', '{jsonUnit}')";

                db.SQLCOmmmand(SQL);
                status = true;
                mensagem = $"Inclusão permitida. Identificador: {id}.";
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
                //SELECT ID, JSON FROM CLIENTE WHERE id = ...

                var SQL = $"SELECT Id, JSON FROM {tabela} WHERE Id = '{id}'";
                var dt = db.SQLQuery(SQL);

                if (dt.Rows.Count > 0)
                {
                    string conteudo = dt.Rows[0]["JSON"].ToString();
                    status = true;
                    mensagem = $"Edição permitida. Identificador: {id}.";
                    return conteudo;
                }
                status = false;
                mensagem = $"Identificador não existente: {id}";
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
                //SELECT ID, JSON FROM CLIENTE

                var SQL = $"SELECT Id, JSON FROM {tabela}";
                var dt = db.SQLQuery(SQL);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        string conteudo = dt.Rows[i]["JSON"].ToString();
                        list.Add(conteudo);
                    }
                    return list;
                }
                status = false;
                mensagem = $"Não existem clientes na base de dados.";
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
                var SQL = $"SELECT Id, JSON FROM {tabela} WHERE Id = '{id}'";
                var dt = db.SQLQuery(SQL);
                if (dt.Rows.Count > 0)
                {
                    SQL = $"DELETE FROM {tabela} WHERE ID = '{id}'";
                    string conteudo = dt.Rows[0]["JSON"].ToString();
                    db.SQLCOmmmand(SQL);
                    status = true; 
                    mensagem = $"Exclusão permitida. Identificador: {id}.";
                    return;
                }
                status = false;
                mensagem = $"Não existem clientes na base de dados.";
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
                var SQL = $"SELECT Id, JSON FROM {tabela} WHERE Id = '{id}'";
                var dt = db.SQLQuery(SQL);
                if (dt.Rows.Count > 0)
                {
                    SQL = $"UPDATE {tabela} SET JSON = '{jsonUnit}' WHERE ID = '{id}'";
                    db.SQLCOmmmand(SQL);
                    status = true;
                    mensagem = $"Alteração efetuada com sucesso. Identificador: {id}.";
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
