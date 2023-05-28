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
    public partial class Frm_Questao : Form
    {
        public Frm_Questao(string nomeImagem, string mensagem)
        {
            InitializeComponent();
            Image MI = (Image)global::CursoWindowsForms0.Properties.Resources.ResourceManager.GetObject(nomeImagem);
            Pic_Imagem.Image = MI;
            Lbl_Questao.Text = mensagem;
        }

        private void Lbl_Questao_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Frm_Questao_Load(object sender, EventArgs e)
        {

        }
    }
}
