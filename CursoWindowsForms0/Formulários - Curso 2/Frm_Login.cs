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
    public partial class Frm_Login : Form
    {
        public string login;
        public string senha;
        public Frm_Login()
        {
            InitializeComponent();
            Lbl_Login.Text = "Usuário";
            Lbl_Senha.Text = "Senha";
            Btn_Ok.Text = "OK";
            Btn_Cancel.Text = "Cancel";
        }

        private void Lbl_Senha_Click(object sender, EventArgs e)
        {

        }

        private void Pic_Login_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            login = Txt_Login.Text;
            senha = Txt_Senha.Text;
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
