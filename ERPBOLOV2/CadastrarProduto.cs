using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class CadastrarProduto : Form
    {
        public static List<Produto> Produtos = new List<Produto>
        {
            new Produto { Codigo = "P001", Modelo = "Modelo A", Cor = "Preto", Altura = 10.5m, Topo = 5.0m, Base = 3.2m, ValorLocacao = 50.00m },
            new Produto { Codigo = "P002", Modelo = "Modelo B", Cor = "Branco", Altura = 12.0m, Topo = 6.0m, Base = 4.0m, ValorLocacao = 60.00m },
            new Produto { Codigo = "P003", Modelo = "Modelo C", Cor = "Vermelho", Altura = 8.0m, Topo = 4.0m, Base = 2.5m, ValorLocacao = 45.00m },
            new Produto { Codigo = "P004", Modelo = "Modelo D", Cor = "Azul", Altura = 15.0m, Topo = 7.5m, Base = 5.0m, ValorLocacao = 80.00m },
            new Produto { Codigo = "P005", Modelo = "Modelo E", Cor = "Verde", Altura = 9.5m, Topo = 4.5m, Base = 3.0m, ValorLocacao = 55.00m }
        };

        public event EventHandler ProdutoAdicionado;

        public CadastrarProduto()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            decimal altura, topo, baseVal, valor;
            decimal.TryParse(txtAltura.Text, out altura);
            decimal.TryParse(txtTopo.Text, out topo);
            decimal.TryParse(txtBase.Text, out baseVal);
            decimal.TryParse(txtValor.Text, out valor);

            var p = new Produto
            {
                Codigo = txtCodigo.Text,
                Modelo = txtModelo.Text,
                Cor = txtCor.Text,
                Altura = altura,
                Topo = topo,
                Base = baseVal,
                ValorLocacao = valor
            };

            Produtos.Add(p);
            ProdutoAdicionado?.Invoke(this, EventArgs.Empty);

            MessageBox.Show("Produto salvo com sucesso.", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
