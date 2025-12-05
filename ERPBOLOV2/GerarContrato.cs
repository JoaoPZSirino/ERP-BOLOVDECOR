using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ERPBOLOV2
{
    public partial class GerarContrato : Form
    {
        public GerarContrato()
        {
            InitializeComponent();
            // Vincula o evento Load manualmente se não estiver pelo Designer
            this.Load += new EventHandler(this.ContratoLocacao_Load);
        }

        private void ContratoLocacao_Load(object sender, EventArgs e)
        {
            // 1. Inicializa listas se estiverem nulas (Evita erro ao abrir)
            if (CadastrarCliente.Clientes == null) CadastrarCliente.Clientes = new List<Cliente>();
            if (CadastrarProduto.Produtos == null) CadastrarProduto.Produtos = new List<Produto>();
            if (CadastroLocal.Locais == null) CadastroLocal.Locais = new List<Local>();
            if (CadastroAssessor.Assessores == null) CadastroAssessor.Assessores = new List<Assessor>();
            if (CadastroDecorador.Decoradores == null) CadastroDecorador.Decoradores = new List<Decorador>();

            // 2. Preenche os ComboBoxes
            cmbCliente.Items.Clear();
            foreach (var c in CadastrarCliente.Clientes) cmbCliente.Items.Add(c.Nome);

            clbProdutos.Items.Clear();
            foreach (var p in CadastrarProduto.Produtos) clbProdutos.Items.Add($"{p.Codigo} - {p.Modelo} - R${p.ValorLocacao}");

            cmbLocal.Items.Clear();
            foreach (var l in CadastroLocal.Locais) cmbLocal.Items.Add(l.Nome);

            cmbAssessor.Items.Clear();
            foreach (var a in CadastroAssessor.Assessores) cmbAssessor.Items.Add(a.Nome);

            cmbDecorador.Items.Clear();
            foreach (var d in CadastroDecorador.Decoradores) cmbDecorador.Items.Add(d.Nome);

            cmbFormaPagamento.Items.Clear();
            cmbFormaPagamento.Items.AddRange(new object[] { "Pix", "Dinheiro", "Cartão" });

            AtualizarValorTotal();
        }

        private void clbProdutos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Atualiza o valor total logo após marcar/desmarcar
            this.BeginInvoke(new Action(() => AtualizarValorTotal()));
        }

        private void AtualizarValorTotal()
        {
            decimal total = 0m;
            for (int i = 0; i < clbProdutos.Items.Count; i++)
            {
                if (clbProdutos.GetItemChecked(i))
                {
                    // Tenta ler o valor da string "COD - NOME - R$VALOR"
                    var text = clbProdutos.Items[i].ToString();
                    var parts = text.Split(new[] { '-' }, 3);
                    if (parts.Length == 3)
                    {
                        var valPart = parts[2].Trim();
                        if (valPart.StartsWith("R$"))
                        {
                            if (decimal.TryParse(valPart.Substring(2), out decimal v))
                                total += v;
                        }
                    }
                }
            }
            lblValorTotal.Text = $"R${total:0.00}";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // 1. Validação Básica
            if (cmbCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um cliente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Contrato con = new Contrato();

                // 2. Preenchimento dos Objetos (Usando os nomes NOVOS da classe Contrato)
                string nomeCli = cmbCliente.SelectedItem.ToString();
                con.Cliente = CadastrarCliente.Clientes.FirstOrDefault(c => c.Nome == nomeCli);

                if (cmbLocal.SelectedIndex != -1)
                    con.Local = CadastroLocal.Locais.FirstOrDefault(l => l.Nome == cmbLocal.SelectedItem.ToString());

                if (cmbAssessor.SelectedIndex != -1)
                    con.Assessor = CadastroAssessor.Assessores.FirstOrDefault(a => a.Nome == cmbAssessor.SelectedItem.ToString());

                if (cmbDecorador.SelectedIndex != -1)
                    con.Decorador = CadastroDecorador.Decoradores.FirstOrDefault(d => d.Nome == cmbDecorador.SelectedItem.ToString());

                // 3. Preenchimento de Datas e Texto
                con.DataEvento = dtpData.Value.Date;
                con.HoraEvento = dtpHorario.Value.TimeOfDay;
                con.TipoFesta = txtTipoFesta.Text;
                con.Anfitriao = txtAnfitriao.Text;

                // 4. Produtos e Lógica de Valores
                con.ValorTotal = 0;
                foreach (var item in clbProdutos.CheckedItems)
                {
                    string s = item.ToString();
                    var parts = s.Split('-');
                    if (parts.Length > 0)
                    {
                        var cod = parts[0].Trim();
                        var prod = CadastrarProduto.Produtos.FirstOrDefault(p => p.Codigo == cod);
                        if (prod != null)
                        {
                            con.Produtos.Add(prod); // Nome novo: Produtos
                            con.ValorTotal += prod.ValorLocacao;

                            // Gera string de reposição (Valor x5)
                            con.ItensReposicao.Add($"{prod.Modelo}: R$ {(prod.ValorLocacao * 5):N2}");
                        }
                    }
                }

                // 5. Configuração Financeira Automática
                con.ValorEntrada = con.ValorTotal / 2;
                con.ValorRestante = con.ValorTotal / 2;
                // Regra: Entrada daqui 7 dias, Restante 7 dias antes da festa
                con.DataEntrada = DateTime.Now.AddDays(7);
                con.DataRestante = con.DataEvento.AddDays(-7);

                // Texto placeholder (ideal seria uma função de número por extenso)
                con.ValorPorExtenso = "(valor por extenso)";

                // Lógica de Logística (baseado num checkbox se você tiver, ou padrão)
                // con.ClienteRetira = chkRetira.Checked; 
                con.ClienteRetira = false; // Padrão entrega

                // 6. Geração do Arquivo PDF
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF Files|*.pdf";
                    // Nome do arquivo seguro
                    string nomeArquivo = con.Cliente?.Nome ?? "Contrato";
                    sfd.FileName = $"Contrato_{nomeArquivo}_{DateTime.Now:yyyyMMdd}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        var gerador = new GeradorPDF();
                        gerador.GerarArquivoPDF(con, sfd.FileName);
                        MessageBox.Show("Contrato gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar contrato: {ex.Message}\n\nDetalhes: {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eventos vazios que podem ter sobrado do designer (para não dar erro de compilação se o designer chamar)
        private void lblValorTotal_Click(object sender, EventArgs e) { }
        private void GerarContrato_Load(object sender, EventArgs e) { }
    }
}