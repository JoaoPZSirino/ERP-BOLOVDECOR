namespace ERPBOLOV2
{
    partial class GerarContrato
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label labelProdutos;
        private System.Windows.Forms.CheckedListBox clbProdutos;
        private System.Windows.Forms.Label labelTipoFesta;
        private System.Windows.Forms.TextBox txtTipoFesta;
        private System.Windows.Forms.Label labelAnfitriao;
        private System.Windows.Forms.TextBox txtAnfitriao;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label labelHorario;
        private System.Windows.Forms.DateTimePicker dtpHorario;
        private System.Windows.Forms.Label labelLocal;
        private System.Windows.Forms.ComboBox cmbLocal;
        private System.Windows.Forms.Label labelAssessor;
        private System.Windows.Forms.ComboBox cmbAssessor;
        private System.Windows.Forms.Label labelDecorador;
        private System.Windows.Forms.ComboBox cmbDecorador;
        private System.Windows.Forms.Label labelValorTotal;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label labelFormaPagamento;
        private System.Windows.Forms.ComboBox cmbFormaPagamento;
        private System.Windows.Forms.Button btnSalvar;

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
            this.labelCliente = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.labelProdutos = new System.Windows.Forms.Label();
            this.clbProdutos = new System.Windows.Forms.CheckedListBox();
            this.labelTipoFesta = new System.Windows.Forms.Label();
            this.txtTipoFesta = new System.Windows.Forms.TextBox();
            this.labelAnfitriao = new System.Windows.Forms.Label();
            this.txtAnfitriao = new System.Windows.Forms.TextBox();
            this.labelData = new System.Windows.Forms.Label();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.labelHorario = new System.Windows.Forms.Label();
            this.dtpHorario = new System.Windows.Forms.DateTimePicker();
            this.labelLocal = new System.Windows.Forms.Label();
            this.cmbLocal = new System.Windows.Forms.ComboBox();
            this.labelAssessor = new System.Windows.Forms.Label();
            this.cmbAssessor = new System.Windows.Forms.ComboBox();
            this.labelDecorador = new System.Windows.Forms.Label();
            this.cmbDecorador = new System.Windows.Forms.ComboBox();
            this.labelValorTotal = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.labelFormaPagamento = new System.Windows.Forms.Label();
            this.cmbFormaPagamento = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(12, 15);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(42, 13);
            this.labelCliente.TabIndex = 0;
            this.labelCliente.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(120, 12);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(300, 21);
            this.cmbCliente.TabIndex = 1;
            // 
            // labelProdutos
            // 
            this.labelProdutos.AutoSize = true;
            this.labelProdutos.Location = new System.Drawing.Point(12, 50);
            this.labelProdutos.Name = "labelProdutos";
            this.labelProdutos.Size = new System.Drawing.Size(52, 13);
            this.labelProdutos.TabIndex = 2;
            this.labelProdutos.Text = "Produtos:";
            // 
            // clbProdutos
            // 
            this.clbProdutos.FormattingEnabled = true;
            this.clbProdutos.Location = new System.Drawing.Point(120, 50);
            this.clbProdutos.Name = "clbProdutos";
            this.clbProdutos.Size = new System.Drawing.Size(300, 94);
            this.clbProdutos.TabIndex = 3;
            this.clbProdutos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbProdutos_ItemCheck);
            // 
            // labelTipoFesta
            // 
            this.labelTipoFesta.AutoSize = true;
            this.labelTipoFesta.Location = new System.Drawing.Point(12, 160);
            this.labelTipoFesta.Name = "labelTipoFesta";
            this.labelTipoFesta.Size = new System.Drawing.Size(60, 13);
            this.labelTipoFesta.TabIndex = 4;
            this.labelTipoFesta.Text = "Tipo Festa:";
            // 
            // txtTipoFesta
            // 
            this.txtTipoFesta.Location = new System.Drawing.Point(120, 157);
            this.txtTipoFesta.Name = "txtTipoFesta";
            this.txtTipoFesta.Size = new System.Drawing.Size(300, 20);
            this.txtTipoFesta.TabIndex = 5;
            // 
            // labelAnfitriao
            // 
            this.labelAnfitriao.AutoSize = true;
            this.labelAnfitriao.Location = new System.Drawing.Point(12, 190);
            this.labelAnfitriao.Name = "labelAnfitriao";
            this.labelAnfitriao.Size = new System.Drawing.Size(59, 13);
            this.labelAnfitriao.TabIndex = 6;
            this.labelAnfitriao.Text = "Anfitrião(s):";
            // 
            // txtAnfitriao
            // 
            this.txtAnfitriao.Location = new System.Drawing.Point(120, 187);
            this.txtAnfitriao.Name = "txtAnfitriao";
            this.txtAnfitriao.Size = new System.Drawing.Size(300, 20);
            this.txtAnfitriao.TabIndex = 7;
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(12, 220);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(33, 13);
            this.labelData.TabIndex = 8;
            this.labelData.Text = "Data:";
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(120, 216);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(120, 20);
            this.dtpData.TabIndex = 9;
            // 
            // labelHorario
            // 
            this.labelHorario.AutoSize = true;
            this.labelHorario.Location = new System.Drawing.Point(260, 220);
            this.labelHorario.Name = "labelHorario";
            this.labelHorario.Size = new System.Drawing.Size(44, 13);
            this.labelHorario.TabIndex = 10;
            this.labelHorario.Text = "Horário:";
            // 
            // dtpHorario
            // 
            this.dtpHorario.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHorario.Location = new System.Drawing.Point(320, 216);
            this.dtpHorario.Name = "dtpHorario";
            this.dtpHorario.ShowUpDown = true;
            this.dtpHorario.Size = new System.Drawing.Size(100, 20);
            this.dtpHorario.TabIndex = 11;
            // 
            // labelLocal
            // 
            this.labelLocal.AutoSize = true;
            this.labelLocal.Location = new System.Drawing.Point(12, 255);
            this.labelLocal.Name = "labelLocal";
            this.labelLocal.Size = new System.Drawing.Size(36, 13);
            this.labelLocal.TabIndex = 12;
            this.labelLocal.Text = "Local:";
            // 
            // cmbLocal
            // 
            this.cmbLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Location = new System.Drawing.Point(120, 252);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.Size = new System.Drawing.Size(300, 21);
            this.cmbLocal.TabIndex = 13;
            // 
            // labelAssessor
            // 
            this.labelAssessor.AutoSize = true;
            this.labelAssessor.Location = new System.Drawing.Point(12, 290);
            this.labelAssessor.Name = "labelAssessor";
            this.labelAssessor.Size = new System.Drawing.Size(52, 13);
            this.labelAssessor.TabIndex = 14;
            this.labelAssessor.Text = "Assessor:";
            // 
            // cmbAssessor
            // 
            this.cmbAssessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssessor.FormattingEnabled = true;
            this.cmbAssessor.Location = new System.Drawing.Point(120, 287);
            this.cmbAssessor.Name = "cmbAssessor";
            this.cmbAssessor.Size = new System.Drawing.Size(300, 21);
            this.cmbAssessor.TabIndex = 15;
            // 
            // labelDecorador
            // 
            this.labelDecorador.AutoSize = true;
            this.labelDecorador.Location = new System.Drawing.Point(12, 325);
            this.labelDecorador.Name = "labelDecorador";
            this.labelDecorador.Size = new System.Drawing.Size(60, 13);
            this.labelDecorador.TabIndex = 16;
            this.labelDecorador.Text = "Decorador:";
            // 
            // cmbDecorador
            // 
            this.cmbDecorador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDecorador.FormattingEnabled = true;
            this.cmbDecorador.Location = new System.Drawing.Point(120, 322);
            this.cmbDecorador.Name = "cmbDecorador";
            this.cmbDecorador.Size = new System.Drawing.Size(300, 21);
            this.cmbDecorador.TabIndex = 17;
            // 
            // labelValorTotal
            // 
            this.labelValorTotal.AutoSize = true;
            this.labelValorTotal.Location = new System.Drawing.Point(12, 360);
            this.labelValorTotal.Name = "labelValorTotal";
            this.labelValorTotal.Size = new System.Drawing.Size(61, 13);
            this.labelValorTotal.TabIndex = 18;
            this.labelValorTotal.Text = "Valor Total:";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(120, 360);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(42, 13);
            this.lblValorTotal.TabIndex = 19;
            this.lblValorTotal.Text = "R$0,00";
            this.lblValorTotal.Click += new System.EventHandler(this.lblValorTotal_Click);
            // 
            // labelFormaPagamento
            // 
            this.labelFormaPagamento.AutoSize = true;
            this.labelFormaPagamento.Location = new System.Drawing.Point(12, 390);
            this.labelFormaPagamento.Name = "labelFormaPagamento";
            this.labelFormaPagamento.Size = new System.Drawing.Size(111, 13);
            this.labelFormaPagamento.TabIndex = 20;
            this.labelFormaPagamento.Text = "Forma de Pagamento:";
            // 
            // cmbFormaPagamento
            // 
            this.cmbFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPagamento.FormattingEnabled = true;
            this.cmbFormaPagamento.Location = new System.Drawing.Point(120, 387);
            this.cmbFormaPagamento.Name = "cmbFormaPagamento";
            this.cmbFormaPagamento.Size = new System.Drawing.Size(150, 21);
            this.cmbFormaPagamento.TabIndex = 21;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(345, 414);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 22;
            this.btnSalvar.Text = "Gerar Contrato";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // ContratoLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 449);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.labelProdutos);
            this.Controls.Add(this.clbProdutos);
            this.Controls.Add(this.labelTipoFesta);
            this.Controls.Add(this.txtTipoFesta);
            this.Controls.Add(this.labelAnfitriao);
            this.Controls.Add(this.txtAnfitriao);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.labelHorario);
            this.Controls.Add(this.dtpHorario);
            this.Controls.Add(this.labelLocal);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.labelAssessor);
            this.Controls.Add(this.cmbAssessor);
            this.Controls.Add(this.labelDecorador);
            this.Controls.Add(this.cmbDecorador);
            this.Controls.Add(this.labelValorTotal);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.labelFormaPagamento);
            this.Controls.Add(this.cmbFormaPagamento);
            this.Controls.Add(this.btnSalvar);
            this.Name = "ContratoLocacao";
            this.Text = "Contrato de Locação";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}