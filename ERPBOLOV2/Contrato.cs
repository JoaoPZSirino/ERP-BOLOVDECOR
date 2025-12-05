using System;
using System.Collections.Generic;

namespace ERPBOLOV2
{
    public class Contrato
    {
        // Dados Fixos da Empresa (Conforme o modelo Word)
        public string NomeEmpresa { get; set; } = "Bolo DeCoração Ltda";
        public string CNPJEmpresa { get; set; } = "62.770.564/0001-60";
        public string EnderecoEmpresa { get; set; } = "Rua Pioneiro Alfredo José da Costa, 1308, Loteamento Sumaré, CEP 87035-610, Maringá – Paraná";

        // --- PROPRIEDADES (Nomes Simplificados) ---
        public Cliente Cliente { get; set; }
        public Local Local { get; set; }
        public Assessor Assessor { get; set; }
        public Decorador Decorador { get; set; }

        // Dados do Evento
        public DateTime DataEvento { get; set; }
        public TimeSpan HoraEvento { get; set; }
        public string TipoFesta { get; set; }
        public string Anfitriao { get; set; }

        // Produtos
        public List<Produto> Produtos { get; set; } = new List<Produto>();

        // Financeiro
        public decimal ValorTotal { get; set; }
        public string ValorPorExtenso { get; set; }

        // Pagamento Detalhado
        public decimal ValorEntrada { get; set; }
        public DateTime DataEntrada { get; set; }
        public decimal ValorRestante { get; set; }
        public DateTime DataRestante { get; set; }

        // Logística e Assinatura
        public bool ClienteRetira { get; set; }
        public string CidadeAssinatura { get; set; } = "Maringá";
        public DateTime DataAssinatura { get; set; } = DateTime.Now;

        // Lista de Reposição (para a Cláusula 4)
        public List<string> ItensReposicao { get; set; } = new List<string>();

        public Contrato() { }
    }
}