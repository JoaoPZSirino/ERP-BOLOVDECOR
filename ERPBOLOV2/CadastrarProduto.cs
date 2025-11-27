using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class CadastrarProduto : Form
    {
        public static List<Produto> Produtos = new List<Produto>
        {
            new Produto { Codigo = "P001", Modelo = TipoModelo.Bolo, Cor = "Preto", Altura = 10.5m, Topo = 5.0m, Base = 3.2m, ValorLocacao = 50.00m },
            new Produto { Codigo = "P002", Modelo = TipoModelo.Bolo , Cor = "Branco", Altura = 12.0m, Topo = 6.0m, Base = 4.0m, ValorLocacao = 60.00m },
            new Produto { Codigo = "N003", Modelo = TipoModelo.Topo, Cor = "Cinza", Altura = 0.5m, Topo = 0.2m, Base = 0.1m, ValorLocacao = 45.00m },
            new Produto { Codigo = "P004", Modelo = TipoModelo.Boleira, Cor = "Azul", Altura = 15.0m, Topo = 7.5m, Base = 5.0m, ValorLocacao = 80.00m },
            new Produto { Codigo = "P005", Modelo = TipoModelo.Outro, Cor = "Verde", Altura = 99.99m, Topo = 99.99m, Base = 100.99m, ValorLocacao = 999.99m }
        };

        public event EventHandler ProdutoAdicionado;

        public CadastrarProduto()
        {
            InitializeComponent();
            CarregarComboBox();
        }

        private void CarregarComboBox()
        {
            CBModelo.Items.Clear();

            string[] nomeDosModelos = Enum.GetNames(typeof(TipoModelo));

            CBModelo.Items.AddRange(nomeDosModelos);

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            TipoModelo modelo;
            decimal altura, topo, baseVal, valor;
            Enum.TryParse<TipoModelo>(CBModelo.SelectedItem.ToString(), out modelo);
            decimal.TryParse(txtAltura.Text, out altura);
            decimal.TryParse(txtTopo.Text, out topo);
            decimal.TryParse(txtBase.Text, out baseVal);
            decimal.TryParse(txtValor.Text, out valor);

            var p = new Produto
            {
                Codigo = txtCodigo.Text,
                Modelo = modelo,
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


        private void CadastrarProduto_Load(object sender, EventArgs e)
        {

        }


    }
}
