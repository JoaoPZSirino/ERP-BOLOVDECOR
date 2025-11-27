using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPBOLOV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Menu Clientes
        private void visualizarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VizualizarClientes();
            frm.ShowDialog(this);
        }

        private void cadastrarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new CadastrarCliente();
            frm.ShowDialog(this);
        }

        //Menu Produtos

        private void visualizarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VizualizarProduto();
            frm.ShowDialog(this);
        }

        private void cadastrarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new CadastrarProduto();
            frm.ShowDialog(this);
        }

        //Menu Assessores

        private void visualizarAssessoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VizualizarAssessor();
            frm.ShowDialog(this);
        }

        private void cadastrarAcessoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new CadastroAssessor();
            frm.ShowDialog(this);
        }

        //Menu Decoradores

        private void visualizarDecoradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VizualizarDecorador();
            frm.ShowDialog(this);
        }

        private void cadastrarDecoradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new CadastroDecorador();
            frm.ShowDialog(this);
        }

        //Menu Locais

        private void visualizarLocaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VizualizarLocal();
            frm.ShowDialog(this);
        }
        
        private void cadastrarLocaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new CadastroLocal();
            frm.ShowDialog(this);
        }

        //Botão Gerar Contrato

        private void btnGerarContrato_Click(object sender, EventArgs e)
        {
            var frm = new ContratoLocacao();
            frm.ShowDialog(this);
        }


    }
}
