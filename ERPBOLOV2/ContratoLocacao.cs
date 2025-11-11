using System;
using System.Linq;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class ContratoLocacao : Form
    {
        public ContratoLocacao()
        {
            InitializeComponent();
            Load += ContratoLocacao_Load;
        }

        private void ContratoLocacao_Load(object sender, EventArgs e)
        {
            // carregar clientes
            cmbCliente.Items.Clear();
            foreach (var c in CadastrarCliente.Clientes)
            {
                cmbCliente.Items.Add(c.Nome);
            }

            // carregar produtos
            clbProdutos.Items.Clear();
            foreach (var p in CadastrarProduto.Produtos)
            {
                clbProdutos.Items.Add($"{p.Codigo} - {p.Modelo} - R${p.ValorLocacao}");
            }

            // carregar locais
            cmbLocal.Items.Clear();
            foreach (var l in CadastroLocal.Locais)
            {
                cmbLocal.Items.Add(l.Nome);
            }

            // carregar assessores
            cmbAssessor.Items.Clear();
            foreach (var a in CadastroAssessor.Assessores)
            {
                cmbAssessor.Items.Add(a.Nome);
            }

            // carregar decoradores
            cmbDecorador.Items.Clear();
            foreach (var d in CadastroDecorador.Decoradores)
            {
                cmbDecorador.Items.Add(d.Nome);
            }

            // forma de pagamento
            cmbFormaPagamento.Items.Clear();
            cmbFormaPagamento.Items.AddRange(new object[] { "Cartão", "PIX", "Boleto" });

            AtualizarValorTotal();
        }

        private void clbProdutos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Delay update until after item check change is applied
            this.BeginInvoke(new Action(() => AtualizarValorTotal()));
        }

        private void AtualizarValorTotal()
        {
            decimal total = 0m;
            for (int i = 0; i < clbProdutos.Items.Count; i++)
            {
                if (clbProdutos.GetItemChecked(i))
                {
                    var text = clbProdutos.Items[i].ToString();
                    // format: "Codigo - Modelo - R$Valor"
                    var parts = text.Split(new[] { '-' }, 3);
                    if (parts.Length == 3)
                    {
                        var valPart = parts[2].Trim();
                        if (valPart.StartsWith("R$"))
                        {
                            decimal v;
                            if (decimal.TryParse(valPart.Substring(2), out v))
                                total += v;
                        }
                    }
                }
            }

            lblValorTotal.Text = $"R${total:0.00}";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // criar contrato em memória (simples)
            var contrato = new
            {
                Cliente = cmbCliente.SelectedItem as string,
                Produtos = clbProdutos.CheckedItems.Cast<string>().ToArray(),
                TipoFesta = txtTipoFesta.Text,
                Anfitriao = txtAnfitriao.Text,
                Data = dtpData.Value.Date,
                Horario = dtpHorario.Value.TimeOfDay,
                Local = cmbLocal.SelectedItem as string,
                Assessor = cmbAssessor.SelectedItem as string,
                Decorador = cmbDecorador.SelectedItem as string,
                ValorTotal = lblValorTotal.Text,
                FormaPagamento = cmbFormaPagamento.SelectedItem as string
            };

            MessageBox.Show("Contrato gerado com sucesso.", "Contrato", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
