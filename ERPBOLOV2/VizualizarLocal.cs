using System;
using System.Linq;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class VizualizarLocal : Form
    {
        public VizualizarLocal()
        {
            InitializeComponent();
            Load += VizualizarLocal_Load;
        }

        private void VizualizarLocal_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            dgvLocais.DataSource = null;
            dgvLocais.DataSource = CadastroLocal.Locais.Select(l => new
            {
                l.Nome,
                l.Endereco,
                l.Celular
            }).ToList();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var frm = new CadastroLocal();
            frm.LocalAdicionado += (s, ev) => AtualizarGrid();
            frm.ShowDialog(this);
        }
    }
}
