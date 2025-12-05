using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Text;

namespace ERPBOLOV2
{
    public class GeradorPDF
    {
        // Definição das fontes (usando XFontStyleEx para versão 6.x)
        XFont fontTitulo = new XFont("Arial", 14, XFontStyleEx.Bold);
        XFont fontSubTitulo = new XFont("Arial", 11, XFontStyleEx.Bold);
        XFont fontCorpo = new XFont("Arial", 10, XFontStyleEx.Regular);
        XFont fontNegrito = new XFont("Arial", 10, XFontStyleEx.Bold);

        public void GerarArquivoPDF(Contrato contrato, string caminhoArquivo)
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = $"Contrato - {contrato.Cliente?.Nome ?? "Novo"}";

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XTextFormatter tf = new XTextFormatter(gfx);

            double margem = 40;
            double y = 40;
            double largura = page.Width.Point - (margem * 2);

            // --- TÍTULO ---
            tf.Alignment = XParagraphAlignment.Center;
            tf.DrawString("CONTRATO DE LOCAÇÃO", fontTitulo, XBrushes.Black, new XRect(margem, y, largura, 20));
            y += 40;

            // --- PREÂMBULO ---
            tf.Alignment = XParagraphAlignment.Justify;
            var c = contrato.Cliente ?? new Cliente { Nome = "_________________", Nacionalidade = "_______", EstadoCivil = "_______", Endereco = "_______", CEP = "_______", CidadeEstado = "_______", CPF = "_______", RG = "_______", Celular = "_______", Email = "_______" };

            string textoPreambulo = $"De um lado {c.Nome.ToUpper()}, {c.Nacionalidade}, {c.EstadoCivil}, residente na {c.Endereco}, CEP {c.CEP}, {c.CidadeEstado}, " +
                $"CPF {c.CPF} e RG {c.RG}, fone {c.Celular}, e-mail {c.Email}, de outro lado {contrato.NomeEmpresa}, " +
                $"inscrita no CNPJ nº {contrato.CNPJEmpresa}, com sede na {contrato.EnderecoEmpresa}, de ora em diante denominada de CONTRATADA, têm justo e contratado o que segue:";

            y = DesenharParagrafo(gfx, tf, textoPreambulo, fontCorpo, margem, y, largura) + 10;

            // --- CLÁUSULA 1: OBJETO ---
            gfx.DrawString("CLÁUSULA PRIMEIRA – DO(s) OBJETO(s)", fontSubTitulo, XBrushes.Black, margem, y);
            y += 20;

            StringBuilder sb = new StringBuilder();
            foreach (var p in contrato.Produtos) sb.Append($"{p.Modelo} + ");
            string listaProdutos = sb.ToString().TrimEnd(' ', '+');
            if (string.IsNullOrEmpty(listaProdutos)) listaProdutos = "(nenhum produto selecionado)";

            string textoObjeto = $"O(s) objeto(s) do presente contrato consiste(m) na LOCAÇÃO DE {listaProdutos}.";
            y = DesenharParagrafo(gfx, tf, textoObjeto, fontCorpo, margem, y, largura) + 5;

            string localNome = contrato.Local?.Nome ?? "Local a definir";
            string textoEvento = $"Para festa de {contrato.TipoFesta} {contrato.Anfitriao}, a realizar-se na data de {contrato.DataEvento:dd 'de' MMMM 'de' yyyy}, às {contrato.HoraEvento:hh\\:mm}h no {localNome}.";
            y = DesenharParagrafo(gfx, tf, textoEvento, fontCorpo, margem, y, largura) + 5;

            string ass = contrato.Assessor?.Nome ?? "________________";
            string dec = contrato.Decorador?.Nome ?? "________________";
            gfx.DrawString($"Assessoria responsável: {ass}   -   Decorador(a): {dec}", fontCorpo, XBrushes.Black, margem, y);
            y += 25;

            // --- CLÁUSULA 2: PAGAMENTO ---
            gfx.DrawString("CLÁUSULA SEGUNDA – DO VALOR E DA FORMA DE PAGAMENTO", fontSubTitulo, XBrushes.Black, margem, y);
            y += 20;

            string extenso = string.IsNullOrEmpty(contrato.ValorPorExtenso) ? "(valor por extenso)" : contrato.ValorPorExtenso;
            string textoValor = $"O(a) CONTRATANTE pagará a CONTRATADA pelo(s) objeto(s) descrito(s) a quantia de R$ {contrato.ValorTotal:N2} ({extenso}).";
            y = DesenharParagrafo(gfx, tf, textoValor, fontCorpo, margem, y, largura) + 5;

            string textoEntrada = $"Parágrafo Primeiro – O pagamento deverá ser efetuado com entrada até o dia {contrato.DataEntrada:dd/MM/yyyy} no valor de R$ {contrato.ValorEntrada:N2} " +
                $"e R$ {contrato.ValorRestante:N2} até dia {contrato.DataRestante:dd/MM/yyyy}, mediante transação bancária via Pix, CNPJ {contrato.CNPJEmpresa}, banco Sicred, favorecida Bolo DeCoração.";
            y = DesenharParagrafo(gfx, tf, textoEntrada, fontCorpo, margem, y, largura) + 5;

            y = DesenharParagrafo(gfx, tf, "Favor nos enviar o comprovante.", fontNegrito, margem, y, largura) + 5;

            string textoQuitacao = "Parágrafo Segundo – O valor descrito nesta cláusula dá plena e total quitação do presente contrato, independentemente de qualquer reajuste até a data do evento.";
            y = DesenharParagrafo(gfx, tf, textoQuitacao, fontCorpo, margem, y, largura) + 10;

            // --- CLÁUSULA 3: LOGÍSTICA ---
            gfx.DrawString("CLÁUSULA TERCEIRA – DAS RESPONSABILIDADES E OBRIGAÇÕES", fontSubTitulo, XBrushes.Black, margem, y);
            y += 20;

            string textoLogistica;
            if (contrato.ClienteRetira)
                textoLogistica = "- A contratante se compromete em retirar e devolver o(s) objeto(s) no ateliê nas datas combinadas.";
            else
                textoLogistica = "- A contratada se compromete em entregar e retirar o(s) objeto(s) no local do evento nos horários a combinar.";

            y = DesenharParagrafo(gfx, tf, textoLogistica, fontCorpo, margem, y, largura) + 10;

            // --- CLÁUSULA 4: MULTA ---
            gfx.DrawString("CLÁUSULA QUARTA – DA MULTA CONTRATUAL", fontSubTitulo, XBrushes.Black, margem, y);
            y += 20;

            string textoMultas = "Parágrafo Primeiro: Fixa-se a cláusula penal de 20% sobre o valor do contrato para descumprimento.\n" +
                "Parágrafo Segundo: Caso haja desistência, o(a) CONTRATANTE pagará 50% do valor fixado.\n" +
                "Parágrafo Terceiro: A CONTRATADA deve disponibilizar o objeto conforme combinado, sob pena de restituir o valor e multa de 50%.\n" +
                "Parágrafo Quarto: Caso danifique gravemente ou extravie, deverá pagar o valor abaixo:";

            y = DesenharParagrafo(gfx, tf, textoMultas, fontCorpo, margem, y, largura) + 5;

            // Lista os valores de reposição
            foreach (var item in contrato.ItensReposicao)
            {
                gfx.DrawString("• " + item, fontNegrito, XBrushes.DarkRed, margem + 10, y);
                y += 15;
            }
            y += 10;

            // --- CLÁUSULA 5: IMAGEM ---
            gfx.DrawString("CLÁUSULA QUINTA – USO DA IMAGEM", fontSubTitulo, XBrushes.Black, margem, y);
            y += 20;
            y = DesenharParagrafo(gfx, tf, "Parágrafo Primeiro: O CONTRATANTE autoriza o uso da imagem em redes sociais de forma gratuita.", fontCorpo, margem, y, largura) + 20;

            // --- ASSINATURAS ---
            y = DesenharParagrafo(gfx, tf, "E por estarem justos e contratados, assinam o presente contrato em 2 vias.", fontCorpo, margem, y, largura) + 10;

            string dataExtenso = $"{contrato.CidadeAssinatura}, {contrato.DataAssinatura:dd 'de' MMMM 'de' yyyy}.";
            tf.Alignment = XParagraphAlignment.Right;
            tf.DrawString(dataExtenso, fontCorpo, XBrushes.Black, new XRect(margem, y, largura, 20));
            y += 50;

            double centro = page.Width.Point / 2;
            gfx.DrawLine(XPens.Black, margem, y, centro - 20, y);
            gfx.DrawLine(XPens.Black, centro + 20, y, page.Width.Point - margem, y);
            y += 5;

            tf.Alignment = XParagraphAlignment.Center;
            tf.DrawString(c.Nome, fontCorpo, XBrushes.Black, new XRect(margem, y, centro - margem - 20, 40));
            tf.DrawString("ZULEICA ZEN SIRINO", fontCorpo, XBrushes.Black, new XRect(centro + 20, y, centro - margem - 20, 40));

            document.Save(caminhoArquivo);
            document.Close();
        }

        private double DesenharParagrafo(XGraphics gfx, XTextFormatter tf, string texto, XFont fonte, double x, double y, double largura)
        {
            XRect rect = new XRect(x, y, largura, 1000); // Altura generosa
            tf.DrawString(texto, fonte, XBrushes.Black, rect);

            // Cálculo aproximado da altura usada
            double charPorLinha = largura / (fonte.Size * 0.5);
            int linhas = (int)Math.Ceiling(texto.Length / charPorLinha) + (texto.Split('\n').Length - 1);
            return y + (linhas * fonte.GetHeight()) + 10;
        }
    }
}