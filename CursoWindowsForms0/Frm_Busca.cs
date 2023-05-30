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
    public partial class Frm_Busca : Form
    {
        List<List<string>> _listaBusca = new List<List<string>>();
        public string IdSelected { get; set; }
        public Frm_Busca(List<List<string>> listaBusca)
        {
            InitializeComponent();
            _listaBusca = listaBusca;
            this.Text = "Busca";
            Tls_Principal.Items[0].Text = "Salvar seleção";
            Tls_Principal.Items[1].Text = "Apagar seleção";
            PreencherLista();
            Lsb_Busca.Sorted = true;

        }

        void PreencherLista()
        {
            Lsb_Busca.Items.Clear();

            foreach (var i in _listaBusca)
            {
                ItemBox X = new ItemBox();
                X.Id = i[0];
                X.Nome = i[1];
                Lsb_Busca.Items.Add(X);
            }
        }

        private void ApagatoolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void salvarToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            ItemBox i = (ItemBox)Lsb_Busca.Items[Lsb_Busca.SelectedIndex];
            IdSelected = i.Id;
            this.Close();
        }

        class ItemBox
        {
            public string Id { get; set; }
            public string Nome { get; set; }

            public override string ToString()
            {
                return Nome;
            }
        }
    }
}
