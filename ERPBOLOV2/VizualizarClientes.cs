using System;
using System.Linq;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class VizualizarClientes : Form
    {
        private readonly ClienteDAO _dao = new ClienteDAO();
        public VizualizarClientes()
        {
            InitializeComponent();
            Load += VizualizarClientes_Load;
        }

        private void VizualizarClientes_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void AtualizarGrid(string filtroNome = null)
        {
            dgvClientes.DataSource = null;

            var clientes = string.IsNullOrWhiteSpace(filtroNome)
                ? _dao.ObterTodosClientes()
                : _dao.ObterClientesPorNome(filtroNome);

            dgvClientes.DataSource = clientes.Select(c => new
            {
                c.Nome,
                c.Celular,
                c.Nacionalidade,
                c.EstadoCivil,
                c.Profissao,
                c.Endereco,
                c.CEP,
                c.CidadeEstado,
                c.RG,
                c.CPF,
                c.Email
            }).ToList();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var frm = new CadastrarCliente();
            frm.ClienteAdicionado += (s, ev) => AtualizarGrid();
            frm.ShowDialog(this);
        }

        private void buttonFiltroNome_Click(object sender, EventArgs e)
        {
            //Ligar txtFiltroNome.keyDown para filtrar ao pressinonar buttonFiltroNome
            var txt = txtFiltroNome.Text;
            AtualizarGrid(txt);
        }
    }
}
