using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class CadastroDecorador : Form
    {
        public static List<Decorador> Decoradores = new List<Decorador>();

        public event EventHandler DecoradorAdicionado;

        public CadastroDecorador()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var d = new Decorador
            {
                Nome = txtNome.Text,
                Endereco = txtEndereco.Text,
                Celular = txtCelular.Text
            };

            Decoradores.Add(d);
            DecoradorAdicionado?.Invoke(this, EventArgs.Empty);

            MessageBox.Show("Decorador salvo com sucesso.", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
