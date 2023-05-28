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
    public partial class Frm_MenuFlutuante : Form
    {
        public Frm_MenuFlutuante()
        {
            InitializeComponent();
        }

        private void Frm_MenuFlutuante_MouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show($"O botão direito foi presssionado. A posição relativa foi X: {Mouse_X} Y: {Mouse_Y}");
            if (e.Button == MouseButtons.Right)
            {
                var ContextMenu = new ContextMenuStrip();
                var vToolTip001 = DesenhaItemMenu("Item 1", "key");
                var vToolTip002 = DesenhaItemMenu("Item 2", "Frm_ValidaSenha");
                ContextMenu.Items.Add(vToolTip001);
                ContextMenu.Items.Add(vToolTip002);
                ContextMenu.Show(this, new Point(e.X, e.Y));
                vToolTip001.Click += new EventHandler(vToolTip001_Click);
                vToolTip002.Click += new EventHandler(vToolTip002_Click);
            }
                
             void vToolTip001_Click(object sender1, EventArgs e1)
            {
                MessageBox.Show("Opção 001");
            }

            void vToolTip002_Click(object sender1, EventArgs e1)
            {
                MessageBox.Show("Opção 002");
            }

            ToolStripMenuItem DesenhaItemMenu(string text, string nomeImagem)
            {
                var vTooltip = new ToolStripMenuItem();
                Image MyImage = (Image)global::CursoWindowsForms0.Properties.Resources.ResourceManager.GetObject(nomeImagem);
                vTooltip.Image = MyImage;
                vTooltip.Text = text;
                return vTooltip;
            }
        }

        private void Frm_MenuFlutuante_Load(object sender, EventArgs e)
        {

        }
    }
}
