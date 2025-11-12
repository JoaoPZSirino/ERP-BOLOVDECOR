using System;

namespace ERPBOLOV2
{
    
                /// </summary>
    public class Pagamento
    {
        
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Valor total escrito por extenso. Ex: "oitocentos e cinquenta reais". [cite: 9]
        /// (Você precisará de uma função para gerar isso).
        /// </summary>
        public string ValorTotalPorExtenso { get; set; }

        /// <summary>
        /// O valor da entrada/sinal. Ex: R$ 425,00. [cite: 10]
        /// </summary>
        public decimal ValorEntrada { get; set; }

        /// <summary>
        /// Data limite para o pagamento da entrada. Ex: 13/11/2025. [cite: 10]
        /// </summary>
        public DateTime DataLimiteEntrada { get; set; }

        /// <summary>
        /// O valor restante. Ex: R$ 425,00. [cite: 10]
        /// </summary>
        public decimal ValorRestante { get; set; }

        /// <summary>
        /// Data limite para o pagamento final. Ex: 27/05/2026. [cite: 10]
        /// </summary>
        public DateTime DataLimiteRestante { get; set; }

       
        public string DescricaoMetodo { get; set; }

        /// <summary>
        /// Construtor que já preenche os dados padrão da sua empresa (Contratada).
        /// </summary>
        public Pagamento()
        {
            
            this.DescricaoMetodo = "mediante transação bancária via Pix, sendo CNPJ 62.770.564/0001-60, banco Sicred, favorecida Bolo DeCoração, na descrição identifique o nome a quem destina-se a festa e data.";

            // Inicializa valores para evitar erros
            this.ValorTotal = 0m;
            this.ValorEntrada = 0m;
            this.ValorRestante = 0m;
            this.DataLimiteEntrada = DateTime.Now;
            this.DataLimiteRestante = DateTime.Now;
            this.ValorTotalPorExtenso = "zero reais";
        }
    }
}