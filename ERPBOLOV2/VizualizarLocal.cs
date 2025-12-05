using ERPBOLOV2.DAO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class VizualizarLocal : Form
    {
        private readonly LocalDAO _dao = new LocalDAO();

        public VizualizarLocal()
        {
            InitializeComponent();
            Load += VizualizarLocal_Load;
        }

        private void VizualizarLocal_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void AtualizarGrid(string filtroPorNome = null)
        {
            dgvLocais.DataSource = null;

            var Locais = string.IsNullOrEmpty(filtroPorNome)
                ? _dao.ObterTodosLocais()
                : _dao.FiltrarLocaisPorNome(filtroPorNome);


            dgvLocais.DataSource = Locais.Select(l => new
            {
                l.Id,
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
