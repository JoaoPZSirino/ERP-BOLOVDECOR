using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class CadastroAssessor : Form
    {
        // repositório em memória idêntico ao usado em CadastrarCliente
        public static List<Assessor> Assessores = new List<Assessor>
        {
            new Assessor { Nome = "Carlos Almeida", Endereco = "Rua das Flores, 123", Celular = "(11) 91234-0001" },
            new Assessor { Nome = "Mariana Souza", Endereco = "Av. Brasil, 45", Celular = "(21) 99876-0002" },
            new Assessor { Nome = "Roberto Lima", Endereco = "Praça Central, 10", Celular = "(31) 97777-0003" },
            new Assessor { Nome = "Fernanda Gomes", Endereco = "Alameda das Acácias, 8", Celular = "(41) 96666-0004" },
            new Assessor { Nome = "Luiz Pereira", Endereco = "Travessa do Sol, 50", Celular = "(51) 95555-0005" }
        };

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
