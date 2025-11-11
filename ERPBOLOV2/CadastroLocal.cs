using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class CadastroLocal : Form
    {
        public static List<Local> Locais = new List<Local>();

        public event EventHandler LocalAdicionado;

        public CadastroLocal()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var l = new Local
            {
                Nome = txtNome.Text,
                Endereco = txtEndereco.Text,
                Celular = txtCelular.Text
            };

            Locais.Add(l);
            LocalAdicionado?.Invoke(this, EventArgs.Empty);

            MessageBox.Show("Local salvo com sucesso.", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
