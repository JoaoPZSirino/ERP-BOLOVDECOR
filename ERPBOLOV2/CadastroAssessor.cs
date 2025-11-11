using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class CadastroAssessor : Form
    {
        // repositório em memória idêntico ao usado em CadastrarCliente
        public static List<Assessor> Assessores = new List<Assessor>();

        public event EventHandler AssessorAdicionado;

        public CadastroAssessor()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var a = new Assessor
            {
                Nome = txtNome.Text,
                Endereco = txtEndereco.Text,
                Celular = txtCelular.Text
            };

            Assessores.Add(a);
            AssessorAdicionado?.Invoke(this, EventArgs.Empty);

            MessageBox.Show("Assessor salvo com sucesso.", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
