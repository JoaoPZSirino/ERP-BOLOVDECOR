using System;
using System.Linq;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class VizualizarDecorador : Form
    {
        public VizualizarDecorador()
        {
            InitializeComponent();
            Load += VizualizarDecorador_Load;
        }

        private void VizualizarDecorador_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            dgvDecoradores.DataSource = null;
            dgvDecoradores.DataSource = CadastroDecorador.Decoradores.Select(d => new
            {
                d.Nome,
                d.Endereco,
                d.Celular
            }).ToList();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var frm = new CadastroDecorador();
            frm.DecoradorAdicionado += (s, ev) => AtualizarGrid();
            frm.ShowDialog(this);
        }
    }
}
