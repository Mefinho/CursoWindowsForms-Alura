using CursoWindowsFormsBiblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoWindowsForms0.Formulários___User_Control
{
    public partial class Frm_ValidaCPF2_UC : UserControl
    {
        public Frm_ValidaCPF2_UC()
        {
            InitializeComponent();
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            Msk_CPF.Text = "";
        }

        private void Btn_Valida_Click(object sender, EventArgs e)
        {
            string vContent;
            vContent = Msk_CPF.Text;
            vContent = vContent.Replace(".", "").Replace("-", "").Replace(" ", "").Trim();
            if (vContent == "" || vContent.Length < 11)
            {
                MessageBox.Show("Você deve digitar um CPF completo", "Mensagem de validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Frm_Questao db = new Frm_Questao("Frm_ValidaCPF2", "Deseja validar seu CPF?");
            db.ShowDialog();
            if (db.DialogResult != DialogResult.Yes)
            {
                return;
            }
            bool ValidaCpf = false;
            ValidaCpf = Cls_Utils.Valida(Msk_CPF.Text);
            if (!ValidaCpf)
            {
                MessageBox.Show("CPF INVÁLIDO", "Mensagem de validação", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
                return;
            }
            MessageBox.Show("CPF VÁLIDO", "Mensagem de validação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
