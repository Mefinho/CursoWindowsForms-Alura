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
    public partial class Frm_ValidaCPF_UC : UserControl
    {
        public Frm_ValidaCPF_UC()
        {
            InitializeComponent();
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
    }
}
