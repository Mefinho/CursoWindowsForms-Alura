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
    public partial class Frm_Demonstracao_UC : UserControl
    {
        public Frm_Demonstracao_UC()
        {
            InitializeComponent();
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            Txt_Msg.Clear();
            Lbl_Lower.Text = "";
            Lbl_Upper.Text = "";
            Txt_Input.Clear();
        }

        private void Txt_Input_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_Input_KeyDown(object sender, KeyEventArgs e)
        {
            Txt_Msg.AppendText("\r\n" + "Pressionei a tecla: " + e.KeyCode + "\r\n");
            Txt_Msg.AppendText("\t" + "Código da Tecla: " + (int)e.KeyCode + "\r\n");
            Txt_Msg.AppendText("\t" + "Nome da Tecla: " + e.KeyData + "\r\n");
            Lbl_Lower.Text = e.KeyCode.ToString().ToLower();
            Lbl_Upper.Text = e.KeyCode.ToString().ToUpper();
        }

        private void Frm_Demonstracao_UC_Load(object sender, EventArgs e)
        {

        }

        private void Txt_Msg_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
