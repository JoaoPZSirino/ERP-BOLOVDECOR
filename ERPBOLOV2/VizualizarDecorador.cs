using ERPBOLOV2.DAO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class VizualizarDecorador : Form
    {
        private readonly DecoradorDAO _dao = new DecoradorDAO();

        public VizualizarDecorador()
        {
            InitializeComponent();
            Load += VizualizarDecorador_Load;
        }

        private void VizualizarDecorador_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void AtualizarGrid(string filtroNome = null)
        {
            dgvDecoradores.DataSource = null;

            var Decoradores = string.IsNullOrWhiteSpace(filtroNome)
                ? _dao.ObterTodosDecoradores()
                : _dao.ObterDecoradoresPorNome(filtroNome);

            dgvDecoradores.DataSource = Decoradores.Select(d => new
            {
                d.Id,
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

        private void buttonFiltrarPorNome_Click(object sender, EventArgs e)
        {
            var txt = txtFiltroNome.Text;
            AtualizarGrid(txt);
        }

        private void VizualizarDecorador_Load_1(object sender, EventArgs e)
        {

        }
    }
}
