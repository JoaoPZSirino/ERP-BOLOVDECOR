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

        /// <summary>
        /// Método principal do botão Salvar.
        /// Agora ele coleta os dados, preenche o objeto 'Contrato'
        /// e chama os métodos auxiliares para gerar o texto e salvar o arquivo.
        /// </summary>
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // 1. Criar e preencher o objeto Contrato com os dados do formulário
            Contrato novoContrato = new Contrato();

            // --- Partes Envolvidas ---
            var clienteNome = cmbCliente.SelectedItem as string;
            novoContrato.ClienteContratante = CadastrarCliente.Clientes.FirstOrDefault(c => c.Nome == clienteNome);

            var localNome = cmbLocal.SelectedItem as string;
            novoContrato.LocalEvento = CadastroLocal.Locais.FirstOrDefault(l => l.Nome == localNome);

            var assessorNome = cmbAssessor.SelectedItem as string;
            novoContrato.AssessorEvento = CadastroAssessor.Assessores.FirstOrDefault(a => a.Nome == assessorNome);

            var decoradorNome = cmbDecorador.SelectedItem as string;
            novoContrato.DecoradorEvento = CadastroDecorador.Decoradores.FirstOrDefault(d => d.Nome == decoradorNome);

            // --- Dados do Evento ---
            novoContrato.DataHoraEvento = dtpData.Value.Date + dtpHorario.Value.TimeOfDay;
            novoContrato.TipoFesta = txtTipoFesta.Text;
            novoContrato.Anfitriao = txtAnfitriao.Text;

            // --- Itens e Valores ---
            novoContrato.ValorTotal = 0m;
            var produtosSelecionadosStrings = clbProdutos.CheckedItems.Cast<string>().ToList();

            foreach (var item in produtosSelecionadosStrings)
            {
                // item format: "Codigo - Modelo - R$Valor"
                var parts = item.Split(new[] { '-' }, 3);
                string codigo = parts.Length >= 1 ? parts[0].Trim() : item;
                var produto = CadastrarProduto.Produtos.FirstOrDefault(p => p.Codigo == codigo);

                if (produto != null)
                {
                    novoContrato.ProdutosLocados.Add(produto);
                    novoContrato.ValorTotal += produto.ValorLocacao;

                    // TODO: Adicionar lógica para preencher 'DescricaoValoresReposicao'
                    // Ex: novoContrato.DescricaoValoresReposicao.Add($"{produto.Modelo}: R${produto.ValorReposicao:0.00}");
                }
            }

            // --- Pagamento (Simples, do seu formulário atual) ---
            novoContrato.DetalhesFormaPagamento = cmbFormaPagamento.SelectedItem as string ?? "(não informado)";

            // --- Pagamento (Campos do template .DOCX - Adicione-os ao seu formulário) ---
            /* novoContrato.ValorEntrada = decimal.Parse(txtValorEntrada.Text);
            novoContrato.DataEntrada = dtpDataEntrada.Value;
            novoContrato.ValorRestante = decimal.Parse(txtValorRestante.Text);
            novoContrato.DataRestante = dtpDataRestante.Value;
            novoContrato.HorarioEntregaCombinado = txtHorarioEntrega.Text;
            novoContrato.HorarioRetiradaCombinado = txtHorarioRetirada.Text;
            */

            // 2. Gerar o texto do contrato usando o objeto preenchido
            // (Este é o novo método auxiliar)
            string textoDoContrato = GerarTextoParaContrato(novoContrato);

            // 3. Salvar o arquivo (Lógica do SaveFileDialog)
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF files (*.pdf)|*.pdf|Text files (*.txt)|*.txt";

                // Usa o nome do cliente que está no objeto 'Contrato'
                var safeName = (novoContrato.ClienteContratante?.Nome ?? "contrato")
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
                            // Passa o texto gerado para o método de PDF
                            GeneratePdf(textoDoContrato, sfd.FileName);
                            MessageBox.Show($"Contrato PDF salvo em:\n{sfd.FileName}", "Contrato gerado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            // Escreve o texto gerado no arquivo TXT
                            File.WriteAllText(sfd.FileName, textoDoContrato, Encoding.UTF8);
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

        /// <summary>
        /// NOVO MÉTODO AUXILIAR
        /// Pega o objeto 'Contrato' preenchido e gera o texto
        /// formatado para o arquivo final.
        /// </summary>
        /// <param name="contrato">O objeto com todos os dados do contrato.</param>
        /// <returns>Uma string com o contrato formatado.</returns>
        private string GerarTextoParaContrato(Contrato contrato)
        {
            var sb = new StringBuilder();
            sb.AppendLine("CONTRATO DE LOCAÇÃO");
            sb.AppendLine("===================");
            sb.AppendLine();

            sb.AppendLine("Cliente:");
            if (contrato.ClienteContratante != null)
            {
                sb.AppendLine($"Nome: {contrato.ClienteContratante.Nome}");
                sb.AppendLine($"Nacionalidade: {contrato.ClienteContratante.Nacionalidade}");
                sb.AppendLine($"Estado Civil: {contrato.ClienteContratante.EstadoCivil}");
                sb.AppendLine($"Profissão: {contrato.ClienteContratante.Profissao}");
                sb.AppendLine($"Endereço: {contrato.ClienteContratante.Endereco}");
                sb.AppendLine($"CEP: {contrato.ClienteContratante.CEP}");
                sb.AppendLine($"Cidade/Estado: {contrato.ClienteContratante.CidadeEstado}");
                sb.AppendLine($"RG: {contrato.ClienteContratante.RG}");
                sb.AppendLine($"CPF: {contrato.ClienteContratante.CPF}");
                sb.AppendLine($"Email: {contrato.ClienteContratante.Email}");
            }
            else
            {
                sb.AppendLine("(não informado)");
            }

            sb.AppendLine();
            sb.AppendLine("Produtos locados:");

            if (contrato.ProdutosLocados != null && contrato.ProdutosLocados.Any())
            {
                foreach (var produto in contrato.ProdutosLocados)
                {
                    sb.AppendLine($"- {produto.Codigo} | {produto.Modelo} | Cor: {produto.Cor} | Valor: R${produto.ValorLocacao:0.00}");
                }
            }
            else
            {
                sb.AppendLine("(nenhum produto selecionado)");
            }

            sb.AppendLine();
            sb.AppendLine($"Tipo de festa: {contrato.TipoFesta}");
            sb.AppendLine($"Anfitrião(ões): {contrato.Anfitriao}");
            sb.AppendLine($"Data do evento: {contrato.DataHoraEvento.ToShortDateString()}");
            sb.AppendLine($"Horário do evento: {contrato.DataHoraEvento.ToShortTimeString()}");
            sb.AppendLine();

            sb.AppendLine("Local:");
            if (contrato.LocalEvento != null)
            {
                sb.AppendLine($"Nome: {contrato.LocalEvento.Nome}");
                sb.AppendLine($"Endereço: {contrato.LocalEvento.Endereco}");
                sb.AppendLine($"Celular: {contrato.LocalEvento.Celular}");
            }
            else
            {
                sb.AppendLine("(não informado)");
            }

            sb.AppendLine();
            sb.AppendLine("Assessor:");
            if (contrato.AssessorEvento != null)
            {
                sb.AppendLine($"Nome: {contrato.AssessorEvento.Nome}");
                sb.AppendLine($"Endereço: {contrato.AssessorEvento.Endereco}");
                sb.AppendLine($"Celular: {contrato.AssessorEvento.Celular}");
            }
            else
            {
                sb.AppendLine("(não informado)");
            }

            sb.AppendLine();
            sb.AppendLine("Decorador:");
            if (contrato.DecoradorEvento != null)
            {
                sb.AppendLine($"Nome: {contrato.DecoradorEvento.Nome}");
                sb.AppendLine($"Endereço: {contrato.DecoradorEvento.Endereco}");
                sb.AppendLine($"Celular: {contrato.DecoradorEvento.Celular}");
            }
            else
            {
                sb.AppendLine("(não informado)");
            }

            sb.AppendLine();
            sb.AppendLine($"Valor total calculado: R${contrato.ValorTotal:0.00}");
            sb.AppendLine($"Forma de pagamento: {contrato.DetalhesFormaPagamento}");
            sb.AppendLine();

            // TODO: Adicionar aqui o restante do texto do contrato (Cláusulas, etc.)
            // buscando os dados do objeto 'contrato'.
            // Ex: sb.AppendLine($"O pagamento será feito com entrada de R${contrato.ValorEntrada}...");

            sb.AppendLine("Assinaturas:");
            sb.AppendLine();
            sb.AppendLine("______________________________");
            sb.AppendLine("Cliente");
            sb.AppendLine();
            sb.AppendLine("______________________________");
            sb.AppendLine("Contratante"); // (No seu docx, a outra parte é ZULEICA ZEN SIRINO)

            return sb.ToString();
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
