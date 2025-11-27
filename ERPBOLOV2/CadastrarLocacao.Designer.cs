namespace ERPBOLOV2
{
    partial class CadastrarLocacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblDataEvento;
        private System.Windows.Forms.DateTimePicker dtpDataEvento;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.TextBox txtHorario;

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbCliente;

        private System.Windows.Forms.Label lblAssessor;
        private System.Windows.Forms.ComboBox cbAssessor;

        private System.Windows.Forms.Label lblDecorador;
        private System.Windows.Forms.ComboBox cbDecorador;

        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.ComboBox cbLocal;

        // Four comboboxes for product types
        private System.Windows.Forms.Label lblBolo;
        private System.Windows.Forms.ComboBox cbBolo;

        private System.Windows.Forms.Label lblBoleira;
        private System.Windows.Forms.ComboBox cbBoleira;

        private System.Windows.Forms.Label lblTopo;
        private System.Windows.Forms.ComboBox cbTopo;

        private System.Windows.Forms.Label lblOutro;
        private System.Windows.Forms.ComboBox cbOutro;

        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.TextBox txtObs;

        private System.Windows.Forms.Label lblTipoLogistica;
        private System.Windows.Forms.ComboBox cbTipoLogistica;

        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.ComboBox cbFormaPagamento;

        private System.Windows.Forms.Label lblCondicaoPagamento;
        private System.Windows.Forms.ComboBox cbCondicaoPagamento;

        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.NumericUpDown nudValorTotal;

        private System.Windows.Forms.CheckBox chkPronto;
        private System.Windows.Forms.CheckBox chkEntregue;
        private System.Windows.Forms.CheckBox chkDevolvido;

        private System.Windows.Forms.Label lblResponsavelDevolucao;
        private System.Windows.Forms.TextBox txtResponsavelDevolucao;

        private System.Windows.Forms.Button btnSalvar;

        private System.Windows.Forms.Label lblDescricaoBoleira;
        private System.Windows.Forms.TextBox txtDescricaoBoleira;
        private System.Windows.Forms.Label lblDescricaoTopo;
        private System.Windows.Forms.TextBox txtDescricaoTopo;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDataEvento = new System.Windows.Forms.Label();
            this.dtpDataEvento = new System.Windows.Forms.DateTimePicker();
            this.lblHorario = new System.Windows.Forms.Label();
            this.txtHorario = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.lblAssessor = new System.Windows.Forms.Label();
            this.cbAssessor = new System.Windows.Forms.ComboBox();
            this.lblDecorador = new System.Windows.Forms.Label();
            this.cbDecorador = new System.Windows.Forms.ComboBox();
            this.lblLocal = new System.Windows.Forms.Label();
            this.cbLocal = new System.Windows.Forms.ComboBox();

            this.lblBolo = new System.Windows.Forms.Label();
            this.cbBolo = new System.Windows.Forms.ComboBox();

            this.lblBoleira = new System.Windows.Forms.Label();
            this.cbBoleira = new System.Windows.Forms.ComboBox();

            this.lblTopo = new System.Windows.Forms.Label();
            this.cbTopo = new System.Windows.Forms.ComboBox();

            this.lblOutro = new System.Windows.Forms.Label();
            this.cbOutro = new System.Windows.Forms.ComboBox();

            this.lblObs = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.lblTipoLogistica = new System.Windows.Forms.Label();
            this.cbTipoLogistica = new System.Windows.Forms.ComboBox();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.cbFormaPagamento = new System.Windows.Forms.ComboBox();
            this.lblCondicaoPagamento = new System.Windows.Forms.Label();
            this.cbCondicaoPagamento = new System.Windows.Forms.ComboBox();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.nudValorTotal = new System.Windows.Forms.NumericUpDown();
            this.chkPronto = new System.Windows.Forms.CheckBox();
            this.chkEntregue = new System.Windows.Forms.CheckBox();
            this.chkDevolvido = new System.Windows.Forms.CheckBox();
            this.lblResponsavelDevolucao = new System.Windows.Forms.Label();
            this.txtResponsavelDevolucao = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblDescricaoBoleira = new System.Windows.Forms.Label();
            this.txtDescricaoBoleira = new System.Windows.Forms.TextBox();
            this.lblDescricaoTopo = new System.Windows.Forms.Label();
            this.txtDescricaoTopo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDataEvento
            // 
            this.lblDataEvento.AutoSize = true;
            this.lblDataEvento.Location = new System.Drawing.Point(12, 15);
            this.lblDataEvento.Name = "lblDataEvento";
            this.lblDataEvento.Size = new System.Drawing.Size(67, 13);
            this.lblDataEvento.TabIndex = 0;
            this.lblDataEvento.Text = "Data Evento";
            // 
            // dtpDataEvento
            // 
            this.dtpDataEvento.Location = new System.Drawing.Point(140, 12);
            this.dtpDataEvento.Name = "dtpDataEvento";
            this.dtpDataEvento.Size = new System.Drawing.Size(200, 20);
            this.dtpDataEvento.TabIndex = 1;
            // 
            // lblHorario
            // 
            this.lblHorario.AutoSize = true;
            this.lblHorario.Location = new System.Drawing.Point(12, 45);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(41, 13);
            this.lblHorario.TabIndex = 2;
            this.lblHorario.Text = "Horário";
            // 
            // txtHorario
            // 
            this.txtHorario.Location = new System.Drawing.Point(140, 42);
            this.txtHorario.Name = "txtHorario";
            this.txtHorario.Size = new System.Drawing.Size(200, 20);
            this.txtHorario.TabIndex = 3;
            this.txtHorario.Text = "10:00";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(12, 75);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Cliente";
            // 
            // cbCliente
            // 
            this.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCliente.Location = new System.Drawing.Point(140, 72);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(200, 21);
            this.cbCliente.TabIndex = 5;
            // 
            // lblAssessor
            // 
            this.lblAssessor.AutoSize = true;
            this.lblAssessor.Location = new System.Drawing.Point(12, 105);
            this.lblAssessor.Name = "lblAssessor";
            this.lblAssessor.Size = new System.Drawing.Size(49, 13);
            this.lblAssessor.TabIndex = 6;
            this.lblAssessor.Text = "Assessor";
            // 
            // cbAssessor
            // 
            this.cbAssessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAssessor.Location = new System.Drawing.Point(140, 102);
            this.cbAssessor.Name = "cbAssessor";
            this.cbAssessor.Size = new System.Drawing.Size(200, 21);
            this.cbAssessor.TabIndex = 7;
            // 
            // lblDecorador
            // 
            this.lblDecorador.AutoSize = true;
            this.lblDecorador.Location = new System.Drawing.Point(12, 135);
            this.lblDecorador.Name = "lblDecorador";
            this.lblDecorador.Size = new System.Drawing.Size(57, 13);
            this.lblDecorador.TabIndex = 8;
            this.lblDecorador.Text = "Decorador";
            // 
            // cbDecorador
            // 
            this.cbDecorador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDecorador.Location = new System.Drawing.Point(140, 132);
            this.cbDecorador.Name = "cbDecorador";
            this.cbDecorador.Size = new System.Drawing.Size(200, 21);
            this.cbDecorador.TabIndex = 9;
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.Location = new System.Drawing.Point(12, 165);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(33, 13);
            this.lblLocal.TabIndex = 10;
            this.lblLocal.Text = "Local";
            // 
            // cbLocal
            // 
            this.cbLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocal.Location = new System.Drawing.Point(140, 162);
            this.cbLocal.Name = "cbLocal";
            this.cbLocal.Size = new System.Drawing.Size(200, 21);
            this.cbLocal.TabIndex = 11;
            // 
            // lblBolo
            // 
            this.lblBolo.AutoSize = true;
            this.lblBolo.Location = new System.Drawing.Point(12, 195);
            this.lblBolo.Name = "lblBolo";
            this.lblBolo.Size = new System.Drawing.Size(28, 13);
            this.lblBolo.TabIndex = 12;
            this.lblBolo.Text = "Bolo";
            // 
            // cbBolo
            // 
            this.cbBolo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBolo.Location = new System.Drawing.Point(140, 192);
            this.cbBolo.Name = "cbBolo";
            this.cbBolo.Size = new System.Drawing.Size(200, 21);
            this.cbBolo.TabIndex = 13;
            this.cbBolo.SelectedIndexChanged += new System.EventHandler(this.cbBolo_SelectedIndexChanged);
            // 
            // lblBoleira
            // 
            this.lblBoleira.AutoSize = true;
            this.lblBoleira.Location = new System.Drawing.Point(12, 225);
            this.lblBoleira.Name = "lblBoleira";
            this.lblBoleira.Size = new System.Drawing.Size(42, 13);
            this.lblBoleira.TabIndex = 14;
            this.lblBoleira.Text = "Boleira";
            // 
            // cbBoleira
            // 
            this.cbBoleira.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoleira.Location = new System.Drawing.Point(140, 222);
            this.cbBoleira.Name = "cbBoleira";
            this.cbBoleira.Size = new System.Drawing.Size(200, 21);
            this.cbBoleira.TabIndex = 15;
            this.cbBoleira.SelectedIndexChanged += new System.EventHandler(this.cbBoleira_SelectedIndexChanged);
            // 
            // lblTopo
            // 
            this.lblTopo.AutoSize = true;
            this.lblTopo.Location = new System.Drawing.Point(12, 255);
            this.lblTopo.Name = "lblTopo";
            this.lblTopo.Size = new System.Drawing.Size(32, 13);
            this.lblTopo.TabIndex = 16;
            this.lblTopo.Text = "Topo";
            // 
            // cbTopo
            // 
            this.cbTopo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTopo.Location = new System.Drawing.Point(140, 252);
            this.cbTopo.Name = "cbTopo";
            this.cbTopo.Size = new System.Drawing.Size(200, 21);
            this.cbTopo.TabIndex = 17;
            this.cbTopo.SelectedIndexChanged += new System.EventHandler(this.cbTopo_SelectedIndexChanged);
            // 
            // lblOutro
            // 
            this.lblOutro.AutoSize = true;
            this.lblOutro.Location = new System.Drawing.Point(12, 285);
            this.lblOutro.Name = "lblOutro";
            this.lblOutro.Size = new System.Drawing.Size(33, 13);
            this.lblOutro.TabIndex = 18;
            this.lblOutro.Text = "Outro";
            // 
            // cbOutro
            // 
            this.cbOutro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutro.Location = new System.Drawing.Point(140, 282);
            this.cbOutro.Name = "cbOutro";
            this.cbOutro.Size = new System.Drawing.Size(200, 21);
            this.cbOutro.TabIndex = 19;
            this.cbOutro.SelectedIndexChanged += new System.EventHandler(this.cbOutro_SelectedIndexChanged);
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(371, 18);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(65, 13);
            this.lblObs.TabIndex = 20;
            this.lblObs.Text = "Observação";
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(481, 15);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(250, 80);
            this.txtObs.TabIndex = 21;
            // 
            // lblTipoLogistica
            // 
            this.lblTipoLogistica.AutoSize = true;
            this.lblTipoLogistica.Location = new System.Drawing.Point(371, 108);
            this.lblTipoLogistica.Name = "lblTipoLogistica";
            this.lblTipoLogistica.Size = new System.Drawing.Size(75, 13);
            this.lblTipoLogistica.TabIndex = 22;
            this.lblTipoLogistica.Text = "Tipo Logística";
            // 
            // cbTipoLogistica
            // 
            this.cbTipoLogistica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoLogistica.Location = new System.Drawing.Point(481, 105);
            this.cbTipoLogistica.Name = "cbTipoLogistica";
            this.cbTipoLogistica.Size = new System.Drawing.Size(250, 21);
            this.cbTipoLogistica.TabIndex = 23;
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Location = new System.Drawing.Point(394, 215);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(93, 13);
            this.lblFormaPagamento.TabIndex = 24;
            this.lblFormaPagamento.Text = "Forma Pagamento";
            // 
            // cbFormaPagamento
            // 
            this.cbFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormaPagamento.Location = new System.Drawing.Point(522, 212);
            this.cbFormaPagamento.Name = "cbFormaPagamento";
            this.cbFormaPagamento.Size = new System.Drawing.Size(200, 21);
            this.cbFormaPagamento.TabIndex = 25;
            // 
            // lblCondicaoPagamento
            // 
            this.lblCondicaoPagamento.AutoSize = true;
            this.lblCondicaoPagamento.Location = new System.Drawing.Point(394, 255);
            this.lblCondicaoPagamento.Name = "lblCondicaoPagamento";
            this.lblCondicaoPagamento.Size = new System.Drawing.Size(109, 13);
            this.lblCondicaoPagamento.TabIndex = 26;
            this.lblCondicaoPagamento.Text = "Condição Pagamento";
            // 
            // cbCondicaoPagamento
            // 
            this.cbCondicaoPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondicaoPagamento.Location = new System.Drawing.Point(522, 252);
            this.cbCondicaoPagamento.Name = "cbCondicaoPagamento";
            this.cbCondicaoPagamento.Size = new System.Drawing.Size(200, 21);
            this.cbCondicaoPagamento.TabIndex = 27;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(394, 285);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(58, 13);
            this.lblValorTotal.TabIndex = 28;
            this.lblValorTotal.Text = "Valor Total";
            // 
            // nudValorTotal
            // 
            this.nudValorTotal.DecimalPlaces = 2;
            this.nudValorTotal.Location = new System.Drawing.Point(522, 282);
            this.nudValorTotal.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudValorTotal.Name = "nudValorTotal";
            this.nudValorTotal.Size = new System.Drawing.Size(200, 20);
            this.nudValorTotal.TabIndex = 29;
            // 
            // chkPronto
            // 
            this.chkPronto.AutoSize = true;
            this.chkPronto.Location = new System.Drawing.Point(371, 143);
            this.chkPronto.Name = "chkPronto";
            this.chkPronto.Size = new System.Drawing.Size(57, 17);
            this.chkPronto.TabIndex = 30;
            this.chkPronto.Text = "Pronto";
            this.chkPronto.UseVisualStyleBackColor = true;
            // 
            // chkEntregue
            // 
            this.chkEntregue.AutoSize = true;
            this.chkEntregue.Location = new System.Drawing.Point(451, 143);
            this.chkEntregue.Name = "chkEntregue";
            this.chkEntregue.Size = new System.Drawing.Size(69, 17);
            this.chkEntregue.TabIndex = 31;
            this.chkEntregue.Text = "Entregue";
            this.chkEntregue.UseVisualStyleBackColor = true;
            // 
            // chkDevolvido
            // 
            this.chkDevolvido.AutoSize = true;
            this.chkDevolvido.Location = new System.Drawing.Point(541, 143);
            this.chkDevolvido.Name = "chkDevolvido";
            this.chkDevolvido.Size = new System.Drawing.Size(74, 17);
            this.chkDevolvido.TabIndex = 32;
            this.chkDevolvido.Text = "Devolvido";
            this.chkDevolvido.UseVisualStyleBackColor = true;
            // 
            // lblResponsavelDevolucao
            // 
            this.lblResponsavelDevolucao.AutoSize = true;
            this.lblResponsavelDevolucao.Location = new System.Drawing.Point(371, 173);
            this.lblResponsavelDevolucao.Name = "lblResponsavelDevolucao";
            this.lblResponsavelDevolucao.Size = new System.Drawing.Size(145, 13);
            this.lblResponsavelDevolucao.TabIndex = 33;
            this.lblResponsavelDevolucao.Text = "Responsável pela devolução";
            // 
            // txtResponsavelDevolucao
            // 
            this.txtResponsavelDevolucao.Location = new System.Drawing.Point(522, 170);
            this.txtResponsavelDevolucao.Name = "txtResponsavelDevolucao";
            this.txtResponsavelDevolucao.Size = new System.Drawing.Size(209, 20);
            this.txtResponsavelDevolucao.TabIndex = 34;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(140, 380);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 30);
            this.btnSalvar.TabIndex = 35;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lblDescricaoBoleira
            // 
            this.lblDescricaoBoleira.AutoSize = true;
            this.lblDescricaoBoleira.Location = new System.Drawing.Point(12, 315);
            this.lblDescricaoBoleira.Name = "lblDescricaoBoleira";
            this.lblDescricaoBoleira.Size = new System.Drawing.Size(79, 13);
            this.lblDescricaoBoleira.TabIndex = 36;
            this.lblDescricaoBoleira.Text = "Descrição Boleira";
            // 
            // txtDescricaoBoleira
            // 
            this.txtDescricaoBoleira.Location = new System.Drawing.Point(140, 312);
            this.txtDescricaoBoleira.Name = "txtDescricaoBoleira";
            this.txtDescricaoBoleira.Size = new System.Drawing.Size(200, 20);
            this.txtDescricaoBoleira.TabIndex = 37;
            // 
            // lblDescricaoTopo
            // 
            this.lblDescricaoTopo.AutoSize = true;
            this.lblDescricaoTopo.Location = new System.Drawing.Point(12, 345);
            this.lblDescricaoTopo.Name = "lblDescricaoTopo";
            this.lblDescricaoTopo.Size = new System.Drawing.Size(69, 13);
            this.lblDescricaoTopo.TabIndex = 38;
            this.lblDescricaoTopo.Text = "Descrição Topo";
            // 
            // txtDescricaoTopo
            // 
            this.txtDescricaoTopo.Location = new System.Drawing.Point(140, 342);
            this.txtDescricaoTopo.Name = "txtDescricaoTopo";
            this.txtDescricaoTopo.Size = new System.Drawing.Size(200, 20);
            this.txtDescricaoTopo.TabIndex = 39;
            // 
            // CadastrarLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 460);

            this.Controls.Add(this.lblDataEvento);
            this.Controls.Add(this.dtpDataEvento);
            this.Controls.Add(this.lblHorario);
            this.Controls.Add(this.txtHorario);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.lblAssessor);
            this.Controls.Add(this.cbAssessor);
            this.Controls.Add(this.lblDecorador);
            this.Controls.Add(this.cbDecorador);
            this.Controls.Add(this.lblLocal);
            this.Controls.Add(this.cbLocal);
            this.Controls.Add(this.lblBolo);
            this.Controls.Add(this.cbBolo);
            this.Controls.Add(this.lblBoleira);
            this.Controls.Add(this.cbBoleira);
            this.Controls.Add(this.lblTopo);
            this.Controls.Add(this.cbTopo);
            this.Controls.Add(this.lblOutro);
            this.Controls.Add(this.cbOutro);
            this.Controls.Add(this.lblObs);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.lblTipoLogistica);
            this.Controls.Add(this.cbTipoLogistica);
            this.Controls.Add(this.lblFormaPagamento);
            this.Controls.Add(this.cbFormaPagamento);
            this.Controls.Add(this.lblCondicaoPagamento);
            this.Controls.Add(this.cbCondicaoPagamento);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.nudValorTotal);
            this.Controls.Add(this.chkPronto);
            this.Controls.Add(this.chkEntregue);
            this.Controls.Add(this.chkDevolvido);
            this.Controls.Add(this.lblResponsavelDevolucao);
            this.Controls.Add(this.txtResponsavelDevolucao);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblDescricaoBoleira);
            this.Controls.Add(this.txtDescricaoBoleira);
            this.Controls.Add(this.lblDescricaoTopo);
            this.Controls.Add(this.txtDescricaoTopo);

            this.Name = "CadastrarLocacao";
            this.Text = "Cadastrar Locação";
            ((System.ComponentModel.ISupportInitialize)(this.nudValorTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}