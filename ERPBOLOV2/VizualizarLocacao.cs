using System;
using System.Linq;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class VizualizarLocacao : Form
    {
        public VizualizarLocacao()
        {
            InitializeComponent();
            Load += VizualizarLocacao_Load;
        }

        private void VizualizarLocacao_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            dgvLocacoes.DataSource = null;
            dgvLocacoes.DataSource = CadastrarLocacao.Locacoes.Select(l => new
            {
                l.Id,
                DataEvento = l.DataEvento.ToString("yyyy-MM-dd"),
                Horario = l.HorarioEvento.ToString(),
                Cliente = l.Cliente?.Nome,
                Assessor = l.Assessor?.Nome,
                Decorador = l.Decorador?.Nome,
                Local = l.LocalEvento?.Nome,
                Produto = l.Produto?.Codigo,
                ValorTotal = l.ValorTotal,
                Pronto = l.EstaPronto,
                Entregue = l.FoiEntregue,
                Devolvido = l.FoiDevolvido
            }).ToList();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var frm = new CadastrarLocacao();
            frm.LocacaoAdicionada += (s, ev) => AtualizarGrid();
            frm.ShowDialog(this);
        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            if (dgvLocacoes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma locação primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var id = (int)dgvLocacoes.SelectedRows[0].Cells["Id"].Value;
            var loc = CadastrarLocacao.Locacoes.FirstOrDefault(x => x.Id == id);
            if (loc == null) return;

            // Abrir o formulário de cadastro no modo edição
            var frm = new CadastrarLocacao(loc);
            frm.LocacaoAdicionada += (s, ev) => AtualizarGrid();
            frm.ShowDialog(this);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvLocacoes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma locação para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var id = (int)dgvLocacoes.SelectedRows[0].Cells["Id"].Value;
            var loc = CadastrarLocacao.Locacoes.FirstOrDefault(x => x.Id == id);
            if (loc == null) return;

            var res = MessageBox.Show("Deseja realmente excluir esta locação?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                CadastrarLocacao.Locacoes.Remove(loc);
                AtualizarGrid();
            }
        }
    }
}
