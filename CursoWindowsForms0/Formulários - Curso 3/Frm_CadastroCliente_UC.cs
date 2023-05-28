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
using CursoWindowsFormsBiblioteca;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

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
                MessageBox.Show("Classe foi inicializada sem erros", "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Bytebank");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bytebank");
            }
        }

        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void salvarToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void ApagatoolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        Cliente.Unit LeituraFormulario()
        {
            Cliente.Unit c = new Cliente.Unit();
            c.Id = Txt_Codigo.Text;
            c.Nome = Txt_NomeCliente.Text;
            c.NomeMae = Txt_NomeMae.Text;
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
            cep = CEP.DesserializedClassUnit(vJson);
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
    }
}
