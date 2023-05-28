using CursoWindowsForms0.Formulários___User_Control;
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
    public partial class Frm_Principal_Menu_UC : Form
    {
        int ControleHelloWorld = 0;
        int ControleDemonstracao = 0;
        int ControleMascara = 0;
        int ControleValidaCPF = 0;
        int ControleValidaCPF2 = 0;
        int ControleValidaSenha = 0;
        int ControleArquivoImagem = 0;
        int ControleCadastroClientes = 0;
        public Frm_Principal_Menu_UC()
        {
            InitializeComponent();
            novoToolStripMenuItem.Enabled = false;
            apagarAbaToolStripMenuItem.Enabled = false;
            abrirImagemToolStripMenuItem.Enabled = false;
            desconectarToolStripMenuItem.Enabled = false;
            cadastrosToolStripMenuItem.Enabled = false;
        }

        private void demonstraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleDemonstracao++;
            Frm_Demonstracao_UC u = new Frm_Demonstracao_UC();
            u.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Demonstracao Key" + ControleDemonstracao;
            tb.Text = "Demonstracao Key" + ControleDemonstracao;
            tb.ImageIndex = 0;
            tb.Controls.Add(u);
            Tbc_Aplicacoes.TabPages.Add(tb);
        }

        private void helloWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleHelloWorld++;
            Frm_HelloWorld_UC u = new Frm_HelloWorld_UC();
            u.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Hello World" + ControleHelloWorld;
            tb.Text = "Hello World" + ControleHelloWorld;
            tb.ImageIndex = 1;
            tb.Controls.Add(u);
            Tbc_Aplicacoes.TabPages.Add(tb);
        }

        private void máscaraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleMascara++;
            Frm_Mascara_UC u = new Frm_Mascara_UC();
            TabPage tb = new TabPage();
            tb.Name = "Mascara" + ControleMascara;
            tb.Text = "Mascara" + ControleMascara;
            tb.ImageIndex = 2;
            tb.Controls.Add(u);
            Tbc_Aplicacoes.TabPages.Add(tb);
        }

        private void validaCPFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleValidaCPF++;
            Frm_ValidaCPF_UC u = new Frm_ValidaCPF_UC();
            u.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Valida CPF" + ControleValidaCPF;
            tb.Text = "Valida CPF" + ControleValidaCPF;
            tb.ImageIndex = 3;
            tb.Controls.Add(u);
            Tbc_Aplicacoes.TabPages.Add(tb);
        }

        private void validaCPF2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleValidaCPF2++;
            Frm_ValidaCPF2_UC u = new Frm_ValidaCPF2_UC();
            u.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Valida CPF2" + ControleValidaCPF2;
            tb.Text = "Valida CPF2" + ControleValidaCPF2;
            tb.ImageIndex = 4;
            tb.Controls.Add(u);
            Tbc_Aplicacoes.TabPages.Add(tb);
        }

        private void validaSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControleValidaSenha++;
            Frm_ValidaSenha_UC u = new Frm_ValidaSenha_UC();
            u.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Valida Senha" + ControleValidaSenha;
            tb.Text = "Valida Senha" + ControleValidaSenha;
            tb.ImageIndex = 5;
            tb.Controls.Add(u);
            Tbc_Aplicacoes.TabPages.Add(tb);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ControleCadastroClientes != 0)
            {
                MessageBox.Show("Cadastro já está aberto.", "Bytebank", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ControleCadastroClientes++;
            Frm_CadastroCliente_UC u = new Frm_CadastroCliente_UC();
            u.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Cadastro de Clientes";
            tb.Text = "Cadastro de Clientes";
            tb.ImageIndex = 7;
            tb.Controls.Add(u);
            Tbc_Aplicacoes.TabPages.Add(tb);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Frm_Principal_Menu_Load(object sender, EventArgs e)
        {

        }

        private void apagarAbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(Tbc_Aplicacoes.SelectedTab == null))
            {
                ApagaAba(Tbc_Aplicacoes.SelectedTab);
            }
        }

        private void Tbc_Aplicacoes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void abrirImagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog db = new OpenFileDialog();
            db.InitialDirectory = "C:\\Users\\math0\\source\\repos\\Curso - WindowsForms\\CursoWindowsForms0\\CursoWindowsForms0\\Assets";
            db.Filter = "PNG|*.PNG";
            db.Title = "Escolha a imagem";
            if (db.ShowDialog() == DialogResult.OK)
            {
                string nomeArquivoImagem = db.FileName;
                ControleArquivoImagem++;
                Frm_ArquivoImagem_UC u = new Frm_ArquivoImagem_UC(nomeArquivoImagem);
                u.Dock = DockStyle.Fill;
                TabPage tb = new TabPage();
                tb.Name = "Arquivo Imagem" + ControleArquivoImagem;
                tb.Text = "Arquivo Imagem" + ControleArquivoImagem;
                tb.ImageIndex = 6;
                tb.Controls.Add(u);
                Tbc_Aplicacoes.TabPages.Add(tb);
            }   
        }

        private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Login f = new Frm_Login();
            f.ShowDialog();
            if (f.DialogResult != DialogResult.OK)
            {
                return;
            }
            string senha = f.senha;
            string login = f.login;

            if (!Cls_Utils.ValidaSenha(senha))
            {
                MessageBox.Show($"Senha incorreta.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            novoToolStripMenuItem.Enabled = true;
            apagarAbaToolStripMenuItem.Enabled = true;
            abrirImagemToolStripMenuItem.Enabled = true;
            desconectarToolStripMenuItem.Enabled = true;
            cadastrosToolStripMenuItem.Enabled = true;
            conectarToolStripMenuItem.Enabled = false;
            MessageBox.Show($"Boas vindas, {login}.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void desconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Questao q = new Frm_Questao("Frm_Questao","Deseja se desconectar?");
            q.ShowDialog();
            if (q.DialogResult != DialogResult.Yes)
            {
                return;
            }

            //if (!(Tbc_Aplicacoes.SelectedTab == null))
            //{
            //    Tbc_Aplicacoes.TabPages.Remove(Tbc_Aplicacoes.SelectedTab);
            //}
            for (int i = Tbc_Aplicacoes.TabPages.Count - 1; i >= 0; i--)
            {
                ApagaAba(Tbc_Aplicacoes.TabPages[1]);
            }
            MessageBox.Show($"Até mais.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.None);
            novoToolStripMenuItem.Enabled = false;
            apagarAbaToolStripMenuItem.Enabled = false;
            abrirImagemToolStripMenuItem.Enabled = false;
            desconectarToolStripMenuItem.Enabled = false;
            cadastrosToolStripMenuItem.Enabled = false;
            conectarToolStripMenuItem.Enabled = true;
        }

        private void Frm_Principal_Menu_UC_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Tbc_Aplicacoes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var ContextMenu = new ContextMenuStrip();
                var vToolTip001 = DesenhaItemMenu("Apagar esta aba", "DeleteTab");
                var vToolTip002 = DesenhaItemMenu("Apagar todas as abas a esquerda", "DeleteLeft");
                var vToolTip003 = DesenhaItemMenu("Apagar todas as abas a direita", "DeleteRight");
                var vToolTip004 = DesenhaItemMenu("Apagar todas, menos esta", "DeleteAll");
                ContextMenu.Items.Add(vToolTip001);
                ContextMenu.Items.Add(vToolTip002);
                ContextMenu.Items.Add(vToolTip003);
                ContextMenu.Items.Add(vToolTip004);
                ContextMenu.Show(this, new Point(e.X, e.Y));
                vToolTip001.Click += new EventHandler(vToolTip001_Click);
                vToolTip002.Click += new EventHandler(vToolTip002_Click);
                vToolTip003.Click += new EventHandler(vToolTip003_Click);
                vToolTip004.Click += new EventHandler(vToolTip004_Click);
            }
        }
        void vToolTip001_Click(object sender1, EventArgs e1)
        {
            if (!(Tbc_Aplicacoes.SelectedTab == null))
            {
                ApagaAba(Tbc_Aplicacoes.SelectedTab);
            }
        }

        void vToolTip002_Click(object sender1, EventArgs e1)
        {
            if (Tbc_Aplicacoes.SelectedTab == null) return;
            RemoveLeft();
        }

        void vToolTip003_Click(object sender1, EventArgs e1)
        {
            if (Tbc_Aplicacoes.SelectedTab == null) return;
            RemoveRight();
        }
        void vToolTip004_Click(object sender1, EventArgs e1)
        {
            if (Tbc_Aplicacoes.SelectedTab == null) return;
            RemoveLeft();
            RemoveRight();
        }

        ToolStripMenuItem DesenhaItemMenu(string text, string nomeImagem)
        {
            var vTooltip = new ToolStripMenuItem();
            Image MyImage = (Image)global::CursoWindowsForms0.Properties.Resources.ResourceManager.GetObject(nomeImagem);
            vTooltip.Image = MyImage;
            vTooltip.Text = text;
            return vTooltip;
        }

        void RemoveLeft()
        {
            for (int i = Tbc_Aplicacoes.SelectedIndex - 1; i >= 0; i += -1)
            {
                ApagaAba(Tbc_Aplicacoes.TabPages[i]);
            }
        }

        void RemoveRight()
        {
            for (int i = Tbc_Aplicacoes.TabPages.Count - 1; i > Tbc_Aplicacoes.SelectedIndex; i += -1)
            {
                ApagaAba(Tbc_Aplicacoes.TabPages[i]);
            }
        }

        void ApagaAba(TabPage TB)
        {
            if (TB.Name == "Cadastro de Clientes")
            {
                ControleCadastroClientes = 0;
            }
            Tbc_Aplicacoes.TabPages.Remove(TB);
        }
    }
}
