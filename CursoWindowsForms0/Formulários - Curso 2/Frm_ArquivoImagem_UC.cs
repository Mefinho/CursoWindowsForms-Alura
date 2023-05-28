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
    public partial class Frm_ArquivoImagem_UC : UserControl
    {
        public Frm_ArquivoImagem_UC(string nomeArquivoImagem)
        {
            InitializeComponent();
            Lbl_ArquivoIMG.Text = nomeArquivoImagem;
            Pic_Imagem.Image = Image.FromFile(nomeArquivoImagem);
        }

        private void Btn_Cor_Click(object sender, EventArgs e)
        {
            ColorDialog db = new ColorDialog();
            if (db.ShowDialog() == DialogResult.OK) Lbl_ArquivoIMG.ForeColor = db.Color;
        }

        private void Btn_Fonte_Click(object sender, EventArgs e)
        {
            FontDialog fdb = new FontDialog();
            if (fdb.ShowDialog() == DialogResult.OK) Lbl_ArquivoIMG.Font = fdb.Font;
        }
    }
}
