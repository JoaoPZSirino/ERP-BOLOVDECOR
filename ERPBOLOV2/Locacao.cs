using System;
using System.Collections.Generic;

namespace ERPBOLOV2
{
    internal class Locacao
    {
        // --- Informações do Evento ---
        public DateTime DataHoraEvento { get; set; }
        public string TipoFesta { get; set; }
        public string Anfitriao { get; set; }

        // --- Partes Envolvidas ---
        public Cliente ClienteContratante { get; set; }
        public Local LocalEvento { get; set; }
        public Assessor AssessorEvento { get; set; }
        public Decorador DecoradorEvento { get; set; }

        // --- Itens e Valores ---
        public List<Produto> ProdutosLocados { get; set; }
        public decimal ValorTotal { get; set; } // O total ainda fica aqui
        public List<string> DescricaoValoresReposicao { get; set; }

        // --- PAGAMENTO (AQUI ESTÁ A MUDANÇA) ---
        // As propriedades de pagamento foram movidas para a classe Pagamento
        public Pagamento DetalhesPagamento { get; set; } // <--- SUA NOVA PROPRIEDADE

        // --- Logística ---
        public string HorarioEntregaCombinado { get; set; }
        public string HorarioRetiradaCombinado { get; set; }

        // --- Dados de Geração ---
        public string CidadeAssinatura { get; set; }
        public DateTime DataAssinatura { get; set; }


        public Locacao()
        {
            ProdutosLocados = new List<Produto>();
            DescricaoValoresReposicao = new List<string>();

            // Inicializa o objeto de Pagamento
            DetalhesPagamento = new Pagamento(); // <--- IMPORTANTE

            this.CidadeAssinatura = "Maringá";
            this.DataAssinatura = DateTime.Now;
        }
    }
}