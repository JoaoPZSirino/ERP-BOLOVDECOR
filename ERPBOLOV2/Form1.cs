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

        private void visualizarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VizualizarClientes();
            frm.ShowDialog(this);
        }

        private void visualizarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VizualizarProduto();
            frm.ShowDialog(this);
        }

        private void visualizarAssessoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VizualizarAssessor();
            frm.ShowDialog(this);
        }

        private void visualizarDecoradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VizualizarDecorador();
            frm.ShowDialog(this);
        }

        private void visualizarLocaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new VizualizarLocal();
            frm.ShowDialog(this);
        }

        private void btnGerarContrato_Click(object sender, EventArgs e)
        {
            var frm = new ContratoLocacao();
            frm.ShowDialog(this);
        }
    }
}
