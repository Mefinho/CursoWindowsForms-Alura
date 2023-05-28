using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CursoWindowsFormsBiblioteca.Cls_Utils;

namespace CursoWindowsForms0
{
    public partial class Frm_ValidaSenha : Form
    {
        bool VerSenhaTxT = false;
        public Frm_ValidaSenha()
        {
            InitializeComponent();
        }

        private void Frm_ValidaSenha_Load(object sender, EventArgs e)
        {

        }

        private void Lbl_Resultado_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            Txt_Senha.Text = "";
            Lbl_Resultado.Text = "";
        }

        private void Txt_Senha_KeyDown(object sender, KeyEventArgs e)
        {
            ChecaForcaSenha check = new ChecaForcaSenha();
            ChecaForcaSenha.ForcaDaSenha forca;
            forca = check.GetForcaDaSenha(Txt_Senha.Text);
            Lbl_Resultado.Text = forca.ToString();
            if (Lbl_Resultado.Text == "Inaceitavel" || Lbl_Resultado.Text == "Fraca")
            {
                Lbl_Resultado.ForeColor = Color.Red;
            }
            else if (Lbl_Resultado.Text == "Aceitavel")
            {
                Lbl_Resultado.ForeColor = Color.Blue;
            }
            else Lbl_Resultado.ForeColor = Color.Green;
        }

        private void Btn_VerSenha_Click(object sender, EventArgs e)
        {
            if (!VerSenhaTxT)
            {
                Txt_Senha.PasswordChar = '\0';
                Btn_VerSenha.Text = "Esconder Senha";
                VerSenhaTxT = true;
                return;
            }
            Txt_Senha.PasswordChar = '*';
            Btn_VerSenha.Text = "Ver Senha";
            VerSenhaTxT = false;
        }

        private void Txt_Senha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
