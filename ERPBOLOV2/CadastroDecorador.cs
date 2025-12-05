using ERPBOLOV2.DAO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class CadastroDecorador : Form
    {
        public static List<Decorador> Decoradores = new List<Decorador>
        {
            new Decorador { Nome = "Studio Festa", Endereco = "Rua das Festas, 12", Celular = "(11) 91111-0001" },
            new Decorador { Nome = "DecoraBem", Endereco = "Av. Alegria, 100", Celular = "(21) 92222-0002" },
            new Decorador { Nome = "Eventos & Cia", Endereco = "Praça do Evento, 5", Celular = "(31) 93333-0003" },
            new Decorador { Nome = "Arco Iris Decorações", Endereco = "Alameda Flores, 8", Celular = "(41) 94444-0004" },
            new Decorador { Nome = "Festas & Sonhos", Endereco = "Travessa Alegre, 50", Celular = "(51) 95555-0005" }
        };

        public event EventHandler DecoradorAdicionado;

        private readonly DecoradorDAO _dao = new DecoradorDAO();


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

            _dao.AdicionarDecorador(d);

            MessageBox.Show("Decorador salvo com sucesso.", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
