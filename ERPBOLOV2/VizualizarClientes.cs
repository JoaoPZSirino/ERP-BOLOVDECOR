using System;
using System.Linq;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class VizualizarClientes : Form
    {
        public VizualizarClientes()
        {
            InitializeComponent();
            Load += VizualizarClientes_Load;
        }

        private void VizualizarClientes_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = CadastrarCliente.Clientes.Select(c => new
            {
                c.Nome,
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
    }
}
