using ERPBOLOV2.DAO;
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
        private readonly LocalDAO _dao = new LocalDAO();

        public static List<Local> Locais = new List<Local>
        {
            new Local { Nome = "Salão Primavera", Endereco = "Rua das Flores, 200", Celular = "(11) 90000-0001" },
            new Local { Nome = "Buffet Alegra", Endereco = "Av. das Palmeiras, 150", Celular = "(21) 90000-0002" },
            new Local { Nome = "Espaço Central", Endereco = "Praça Central, 10", Celular = "(31) 90000-0003" },
            new Local { Nome = "Chácara Verde", Endereco = "Estrada da Serra, 50", Celular = "(41) 90000-0004" },
            new Local { Nome = "Casa de Festas Ouro", Endereco = "Travessa do Ouro, 5", Celular = "(51) 90000-0005" }
        };

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

            _dao.AdicionarLocal(l);

            MessageBox.Show("Local salvo com sucesso.", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
