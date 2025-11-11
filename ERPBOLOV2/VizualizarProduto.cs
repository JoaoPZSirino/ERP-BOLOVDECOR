using System;
using System.Linq;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class VizualizarProduto : Form
    {
        public VizualizarProduto()
        {
            InitializeComponent();
            Load += VizualizarProduto_Load;
        }

        private void VizualizarProduto_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            dgvProdutos.DataSource = null;
            dgvProdutos.DataSource = CadastrarProduto.Produtos.Select(p => new
            {
                p.Codigo,
                p.Modelo,
                p.Cor,
                Altura = p.Altura,
                Topo = p.Topo,
                Base = p.Base,
                ValorLocacao = p.ValorLocacao
            }).ToList();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var frm = new CadastrarProduto();
            frm.ProdutoAdicionado += (s, ev) => AtualizarGrid();
            frm.ShowDialog(this);
        }
    }
}
