﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using CursoWindowsFormsBiblioteca.Databases;

namespace CursoWindowsFormsBiblioteca.Classes
{
    public class Cliente
    {
        public class Unit
        {
            [Required(ErrorMessage = "Código do cliente é obrigatório.")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Código do cliente aceita apenas valores númericos.")]
            [StringLength(6, MinimumLength = 6, ErrorMessage = "Código do cliente deve ter 6 dígitos.")]
            public string Id { get; set; }

            [Required(ErrorMessage = "Nome do cliente é obrigatório.")]
            [StringLength(50, ErrorMessage = "Nome do cliente deve ter no máximo 50 Caracteres.")]
            public string Nome { get; set; }

            [StringLength(50, ErrorMessage = "Nome do Pai deve ter no máximo 50 Caracteres.")]
            public string NomePai { get; set; }

            [Required(ErrorMessage = "Nome da Mãe é obrigatório.")]
            [StringLength(50, ErrorMessage = "Nome da Mãe deve ter no máximo 50 Caracteres.")]
            public string NomeMae { get; set; }

            public bool NaoTemPai { get; set; }
            [Required(ErrorMessage = "CPF é obrigatório.")]
            [RegularExpression("([0-9]+)", ErrorMessage = "CPF aceita apenas valores númericos.")]
            [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF do cliente deve ter 11 dígitos.")]
            public string Cpf { get; set; }

            [Required(ErrorMessage = "A seleção do gênero é obrigatória.")]
            public int Genero { get; set; }

            [Required(ErrorMessage = "CEP é obrigatório.")]
            [RegularExpression("([0-9]+)", ErrorMessage = "CEP aceita apenas valores númericos.")]
            [StringLength(8, MinimumLength = 8, ErrorMessage = "CEP deve ter 8 dígitos.")]
            public string CEP { get; set; }

            [Required(ErrorMessage = "Logradouro é obrigatório.")]
            [StringLength(100, ErrorMessage = "Logradouro deve ter no máximo 100 caracteres.")]
            public string Logradouro { get; set; }

            [Required(ErrorMessage = "Complemento é obrigatório.")]
            [StringLength(100, ErrorMessage = "Complemento deve ter no máximo 100 caracteres.")]
            public string Complemento { get; set; }

            [Required(ErrorMessage = "Bairro é obrigatório.")]
            [StringLength(100, ErrorMessage = "Bairro deve ter no máximo 50 caracteres.")]
            public string Bairro { get; set; }

            [Required(ErrorMessage = "Cidade é obrigatório.")]
            [StringLength(100, ErrorMessage = "Cidade deve ter no máximo 50 caracteres.")]
            public string Cidade { get; set; }

            [Required(ErrorMessage = "Estado é obrigatório.")]
            [StringLength(100, ErrorMessage = "Estado deve ter no máximo 50 caracteres.")]
            public string Estado { get; set; }

            [Required(ErrorMessage = "Telefone é obrigatório.")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Telefone aceita apenas valores númericos.")]
            public string Telefone { get; set; }

            public string Profissao { get; set; }

            [Required(ErrorMessage = "Renda familiar é obrigatória.")]
            [Range(0, double.MaxValue, ErrorMessage = "Renda deve ser um valor positivo.")]
            public double RendaFamiliar { get; set; }

            public void ValidaComplemento()
            {
                if (this.NomePai == this.NomeMae)
                    throw new Exception("Nome do pai e da mãe não podem ser iguais.");

                if (!this.NaoTemPai && this.NomePai == "")
                    throw new Exception("Nome do pai não pode estar vazio quando a opção 'Pai desconhecido' não estiver selecionada.");
                if (!Cls_Utils.Valida(this.Cpf))
                    throw new Exception("O cpf é inválido.");
            }

            public void ValidaClasse()
            {
                ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
                List<ValidationResult> results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(this, context, results, true);

                if (!isValid)
                {
                    StringBuilder sbrErrors = new StringBuilder();
                    foreach (var validationResult in results)
                    {
                        sbrErrors.AppendLine(validationResult.ErrorMessage);
                    }
                    throw new ValidationException(sbrErrors.ToString());
                }
            }

            #region:CRUD DO FICHARIO

            public void IncluirFichario(string conexao)
            {
                Fichario f = new Fichario(conexao);
                string clienteJson = Cliente.SerializeClassUnit(this);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }

                f.Incluir(this.Id, clienteJson);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }

            }

            public Unit BuscarFichario(string id, string conexao)
            {
                Fichario f = new Fichario(conexao);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }
                string clienteJson = f.Buscar(id);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }
                return DesserializeClassUnit(clienteJson);
            }

            public void AlterarFichario(string conexao)
            {
                Fichario f = new Fichario(conexao);
                string clienteJson = Cliente.SerializeClassUnit(this);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }

                f.Alterar(this.Id, clienteJson);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }

            }

            public void ApagarFichario(string conexao)
            {
                Fichario f = new Fichario(conexao);

                string clienteJson = Cliente.SerializeClassUnit(this);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }

                f.Apagar(this.Id);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }
            }

            public List<string> ListaFichario(string conexao)
            {
                Fichario f = new Fichario(conexao);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }
                List<string> todosJson = f.BuscarTodos();
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }
                return todosJson;
            }

            #endregion

            #region:CRUD DO FicharioDB LOCALDB

            public void IncluirFicharioDB(string conexao)
            {
                FicharioDB f = new FicharioDB(conexao);
                string clienteJson = Cliente.SerializeClassUnit(this);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }

                f.Incluir(this.Id, clienteJson);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }

            }

            public Unit BuscarFicharioDB(string id, string conexao)
            {
                FicharioDB f = new FicharioDB(conexao);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }
                string clienteJson = f.Buscar(id);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }
                return DesserializeClassUnit(clienteJson);
            }

            public void AlterarFicharioDB(string conexao)
            {
                FicharioDB f = new FicharioDB(conexao);
                string clienteJson = Cliente.SerializeClassUnit(this);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }

                f.Alterar(this.Id, clienteJson);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }

            }

            public void ApagarFicharioDB(string conexao)
            {
                FicharioDB f = new FicharioDB(conexao);

                string clienteJson = Cliente.SerializeClassUnit(this);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }

                f.Apagar(this.Id);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }
            }

            public List<string> ListaFicharioDB(string conexao)
            {
                FicharioDB f = new FicharioDB(conexao);
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }
                List<string> todosJson = f.BuscarTodos();
                if (!f.status)
                {
                    throw new Exception(f.mensagem);
                }
                return todosJson;
            }

            #endregion

        }

        public class List
        {
            public List<Unit> ListUnit { get; set; }
        }

        public static Unit DesserializeClassUnit(string json)
        {
            return JsonConvert.DeserializeObject<Unit>(json);
        }

        public static string SerializeClassUnit(Unit unit)
        {
            return JsonConvert.SerializeObject(unit);
        }
    }
}
