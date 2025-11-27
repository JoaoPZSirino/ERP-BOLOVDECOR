using System;
using System.Linq;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtualizarListaDoDia(monthCalendar1.SelectionStart);
            AtualizarDiasComLocacao();
        }

        //Menu Clientes
        private void visualizarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VizualizarClientes();
            frm.ShowDialog(this);
        }

        private void cadastrarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new CadastrarCliente();
            frm.ShowDialog(this);
        }

        //Menu Produtos

        private void visualizarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VizualizarProduto();
            frm.ShowDialog(this);
        }

        private void cadastrarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new CadastrarProduto();
            frm.ShowDialog(this);
        }

        //Menu Assessores

        private void visualizarAssessoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VizualizarAssessor();
            frm.ShowDialog(this);
        }

        private void cadastrarAcessoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new CadastroAssessor();
            frm.ShowDialog(this);
        }

        //Menu Decoradores

        private void visualizarDecoradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VizualizarDecorador();
            frm.ShowDialog(this);
        }

        private void cadastrarDecoradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new CadastroDecorador();
            frm.ShowDialog(this);
        }

        //Menu Locais

        private void visualizarLocaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VizualizarLocal();
            frm.ShowDialog(this);
        }
        
        private void cadastrarLocaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new CadastroLocal();
            frm.ShowDialog(this);
        }

        //Botão Gerar Contrato

        private void btnGerarContrato_Click(object sender, EventArgs e)
        {
            var frm = new GerarContrato();
            frm.ShowDialog(this);
        }

        private void vizualizarLocaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VizualizarLocacao();
            frm.ShowDialog(this);
        }

        private void cadastrarLocaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new CadastrarLocacao();
            frm.LocacaoAdicionada += (s, ev) => { AtualizarListaDoDia(monthCalendar1.SelectionStart); AtualizarDiasComLocacao(); };
            frm.ShowDialog(this);
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            AtualizarListaDoDia(e.Start);
        }

        private void AtualizarListaDoDia(DateTime data)
        {
            lstLocacoes.Items.Clear();
            var encontrados = CadastrarLocacao.Locacoes.Where(l => l.DataEvento.Date == data.Date).OrderBy(l => l.HorarioEvento);
            foreach (var l in encontrados)
            {
                var horario = l.HorarioEvento.ToString(@"hh\:mm");
                var texto = $"{horario} - {l.Cliente?.Nome ?? "(Sem Cliente)"} - {l.LocalEvento?.Nome ?? "(Sem Local)"} - {l.ProdutoBolo?.Codigo ?? l.Produto?.Codigo ?? "(Sem Produto)"}";
                lstLocacoes.Items.Add(new ListItemForLocacao { LocacaoId = l.Id, Text = texto });
            }

            // atualizar dias com locações (mantém calendário sinalizando dias válidos)
            AtualizarDiasComLocacao();
        }

        private void AtualizarDiasComLocacao()
        {
            // Remove all existing bolded dates and add the dates that have locacoes
            try
            {
                monthCalendar1.RemoveAllBoldedDates();
            }
            catch
            {
                // ignore if not supported
            }

            var datas = CadastrarLocacao.Locacoes.Select(l => l.DataEvento.Date).Distinct();
            foreach (var d in datas)
            {
                try
                {
                    monthCalendar1.AddBoldedDate(d);
                }
                catch
                {
                    // ignore invalid dates
                }
            }
            try
            {
                monthCalendar1.UpdateBoldedDates();
            }
            catch
            {
                // ignore
            }
        }

        private void lstLocacoes_DoubleClick(object sender, EventArgs e)
        {
            if (lstLocacoes.SelectedItem is ListItemForLocacao item)
            {
                var loc = CadastrarLocacao.Locacoes.FirstOrDefault(x => x.Id == item.LocacaoId);
                if (loc != null)
                {
                    var frm = new CadastrarLocacao(loc);
                    frm.LocacaoAdicionada += (s, ev) => AtualizarListaDoDia(monthCalendar1.SelectionStart);
                    frm.ShowDialog(this);
                }
            }
        }

        // helper class to store id + text in ListBox
        private class ListItemForLocacao
        {
            public int LocacaoId { get; set; }
            public string Text { get; set; }
            public override string ToString() => Text;
        }
    }
}
