using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CursoWindowsFormsBiblioteca.Classes;
using CursoWindowsFormsBiblioteca.Databases;
using CursoWindowsFormsBiblioteca;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using System.IO;

namespace CursoWindowsForms0
{
    public partial class Frm_CadastroCliente_UC : UserControl
    {
        public Frm_CadastroCliente_UC()
        {
            InitializeComponent();

            Tls_Principal.Items[0].ToolTipText = "New Cliente";
            Tls_Principal.Items[1].ToolTipText = "Get Cliente";
            Tls_Principal.Items[2].ToolTipText = "Save Cliente";
            Tls_Principal.Items[3].ToolTipText = "Apagar Cliente";
            Tls_Principal.Items[4].ToolTipText = "Limpar dados";

            Grp_Codigo.Text = "Código";
            Grp_DadosPessoais.Text = "Dados Pessoais";
            Grp_Endereco.Text = "Endereço";
            Grp_Genero.Text = "Genero";
            Grp_Outros.Text = "Outros";
            Lbl_Bairro.Text = "Bairro";
            Lbl_CEP.Text = "CEP";
            Lbl_Complemento.Text = "Complemento";
            Lbl_Cidade.Text = "Cidade";
            Lbl_CPF.Text = "CPF";
            Lbl_Estado.Text = "Estado";
            Lbl_Logradouro.Text = "Logradouro";
            Lbl_NomeCliente.Text = "Nome";
            Lbl_NomeMae.Text = "Nome da Mãe";
            Lbl_NomePai.Text = "Nome do Pai";
            Lbl_Profissao.Text = "Profissão";
            Lbl_RendaFamiliar.Text = "Renda Familiar";
            Lbl_Telefone.Text = "Telefone";
            Btn_Busca.Text = "Buscar";
            Chk_TemPai.Text = "Pai Desconhecido";
            Rdb_Masculino.Text = "Masculino";
            Rdb_Feminino.Text = "Feminino";
            Rdb_NB.Text = "Não-Binário";
            Rdb_NC.Text = "Prefiro não dizer";

            Cmb_Estados.Items.Clear();
            Cmb_Estados.Items.Add("Acre (AC)");
            Cmb_Estados.Items.Add("Alagoas(AL)");
            Cmb_Estados.Items.Add("Amapá(AP)");
            Cmb_Estados.Items.Add("Amazonas(AM)");
            Cmb_Estados.Items.Add("Bahia(BA)");
            Cmb_Estados.Items.Add("Ceará(CE)");
            Cmb_Estados.Items.Add("Distrito Federal(DF)");
            Cmb_Estados.Items.Add("Espírito Santo(ES)");
            Cmb_Estados.Items.Add("Goiás(GO)");
            Cmb_Estados.Items.Add("Maranhão(MA)");
            Cmb_Estados.Items.Add("Mato Grosso(MT)");
            Cmb_Estados.Items.Add("Mato Grosso do Sul(MS)");
            Cmb_Estados.Items.Add("Minas Gerais(MG)");
            Cmb_Estados.Items.Add("Pará(PA)");
            Cmb_Estados.Items.Add("Paraíba(PB)");
            Cmb_Estados.Items.Add("Paraná(PR)");
            Cmb_Estados.Items.Add("Pernambuco(PE)");
            Cmb_Estados.Items.Add("Piauí(PI)");
            Cmb_Estados.Items.Add("Rio de Janeiro(RJ)");
            Cmb_Estados.Items.Add("Rio Grande do Norte(RN)");
            Cmb_Estados.Items.Add("Rio Grande do Sul(RS)");
            Cmb_Estados.Items.Add("Rondônia(RO)");
            Cmb_Estados.Items.Add("Roraima(RR)");
            Cmb_Estados.Items.Add("Santa Catarina(SC)");
            Cmb_Estados.Items.Add("São Paulo(SP)");
            Cmb_Estados.Items.Add("Sergipe(SE)");
            Cmb_Estados.Items.Add("Tocantins(TO)");


        }

        private void Frm_CadastroCliente_UC_Load(object sender, EventArgs e)
        {
        }

        private void Chk_TemPai_CheckedChanged(object sender, EventArgs e)
        {
            if (!Chk_TemPai.Checked)
            {
                Txt_NomePai.Enabled = true;
                return;
            }
            Txt_NomePai.Enabled = false;
        }

        private void novoToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente.Unit c = new Cliente.Unit();
                c = LeituraFormulario();
                c.ValidaClasse();
                c.ValidaComplemento();
                c.IncluirFichario("C:\\Teste\\Ficharios");
                MessageBox.Show("Cliente Registrado com sucesso.", "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {
            if (Txt_Codigo.Text == "")
            {
                MessageBox.Show("Código do cliente vazio.", "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Cliente.Unit c = new Cliente.Unit();
                c = c.BuscarFichario(Txt_Codigo.Text, "C:\\Teste\\Ficharios");
                if (c == null)
                {
                    MessageBox.Show("Cliente não existente no banco de dados.", "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                EscreveFormulario(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salvarToolStripButton_Click(object sender, EventArgs e)
        {
            if (Txt_Codigo.Text == "")
            {
                MessageBox.Show("Código do cliente vazio.", "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Cliente.Unit c = new Cliente.Unit();
                c = LeituraFormulario();
                c.ValidaClasse();
                c.ValidaComplemento();
                c.AlterarFichario("C:\\Teste\\Ficharios");
                MessageBox.Show("Cliente alterado com sucesso.", "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApagatoolStripButton1_Click(object sender, EventArgs e)
        {
            if (Txt_Codigo.Text == "")
            {
                MessageBox.Show("Código do cliente vazio.", "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Cliente.Unit c = new Cliente.Unit();
                if (c == null)
                {
                    MessageBox.Show("Cliente não existente no banco de dados.", "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                c = c.BuscarFichario(Txt_Codigo.Text, "C:\\Teste\\Ficharios");
                EscreveFormulario(c);
                Frm_Questao Db = new Frm_Questao("Frm_Questao", "Tem certeza que quer excluir esse cliente?");
                Db.ShowDialog();
                if (!(Db.DialogResult == DialogResult.Yes)) return;
                c.ApagarFichario("C:\\Teste\\Ficharios");
                LimpaFormulario();
                MessageBox.Show("Cliente deletado com sucesso.", "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpatoolStripButton1_Click(object sender, EventArgs e)
        {
            LimpaFormulario();
        }

        void LimpaFormulario()
        {
            Txt_Codigo.Text = "";
            Txt_Bairro.Text = "";
            Txt_CEP.Text = "";
            Txt_Complemento.Text = "";
            Txt_Cidade.Text = "";
            Txt_CPF.Text = "";
            Cmb_Estados.SelectedIndex = -1;
            Txt_Logradouro.Text = "";
            Txt_NomeCliente.Text = "";
            Txt_NomeMae.Text = "";
            Txt_NomePai.Text = "";
            Txt_Profissao.Text = "";
            Txt_RendaFamiliar.Text = "";
            Txt_Telefone.Text = "";
            Chk_TemPai.Checked = false;
            Rdb_NC.Checked = true;
        }
        Cliente.Unit LeituraFormulario()
        {
            Cliente.Unit c = new Cliente.Unit();
            c.Id = Txt_Codigo.Text;
            c.Nome = Txt_NomeCliente.Text;
            c.NomeMae = Txt_NomeMae.Text;
            c.NomePai = Txt_NomePai.Text;
            if (Chk_TemPai.Checked)
            {
                c.NaoTemPai = true;
            }
            else
            {
                c.NaoTemPai = false;
            }
            if (Rdb_Masculino.Checked) c.Genero = 0;
            if (Rdb_Feminino.Checked) c.Genero = 1;
            if (Rdb_NB.Checked) c.Genero = 2;
            if (Rdb_NC.Checked) c.Genero = 3;
            c.Cpf = Txt_CPF.Text;

            c.CEP = Txt_CEP.Text;
            c.Logradouro = Txt_Logradouro.Text;
            c.Complemento = Txt_Complemento.Text;
            c.Cidade = Txt_Cidade.Text;
            c.Bairro = Txt_Bairro.Text;
            if (Cmb_Estados.SelectedIndex < 0) c.Estado = "";
            else c.Estado = Cmb_Estados.Items[Cmb_Estados.SelectedIndex].ToString();
            c.Telefone = Txt_Telefone.Text;
            c.Profissao = Txt_Profissao.Text;
            if (Information.IsNumeric(Txt_RendaFamiliar.Text))
            {
                Double veRenda = Convert.ToDouble(Txt_RendaFamiliar.Text);
                if (veRenda < 0) c.RendaFamiliar = 0;
                else c.RendaFamiliar = veRenda;
            }

            return c;
        }

        void EscreveFormulario(Cliente.Unit c)
        {
            Txt_Codigo.Text = c.Id;
            Txt_NomeCliente.Text = c.Nome;
            Txt_NomeMae.Text = c.NomeMae;
            if (c.NaoTemPai)
            {
                Chk_TemPai.Checked = true;
                Txt_NomePai.Text = "";
            }
            else
            {
                Chk_TemPai.Checked = false;
                Txt_NomePai.Text = c.NomePai;
            }
            if (c.Genero == 0) Rdb_Masculino.Checked = true;
            if (c.Genero == 1) Rdb_Feminino.Checked = true;
            if (c.Genero == 2) Rdb_NB.Checked = true;
            if (c.Genero == 3) Rdb_NC.Checked = true;
            Txt_CPF.Text = c.Cpf;

            Txt_CEP.Text = c.CEP;
            Txt_Logradouro.Text = c.Logradouro;
            Txt_Complemento.Text = c.Complemento;
            Txt_Cidade.Text = c.Cidade;
            Txt_Bairro.Text = c.Bairro;
            if (c.Estado == "") Cmb_Estados.SelectedIndex = -1;
            else
            {
                for (int i = 0; i < Cmb_Estados.Items.Count - 1; i++)
                {
                    if (Cmb_Estados.Items[i].ToString() == c.Estado)
                    {
                        Cmb_Estados.SelectedIndex = i;
                    }
                }
            }
            Txt_Telefone.Text = c.Telefone;
            Txt_Profissao.Text = c.Profissao;
            Txt_RendaFamiliar.Text = c.RendaFamiliar.ToString();
        }

        private void Txt_CEP_Leave(object sender, EventArgs e)
        {
            string vCep = Txt_CEP.Text;
            if (vCep.Length != 8)
            {
                return;
            }
            if (vCep == "")
            {
                return;
            }
            if (!Information.IsNumeric(vCep))
            {
                return;
            }
            var vJson = Cls_Utils.GeraJSONCEP(vCep);
            CEP.Unit cep = new CEP.Unit();
            cep = CEP.DesserializeClassUnit(vJson);
            Txt_Logradouro.Text = cep.logradouro;
            Txt_Bairro.Text = cep.bairro;
            Txt_Cidade.Text = cep.localidade;
            Cmb_Estados.SelectedIndex = -1;
            for (int i = 0; i < Cmb_Estados.Items.Count - 1; i++)
            {
                var vPos = Strings.InStr(Cmb_Estados.Items[i].ToString(), $"({cep.uf})");
                if (vPos > 0)
                {
                    Cmb_Estados.SelectedIndex = i;
                }
            }
        }

        private void Btn_Busca_Click(object sender, EventArgs e)
        {
            Cliente.Unit c = new Cliente.Unit();
            List<string> list = c.ListaFichario("C:\\Teste\\Ficharios");

            if (list == null)
            {
                MessageBox.Show("ERR: " + "Não há contas registradas.", "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<List<string>> listaBusca = new List<List<string>>();

                foreach (string s in list)
                {
                    c = Cliente.DesserializeClassUnit(s);
                    listaBusca.Add(new List<string> { c.Id, c.Nome });
                }
                Frm_Busca fFrm = new Frm_Busca(listaBusca);
                fFrm.ShowDialog();

                if (fFrm.DialogResult == DialogResult.Cancel)
                {
                    return;
                }
                var idSelected = fFrm.IdSelected;
                c = c.BuscarFichario(idSelected, "C:\\Teste\\Ficharios\\");
                if (c == null)
                {
                    MessageBox.Show("ERR: " + "Identificador não encontrado.", "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                EscreveFormulario(c);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
