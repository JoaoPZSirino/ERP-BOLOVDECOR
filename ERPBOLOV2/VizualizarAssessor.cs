using System;
using System.Linq;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class VizualizarAssessor : Form
    {
        public VizualizarAssessor()
        {
            InitializeComponent();
            Load += VizualizarAssessor_Load;
        }

        private void VizualizarAssessor_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            dgvAssessores.DataSource = null;
            dgvAssessores.DataSource = CadastroAssessor.Assessores.Select(a => new
            {
                a.Nome,
                a.Endereco,
                a.Celular
            }).ToList();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var frm = new CadastroAssessor();
            frm.AssessorAdicionado += (s, ev) => AtualizarGrid();
            frm.ShowDialog(this);
        }
    }
}
