using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class CadastrarLocacao : Form
    {
        // Repositório em memória para locações
        public static List<Locacao> Locacoes = new List<Locacao>();

        public event EventHandler LocacaoAdicionada;

        private Locacao editingLoc;
        private bool isEditing = false;

        public CadastrarLocacao()
        {
            InitializeComponent();
            Load += CadastrarLocacao_Load;
        }

        // Construtor para editar uma locação existente
        public CadastrarLocacao(Locacao loc) : this()
        {
            if (loc != null)
            {
                editingLoc = loc;
                isEditing = true;
            }
        }

        private void CadastrarLocacao_Load(object sender, EventArgs e)
        {
            CarregarCombos();

            // Se estivermos editando, preencher campos com os dados existentes
            if (editingLoc != null)
            {
                PreencherCampos(editingLoc);
            }
        }

        private void CarregarCombos()
        {
            // Clientes
            cbCliente.Items.Clear();
            foreach (var c in CadastrarCliente.Clientes)
            {
                cbCliente.Items.Add(c.Nome);
            }
            if (cbCliente.Items.Count > 0) cbCliente.SelectedIndex = 0;

            // Assessores
            cbAssessor.Items.Clear();
            foreach (var a in CadastroAssessor.Assessores)
            {
                cbAssessor.Items.Add(a.Nome);
            }
            if (cbAssessor.Items.Count > 0) cbAssessor.SelectedIndex = 0;

            // Decoradores
            cbDecorador.Items.Clear();
            foreach (var d in CadastroDecorador.Decoradores)
            {
                cbDecorador.Items.Add(d.Nome);
            }
            if (cbDecorador.Items.Count > 0) cbDecorador.SelectedIndex = 0;

            // Locais
            cbLocal.Items.Clear();
            foreach (var l in CadastroLocal.Locais)
            {
                cbLocal.Items.Add(l.Nome);
            }
            if (cbLocal.Items.Count > 0) cbLocal.SelectedIndex = 0;

            // Produtos por tipo
            PreencherProdutosPorTipo();

            // Enums
            cbTipoLogistica.Items.Clear();
            cbTipoLogistica.Items.AddRange(Enum.GetNames(typeof(TipoLogistica)));
            cbTipoLogistica.SelectedIndex = 0;

            cbFormaPagamento.Items.Clear();
            cbFormaPagamento.Items.AddRange(Enum.GetNames(typeof(FormaPagamento)));
            cbFormaPagamento.SelectedIndex = 0;

            cbCondicaoPagamento.Items.Clear();
            cbCondicaoPagamento.Items.AddRange(Enum.GetNames(typeof(CondicaoPagamento)));
            cbCondicaoPagamento.SelectedIndex = 0;

            // Atualiza valor total inicial
            AtualizarValorTotal();
        }

        private void PreencherProdutosPorTipo()
        {
            // Insert an empty option as first item to allow 'none' selection

            // Bolo
            cbBolo.Items.Clear();
            cbBolo.Items.Add(string.Empty);
            foreach (var p in CadastrarProduto.Produtos.Where(x => x.Modelo == TipoModelo.Bolo))
            {
                cbBolo.Items.Add(p.Codigo);
            }
            cbBolo.SelectedIndex = 0; // empty = none

            // Boleira
            cbBoleira.Items.Clear();
            cbBoleira.Items.Add(string.Empty);
            foreach (var p in CadastrarProduto.Produtos.Where(x => x.Modelo == TipoModelo.Boleira))
            {
                cbBoleira.Items.Add(p.Codigo);
            }
            cbBoleira.SelectedIndex = 0;

            // Topo
            cbTopo.Items.Clear();
            cbTopo.Items.Add(string.Empty);
            foreach (var p in CadastrarProduto.Produtos.Where(x => x.Modelo == TipoModelo.Topo))
            {
                cbTopo.Items.Add(p.Codigo);
            }
            cbTopo.SelectedIndex = 0;

            // Outro
            cbOutro.Items.Clear();
            cbOutro.Items.Add(string.Empty);
            foreach (var p in CadastrarProduto.Produtos.Where(x => x.Modelo == TipoModelo.Outro))
            {
                cbOutro.Items.Add(p.Codigo);
            }
            cbOutro.SelectedIndex = 0;

            // Ensure value reflects selections
            AtualizarValorTotal();
        }

        private void cbBolo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarValorTotal();
        }

        private void cbBoleira_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarValorTotal();
        }

        private void cbTopo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarValorTotal();
        }

        private void cbOutro_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarValorTotal();
        }

        private void AtualizarValorTotal()
        {
            decimal total = 0m;

            var codigoBolo = cbBolo.SelectedItem as string;
            if (!string.IsNullOrEmpty(codigoBolo))
            {
                var p = CadastrarProduto.Produtos.FirstOrDefault(x => x.Codigo == codigoBolo);
                if (p != null) total += p.ValorLocacao;
            }

            var codigoBoleira = cbBoleira.SelectedItem as string;
            if (!string.IsNullOrEmpty(codigoBoleira))
            {
                var p = CadastrarProduto.Produtos.FirstOrDefault(x => x.Codigo == codigoBoleira);
                if (p != null) total += p.ValorLocacao;
            }

            var codigoTopo = cbTopo.SelectedItem as string;
            if (!string.IsNullOrEmpty(codigoTopo))
            {
                var p = CadastrarProduto.Produtos.FirstOrDefault(x => x.Codigo == codigoTopo);
                if (p != null) total += p.ValorLocacao;
            }

            var codigoOutro = cbOutro.SelectedItem as string;
            if (!string.IsNullOrEmpty(codigoOutro))
            {
                var p = CadastrarProduto.Produtos.FirstOrDefault(x => x.Codigo == codigoOutro);
                if (p != null) total += p.ValorLocacao;
            }

            // Atualiza nudValorTotal sem disparar eventos adicionais
            try
            {
                if (total > nudValorTotal.Maximum) nudValorTotal.Maximum = decimal.Truncate(total) + 1000000m;
                nudValorTotal.Value = total;
            }
            catch
            {
                // segurança: se algo falhar, apenas ajustar para máximo
                nudValorTotal.Value = nudValorTotal.Maximum;
            }
        }

        private void PreencherCampos(Locacao loc)
        {
            dtpDataEvento.Value = loc.DataEvento;
            txtHorario.Text = loc.HorarioEvento.ToString();

            if (loc.Cliente != null)
            {
                var idx = cbCliente.Items.IndexOf(loc.Cliente.Nome);
                if (idx >= 0) cbCliente.SelectedIndex = idx;
            }

            if (loc.Assessor != null)
            {
                var idx = cbAssessor.Items.IndexOf(loc.Assessor.Nome);
                if (idx >= 0) cbAssessor.SelectedIndex = idx;
            }

            if (loc.Decorador != null)
            {
                var idx = cbDecorador.Items.IndexOf(loc.Decorador.Nome);
                if (idx >= 0) cbDecorador.SelectedIndex = idx;
            }

            if (loc.LocalEvento != null)
            {
                var idx = cbLocal.Items.IndexOf(loc.LocalEvento.Nome);
                if (idx >= 0) cbLocal.SelectedIndex = idx;
            }

            // selecionar produtos por tipo se houver (item 0 = empty)
            if (!string.IsNullOrEmpty(loc.ProdutoBolo?.Codigo))
            {
                var idx = cbBolo.Items.IndexOf(loc.ProdutoBolo.Codigo);
                if (idx >= 0) cbBolo.SelectedIndex = idx;
                else cbBolo.SelectedIndex = 0;
            }
            else
            {
                cbBolo.SelectedIndex = 0;
            }

            if (!string.IsNullOrEmpty(loc.ProdutoBoleira?.Codigo))
            {
                var idx = cbBoleira.Items.IndexOf(loc.ProdutoBoleira.Codigo);
                if (idx >= 0) cbBoleira.SelectedIndex = idx;
                else cbBoleira.SelectedIndex = 0;
            }
            else
            {
                cbBoleira.SelectedIndex = 0;
            }

            if (!string.IsNullOrEmpty(loc.ProdutoTopo?.Codigo))
            {
                var idx = cbTopo.Items.IndexOf(loc.ProdutoTopo.Codigo);
                if (idx >= 0) cbTopo.SelectedIndex = idx;
                else cbTopo.SelectedIndex = 0;
            }
            else
            {
                cbTopo.SelectedIndex = 0;
            }

            if (!string.IsNullOrEmpty(loc.ProdutoOutro?.Codigo))
            {
                var idx = cbOutro.Items.IndexOf(loc.ProdutoOutro.Codigo);
                if (idx >= 0) cbOutro.SelectedIndex = idx;
                else cbOutro.SelectedIndex = 0;
            }
            else
            {
                cbOutro.SelectedIndex = 0;
            }

            txtDescricaoBoleira.Text = loc.DescricaoBoleira;
            txtDescricaoTopo.Text = loc.DescricaoTopo;
            txtObs.Text = loc.Observacao;
            cbTipoLogistica.SelectedItem = loc.TipoLogistica.ToString();
            cbFormaPagamento.SelectedItem = loc.FormaPagamento.ToString();
            cbCondicaoPagamento.SelectedItem = loc.CondicaoPagamento.ToString();
            nudValorTotal.Value = loc.ValorTotal;
            chkPronto.Checked = loc.EstaPronto;
            chkEntregue.Checked = loc.FoiEntregue;
            chkDevolvido.Checked = loc.FoiDevolvido;
            txtResponsavelDevolucao.Text = loc.ResponsavelDevolucao;

            // recalcular total com base nas seleções atuais
            AtualizarValorTotal();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            TimeSpan horario;
            if (!TimeSpan.TryParse(txtHorario.Text, out horario))
            {
                MessageBox.Show("Horário inválido. Use o formato HH:mm.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isEditing && editingLoc != null)
            {
                // Atualiza os campos da locação existente
                editingLoc.DataEvento = dtpDataEvento.Value.Date;
                editingLoc.HorarioEvento = horario;
                editingLoc.Cliente = CadastrarCliente.Clientes.FirstOrDefault(c => c.Nome == (cbCliente.SelectedItem as string));
                editingLoc.Assessor = CadastroAssessor.Assessores.FirstOrDefault(a => a.Nome == (cbAssessor.SelectedItem as string));
                editingLoc.Decorador = CadastroDecorador.Decoradores.FirstOrDefault(d => d.Nome == (cbDecorador.SelectedItem as string));
                editingLoc.LocalEvento = CadastroLocal.Locais.FirstOrDefault(l => l.Nome == (cbLocal.SelectedItem as string));

                // mapear produtos selecionados (podem estar vazios)
                editingLoc.ProdutoBolo = CadastrarProduto.Produtos.FirstOrDefault(p => p.Codigo == (cbBolo.SelectedItem as string));
                editingLoc.ProdutoBoleira = CadastrarProduto.Produtos.FirstOrDefault(p => p.Codigo == (cbBoleira.SelectedItem as string));
                editingLoc.ProdutoTopo = CadastrarProduto.Produtos.FirstOrDefault(p => p.Codigo == (cbTopo.SelectedItem as string));
                editingLoc.ProdutoOutro = CadastrarProduto.Produtos.FirstOrDefault(p => p.Codigo == (cbOutro.SelectedItem as string));

                // manter compatibilidade: Produto aponta para ProdutoBolo se definido
                editingLoc.Produto = editingLoc.ProdutoBolo ?? editingLoc.ProdutoBoleira ?? editingLoc.ProdutoTopo ?? editingLoc.ProdutoOutro;

                editingLoc.DescricaoBoleira = txtDescricaoBoleira.Text;
                editingLoc.DescricaoTopo = txtDescricaoTopo.Text;
                editingLoc.Observacao = txtObs.Text;
                editingLoc.TipoLogistica = (TipoLogistica)Enum.Parse(typeof(TipoLogistica), cbTipoLogistica.SelectedItem as string);
                editingLoc.FormaPagamento = (FormaPagamento)Enum.Parse(typeof(FormaPagamento), cbFormaPagamento.SelectedItem as string);
                editingLoc.CondicaoPagamento = (CondicaoPagamento)Enum.Parse(typeof(CondicaoPagamento), cbCondicaoPagamento.SelectedItem as string);
                editingLoc.ValorTotal = nudValorTotal.Value;
                editingLoc.EstaPronto = chkPronto.Checked;
                editingLoc.FoiEntregue = chkEntregue.Checked;
                editingLoc.FoiDevolvido = chkDevolvido.Checked;
                editingLoc.ResponsavelDevolucao = txtResponsavelDevolucao.Text;

                LocacaoAdicionada?.Invoke(this, EventArgs.Empty);

                MessageBox.Show("Locação atualizada com sucesso.", "Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            // Criar nova locação
            var loc = new Locacao
            {
                Id = Locacoes.Count + 1,
                DataEvento = dtpDataEvento.Value.Date,
                HorarioEvento = horario,
                Cliente = CadastrarCliente.Clientes.FirstOrDefault(c => c.Nome == (cbCliente.SelectedItem as string)),
                Assessor = CadastroAssessor.Assessores.FirstOrDefault(a => a.Nome == (cbAssessor.SelectedItem as string)),
                Decorador = CadastroDecorador.Decoradores.FirstOrDefault(d => d.Nome == (cbDecorador.SelectedItem as string)),
                LocalEvento = CadastroLocal.Locais.FirstOrDefault(l => l.Nome == (cbLocal.SelectedItem as string)),

                ProdutoBolo = CadastrarProduto.Produtos.FirstOrDefault(p => p.Codigo == (cbBolo.SelectedItem as string)),
                ProdutoBoleira = CadastrarProduto.Produtos.FirstOrDefault(p => p.Codigo == (cbBoleira.SelectedItem as string)),
                ProdutoTopo = CadastrarProduto.Produtos.FirstOrDefault(p => p.Codigo == (cbTopo.SelectedItem as string)),
                ProdutoOutro = CadastrarProduto.Produtos.FirstOrDefault(p => p.Codigo == (cbOutro.SelectedItem as string)),

                // compatibilidade
                Produto = null,

                DescricaoBoleira = txtDescricaoBoleira.Text,
                DescricaoTopo = txtDescricaoTopo.Text,
                Observacao = txtObs.Text,
                TipoLogistica = (TipoLogistica)Enum.Parse(typeof(TipoLogistica), cbTipoLogistica.SelectedItem as string),
                FormaPagamento = (FormaPagamento)Enum.Parse(typeof(FormaPagamento), cbFormaPagamento.SelectedItem as string),
                CondicaoPagamento = (CondicaoPagamento)Enum.Parse(typeof(CondicaoPagamento), cbCondicaoPagamento.SelectedItem as string),
                ValorTotal = nudValorTotal.Value,
                EstaPronto = chkPronto.Checked,
                FoiEntregue = chkEntregue.Checked,
                FoiDevolvido = chkDevolvido.Checked,
                ResponsavelDevolucao = txtResponsavelDevolucao.Text
            };

            // garantir compatibilidade Produto aponta para o bolo quando houver
            loc.Produto = loc.ProdutoBolo ?? loc.ProdutoBoleira ?? loc.ProdutoTopo ?? loc.ProdutoOutro;

            Locacoes.Add(loc);
            LocacaoAdicionada?.Invoke(this, EventArgs.Empty);

            MessageBox.Show("Locação salva com sucesso.", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
