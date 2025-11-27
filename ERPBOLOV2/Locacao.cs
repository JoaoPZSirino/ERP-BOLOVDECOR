using System;

namespace ERPBOLOV2
{
    public class Locacao
    {
        public Locacao()
        {
            // Inicializa listas ou valores padrão se necessário
            DataCriacao = DateTime.Now;
        }

        public int Id { get; set; }

        // Dados do Evento (Baseado no CSV: DATA, HOR)
        public DateTime DataEvento { get; set; }
        public TimeSpan HorarioEvento { get; set; } // Coluna HOR
        public DateTime DataCriacao { get; private set; }

        // Relacionamentos com as classes existentes
        // No CSV: CLIENTE, FONE (Fone fica dentro do objeto Cliente)
        public Cliente Cliente { get; set; }

        // No CSV: ASSESSOR
        public Assessor Assessor { get; set; }

        // No CSV: DECORADOR
        public Decorador Decorador { get; set; }

        // No CSV: LOCAL
        public Local LocalEvento { get; set; }

        // Produtos: permitir um de cada tipo
        public Produto ProdutoBolo { get; set; }
        public Produto ProdutoBoleira { get; set; }
        public Produto ProdutoTopo { get; set; }
        public Produto ProdutoOutro { get; set; }

        // Mantém propriedade antiga por retrocompatibilidade (pode representar o bolo principal)
        public Produto Produto { get; set; }

        // Detalhes Específicos da Locação (Baseado no CSV: BOLEIRA, TOPO, OBS)
        public string DescricaoBoleira { get; set; } // Coluna BOLEIRA (ex: "Prato Vidro 50cm")
        public string DescricaoTopo { get; set; }    // Coluna TOPO (ex: "15 Rose")
        public string Observacao { get; set; }       // Coluna Observaçao / OBS

        // Logística (Baseado no CSV: RET/ENTR)
        public TipoLogistica TipoLogistica { get; set; }

        // Controle de Status (Baseado no CSV: PRONTO, ENTREGUE, DEVOLV)
        public bool EstaPronto { get; set; }    // Coluna PRONTO
        public bool FoiEntregue { get; set; }   // Coluna ENTREGUE
        public bool FoiDevolvido { get; set; }  // Coluna DEVOLV
        public string ResponsavelDevolucao { get; set; } // Coluna vazia no final ou OBS de devolução

        // Financeiro (Baseado na regra de negócio informada)
        public decimal ValorTotal { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public CondicaoPagamento CondicaoPagamento { get; set; }

        // Propriedade calculada para ajudar no controle de datas de pagamento
        public DateTime? DataVencimentoRestante
        {
            get
            {
                if (CondicaoPagamento == CondicaoPagamento.EntradaMais7Dias)
                {
                    return DataEvento.AddDays(-7);
                }
                return DataEvento; // Se for a vista ou outro, assume a data do evento como base
            }
        }
    }

    // Enums para padronizar os dados do CSV e Regras de Negócio

    public enum TipoLogistica
    {
        Retirada = 1,
        Entrega = 2,
        Transportadora = 3 // Visto no CSV
    }

    public enum FormaPagamento
    {
        Dinheiro = 1,
        Pix = 2,
        TransferenciaBancaria = 3
    }

    public enum CondicaoPagamento
    {
        AVista = 1,
        EntradaMais7Dias = 2, // 1 entrada e restante 7 dias antes
        Outro = 99 // Controle manual conforme solicitado
    }
}