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

namespace CursoWindowsForms0
{
    public partial class Frm_ValidaCPF : Form
    {
        public Frm_ValidaCPF()
        {
            InitializeComponent();
        }

        private void Frm_ValidaCPF_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            Lbl_Resultado.Text = "";
            Msk_CPF.Text = "";  
        }

        private void Btn_Valida_Click(object sender, EventArgs e)
        {
            bool ValidaCpf = false;
            ValidaCpf = Cls_Utils.Valida(Msk_CPF.Text);
            if (!ValidaCpf)
            {
                Lbl_Resultado.Text = "CPF Inválido";
                Lbl_Resultado.ForeColor = Color.IndianRed;
                return;
            }
            Lbl_Resultado.Text = "CPF Válido";
            Lbl_Resultado.ForeColor = Color.Cyan;
        }

        private void Lbl_Resultado_Click(object sender, EventArgs e)
        {

        }

        private void Msk_CPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
