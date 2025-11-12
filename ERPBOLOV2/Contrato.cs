using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPBOLOV2
{
    /* * Esta classe é o "Data Transfer Object" (DTO) do seu contrato.
     * Ela foi modelada para conter todas as informações VARIÁVEIS 
     * identificadas no seu template "Contrato de locação - Modelo de contrato.docx"
     * e que são (ou deveriam ser) coletadas no seu formulário "ContratoLocacao".
    */
    internal class Contrato
    {
        // --- PARTES ENVOLVIDAS (Fonte: 2) ---

        /// <summary>
        /// O objeto Cliente completo, selecionado no cmbCliente.
        /// (Contém Nome, CPF, RG, Endereço, etc.)
        /// </summary>
        public Cliente ClienteContratante { get; set; }

        /// <summary>
        /// O objeto Local completo, selecionado no cmbLocal.
        /// (Contém Nome, Endereço, Celular)
        /// </summary>
        public Local LocalEvento { get; set; }

        /// <summary>
        /// O objeto Assessor completo, selecionado no cmbAssessor. (Fonte: 6)
        /// </summary>
        public Assessor AssessorEvento { get; set; }

        /// <summary>
        /// O objeto Decorador completo, selecionado no cmbDecorador. (Fonte: 6)
        /// </summary>
        public Decorador DecoradorEvento { get; set; }


        // --- DADOS DO EVENTO (Fonte: 5) ---

        /// <summary>
        /// Combinação dos campos dtpData e dtpHorario do formulário.
        /// </summary>
        public DateTime DataHoraEvento { get; set; }

        /// <summary>
        /// Campo txtTipoFesta do formulário.
        /// (No template: "festa de casamento")
        /// </summary>
        public string TipoFesta { get; set; }

        /// <summary>
        /// Campo txtAnfitriao do formulário.
        /// (No template: "de Mariana e Marcus")
        /// </summary>
        public string Anfitriao { get; set; }


        // --- OBJETOS E VALORES (Fonte: 4, 9, 24) ---

        /// <summary>
        /// Lista dos objetos Produto selecionados no clbProdutos. (Fonte: 4)
        /// </summary>
        public List<Produto> ProdutosLocados { get; set; }

        /// <summary>
        /// Valor total calculado a partir dos produtos. (Fonte: 9)
        /// </summary>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// O valor total escrito por extenso. (Fonte: 9)
        /// Ex: "oitocentos e cinquenta reais"
        /// (Isso precisará de uma função auxiliar para ser gerado)
        /// </summary>
        public string ValorTotalPorExtenso { get; set; }

        /// <summary>
        /// Lista de strings formatadas para a cláusula de extravio. (Fonte: 24)
        /// Ex: "Bolo cenográfico : R$ 2.000,00"
        /// (Isso deve vir da classe Produto, que precisa ter um 'ValorDeReposicao')
        /// </summary>
        public List<string> DescricaoValoresReposicao { get; set; }


        // --- PAGAMENTO (Fonte: 10) ---
        // (Seu formulário 'ContratoLocacao' PRECISA SER ATUALIZADO para coletar isso)

        /// <summary>
        /// O valor da entrada. (Ex: R$ 425,00)
        /// </summary>
        public decimal ValorEntrada { get; set; }

        /// <summary>
        /// A data limite para a entrada. (Ex: 13/11/2025)
        /// </summary>
        public DateTime DataEntrada { get; set; }

        /// <summary>
        /// O valor restante. (Ex: R$ 425,00)
        /// </summary>
        public decimal ValorRestante { get; set; }

        /// <summary>
        /// A data limite para o restante. (Ex: 27/05/2026)
        /// </summary>
        public DateTime DataRestante { get; set; }

        /// <summary>
        /// Detalhes do pagamento (Ex: Pix, CNPJ, etc. - Fonte: 10)
        /// </summary>
        public string DetalhesFormaPagamento { get; set; }


        // --- LOGÍSTICA (Fonte: 14, 15) ---
        // (Seu formulário 'ContratoLocacao' PRECISA SER ATUALIZADO para coletar isso)

        /// <summary>
        /// Horário de entrega a ser combinado.
        /// </summary>
        public string HorarioEntregaCombinado { get; set; }

        /// <summary>
        /// Horário de retirada a ser combinado.
        /// </summary>
        public string HorarioRetiradaCombinado { get; set; }

        // --- DADOS DE GERAÇÃO (Fonte: 30) ---

        /// <summary>
        /// A cidade onde o contrato é assinado (Ex: "Maringá")
        /// </summary>
        public string CidadeAssinatura { get; set; }

        /// <summary>
        /// A data em que o contrato foi gerado e assinado.
        /// </summary>
        public DateTime DataAssinatura { get; set; }


        // Construtor
        public Contrato()
        {
            // Inicializa as listas para evitar erros
            ProdutosLocados = new List<Produto>();
            DescricaoValoresReposicao = new List<string>();

            // Valores padrão que vêm da CONTRATADA (Bolo DeCoração)
            // Você pode carregar isso de um arquivo de configuração
            this.CidadeAssinatura = "Maringá";
            this.DataAssinatura = DateTime.Now;
            this.DetalhesFormaPagamento = "mediante transação bancária via Pix, sendo CNPJ 62.770.564/0001-60, banco Sicred, favorecida Bolo DeCoração, na descrição identifique o nome a quem destina-se a festa e data.";
        }
    }
}