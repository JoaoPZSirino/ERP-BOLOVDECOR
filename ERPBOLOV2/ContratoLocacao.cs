using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

// Note: the PDF generation code below uses PdfSharp. Install the PdfSharp NuGet package
// in Visual Studio (Manage NuGet Packages) before building: PdfSharp (version compatible with .NET Framework 4.7.2).
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;

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
            // gather data
            var clienteNome = cmbCliente.SelectedItem as string;
            var cliente = CadastrarCliente.Clientes.FirstOrDefault(c => c.Nome == clienteNome);

            var produtosSelecionados = clbProdutos.CheckedItems.Cast<string>().ToList();

            var sb = new StringBuilder();
            sb.AppendLine("CONTRATO DE LOCAÇÃO");
            sb.AppendLine("===================");
            sb.AppendLine();

            sb.AppendLine("Cliente:");
            if (cliente != null)
            {
                sb.AppendLine($"Nome: {cliente.Nome}");
                sb.AppendLine($"Nacionalidade: {cliente.Nacionalidade}");
                sb.AppendLine($"Estado Civil: {cliente.EstadoCivil}");
                sb.AppendLine($"Profissão: {cliente.Profissao}");
                sb.AppendLine($"Endereço: {cliente.Endereco}");
                sb.AppendLine($"CEP: {cliente.CEP}");
                sb.AppendLine($"Cidade/Estado: {cliente.CidadeEstado}");
                sb.AppendLine($"RG: {cliente.RG}");
                sb.AppendLine($"CPF: {cliente.CPF}");
                sb.AppendLine($"Email: {cliente.Email}");
            }
            else
            {
                sb.AppendLine((clienteNome ?? "(não informado)"));
            }

            sb.AppendLine();
            sb.AppendLine("Produtos locados:");

            decimal total = 0m;
            if (produtosSelecionados.Any())
            {
                foreach (var item in produtosSelecionados)
                {
                    // item format: "Codigo - Modelo - R$Valor"
                    var parts = item.Split(new[] { '-' }, 3);
                    string codigo = parts.Length >= 1 ? parts[0].Trim() : item;
                    var produto = CadastrarProduto.Produtos.FirstOrDefault(p => p.Codigo == codigo);
                    if (produto != null)
                    {
                        sb.AppendLine($"- {produto.Codigo} | {produto.Modelo} | Cor: {produto.Cor} | Valor: R${produto.ValorLocacao:0.00}");
                        total += produto.ValorLocacao;
                    }
                    else
                    {
                        sb.AppendLine($"- {item}");
                    }
                }
            }
            else
            {
                sb.AppendLine("(nenhum produto selecionado)");
            }

            sb.AppendLine();
            sb.AppendLine($"Tipo de festa: {txtTipoFesta.Text}");
            sb.AppendLine($"Anfitrião(ões): {txtAnfitriao.Text}");
            sb.AppendLine($"Data do evento: {dtpData.Value.ToShortDateString()}");
            sb.AppendLine($"Horário do evento: {dtpHorario.Value.ToShortTimeString()}");
            sb.AppendLine();

            sb.AppendLine("Local:");
            var localNome = cmbLocal.SelectedItem as string;
            var local = CadastroLocal.Locais.FirstOrDefault(l => l.Nome == localNome);
            if (local != null)
            {
                sb.AppendLine($"Nome: {local.Nome}");
                sb.AppendLine($"Endereço: {local.Endereco}");
                sb.AppendLine($"Celular: {local.Celular}");
            }
            else
            {
                sb.AppendLine(localNome ?? "(não informado)");
            }

            sb.AppendLine();
            sb.AppendLine("Assessor:");
            var assessorNome = cmbAssessor.SelectedItem as string;
            var assessor = CadastroAssessor.Assessores.FirstOrDefault(a => a.Nome == assessorNome);
            if (assessor != null)
            {
                sb.AppendLine($"Nome: {assessor.Nome}");
                sb.AppendLine($"Endereço: {assessor.Endereco}");
                sb.AppendLine($"Celular: {assessor.Celular}");
            }
            else
            {
                sb.AppendLine(assessorNome ?? "(não informado)");
            }

            sb.AppendLine();
            sb.AppendLine("Decorador:");
            var decoradorNome = cmbDecorador.SelectedItem as string;
            var decorador = CadastroDecorador.Decoradores.FirstOrDefault(d => d.Nome == decoradorNome);
            if (decorador != null)
            {
                sb.AppendLine($"Nome: {decorador.Nome}");
                sb.AppendLine($"Endereço: {decorador.Endereco}");
                sb.AppendLine($"Celular: {decorador.Celular}");
            }
            else
            {
                sb.AppendLine(decoradorNome ?? "(não informado)");
            }

            sb.AppendLine();
            sb.AppendLine($"Valor total calculado: R${total:0.00}");
            sb.AppendLine($"Forma de pagamento: {cmbFormaPagamento.SelectedItem as string ?? "(não informado)"}");
            sb.AppendLine();

            sb.AppendLine("Assinaturas:");
            sb.AppendLine();
            sb.AppendLine("______________________________");
            sb.AppendLine("Cliente");
            sb.AppendLine();
            sb.AppendLine("______________________________");
            sb.AppendLine("Contratante");

            // ask user where to save (allow txt or pdf)
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF files (*.pdf)|*.pdf|Text files (*.txt)|*.txt";
                var safeName = (clienteNome ?? "contrato")
                    .Replace(" ", "_")
                    .Replace("/", "_")
                    .Replace("\\", "_");
                sfd.FileName = $"Contrato_{safeName}_{DateTime.Now:yyyyMMdd_HHmm}";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        var ext = Path.GetExtension(sfd.FileName).ToLowerInvariant();
                        if (ext == ".pdf")
                        {
                            GeneratePdf(sb.ToString(), sfd.FileName);
                            MessageBox.Show($"Contrato PDF salvo em:\n{sfd.FileName}", "Contrato gerado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                            MessageBox.Show($"Contrato salvo em:\n{sfd.FileName}", "Contrato gerado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void GeneratePdf(string text, string outputPath)
        {
            // Basic PDF generation using PdfSharp. This lays out the provided text on the PDF page(s).
            var doc = new PdfDocument();
            doc.Info.Title = "Contrato de Locação";

            var page = doc.AddPage();
            page.Size = PdfSharp.PageSize.A4;
            page.Orientation = PdfSharp.PageOrientation.Portrait;

            var gfx = XGraphics.FromPdfPage(page);
            var tf = new XTextFormatter(gfx);

            // Fonts
            var titleFont = new XFont("Arial", 14);
            var headerFont = new XFont("Arial", 10);
            var regularFont = new XFont("Arial", 10);

            double margin = 40;
            double y = margin;
            double width = page.Width.Point - 2 * margin;

            // Header (simple)
            gfx.DrawString("CONTRATO DE LOCAÇÃO", titleFont, XBrushes.Black, new XRect(margin, y, width, 20), XStringFormats.TopCenter);
            y += 30;

            // Draw body text with wrapping
            tf.Alignment = XParagraphAlignment.Left;
            var rect = new XRect(margin, y, width, page.Height.Point - y - margin);
            tf.DrawString(text, regularFont, XBrushes.Black, rect, XStringFormats.TopLeft);

            // Save
            doc.Save(outputPath);
            doc.Close();
        }

        private void lblValorTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
