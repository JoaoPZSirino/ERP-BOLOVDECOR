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
    public partial class CadastrarCliente : Form
    {
        public static List<Cliente> Clientes = new List<Cliente>
        {
            new Cliente { Nome = "João Silva", Nacionalidade = "Brasileiro", EstadoCivil = "Solteiro", Profissao = "Engenheiro", Endereco = "Rua A, 123", CEP = "01000-000", CidadeEstado = "São Paulo/SP", RG = "12.345.678-9", CPF = "123.456.789-00", Email = "joao.silva@example.com" },
            new Cliente { Nome = "Maria Oliveira", Nacionalidade = "Brasileira", EstadoCivil = "Casada", Profissao = "Médica", Endereco = "Av. B, 456", CEP = "02000-000", CidadeEstado = "Rio de Janeiro/RJ", RG = "98.765.432-1", CPF = "987.654.321-00", Email = "maria.oliveira@example.com" },
            new Cliente { Nome = "Carlos Pereira", Nacionalidade = "Brasileiro", EstadoCivil = "Divorciado", Profissao = "Professor", Endereco = "Travessa C, 789", CEP = "03000-000", CidadeEstado = "Belo Horizonte/MG", RG = "11.222.333-4", CPF = "111.222.333-44", Email = "carlos.pereira@example.com" },
            new Cliente { Nome = "Ana Souza", Nacionalidade = "Portuguesa", EstadoCivil = "Solteira", Profissao = "Advogada", Endereco = "Praça D, 10", CEP = "04000-000", CidadeEstado = "Porto Alegre/RS", RG = "22.333.444-5", CPF = "222.333.444-55", Email = "ana.souza@example.com" },
            new Cliente { Nome = "Pedro Gomes", Nacionalidade = "Brasileiro", EstadoCivil = "Viúvo", Profissao = "Analista", Endereco = "Alameda E, 50", CEP = "05000-000", CidadeEstado = "Curitiba/PR", RG = "33.444.555-6", CPF = "333.444.555-66", Email = "pedro.gomes@example.com" }
        };

        public event EventHandler ClienteAdicionado;

        private readonly ClienteDAO _dao = new ClienteDAO();


        public CadastrarCliente()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var c = new Cliente
            {
                Nome = txtNome.Text,
                Nacionalidade = txtNacionalidade.Text,
                EstadoCivil = txtEstadoCivil.Text,
                Profissao = txtProfissao.Text,
                Endereco = txtEndereco.Text,
                CEP = txtCEP.Text,
                CidadeEstado = txtCidadeEstado.Text,
                RG = txtRG.Text,
                CPF = txtCPF.Text,
                Email = txtEmail.Text,
                Celular = txtCelular.Text,
            };

            _dao.AdicionarCliente(c);

            MessageBox.Show("Cliente salvo com sucesso.", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
