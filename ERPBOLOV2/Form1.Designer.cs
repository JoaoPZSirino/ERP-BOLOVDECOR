namespace ERPBOLOV2
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarProdutosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assessoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarAssessoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decoradoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarDecoradoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarLocaisToolStripMenuItem;
        private System.Windows.Forms.Button btnGerarContrato;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarProdutosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assessoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarAssessoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decoradoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarDecoradoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarLocaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGerarContrato = new System.Windows.Forms.Button();
            this.cadastrarProdutosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarAcessoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarDecoradoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarLocaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.produtosToolStripMenuItem,
            this.assessoresToolStripMenuItem,
            this.decoradoresToolStripMenuItem,
            this.locaisToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizarClientesToolStripMenuItem,
            this.cadastrarClientesToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // visualizarClientesToolStripMenuItem
            // 
            this.visualizarClientesToolStripMenuItem.Name = "visualizarClientesToolStripMenuItem";
            this.visualizarClientesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.visualizarClientesToolStripMenuItem.Text = "Visualizar Clientes";
            this.visualizarClientesToolStripMenuItem.Click += new System.EventHandler(this.visualizarClientesToolStripMenuItem_Click);
            // 
            // cadastrarClientesToolStripMenuItem
            // 
            this.cadastrarClientesToolStripMenuItem.Name = "cadastrarClientesToolStripMenuItem";
            this.cadastrarClientesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.cadastrarClientesToolStripMenuItem.Text = "Cadastrar Clientes";
            this.cadastrarClientesToolStripMenuItem.Click += new System.EventHandler(this.cadastrarClientesToolStripMenuItem_Click);
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizarProdutosToolStripMenuItem,
            this.cadastrarProdutosToolStripMenuItem});
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.produtosToolStripMenuItem.Text = "Produtos";
            // 
            // visualizarProdutosToolStripMenuItem
            // 
            this.visualizarProdutosToolStripMenuItem.Name = "visualizarProdutosToolStripMenuItem";
            this.visualizarProdutosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.visualizarProdutosToolStripMenuItem.Text = "Visualizar Produtos";
            this.visualizarProdutosToolStripMenuItem.Click += new System.EventHandler(this.visualizarProdutosToolStripMenuItem_Click);
            // 
            // assessoresToolStripMenuItem
            // 
            this.assessoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizarAssessoresToolStripMenuItem,
            this.cadastrarAcessoresToolStripMenuItem});
            this.assessoresToolStripMenuItem.Name = "assessoresToolStripMenuItem";
            this.assessoresToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.assessoresToolStripMenuItem.Text = "Assessores";
            // 
            // visualizarAssessoresToolStripMenuItem
            // 
            this.visualizarAssessoresToolStripMenuItem.Name = "visualizarAssessoresToolStripMenuItem";
            this.visualizarAssessoresToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.visualizarAssessoresToolStripMenuItem.Text = "Visualizar Assessores";
            this.visualizarAssessoresToolStripMenuItem.Click += new System.EventHandler(this.visualizarAssessoresToolStripMenuItem_Click);
            // 
            // decoradoresToolStripMenuItem
            // 
            this.decoradoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizarDecoradoresToolStripMenuItem,
            this.cadastrarDecoradoresToolStripMenuItem});
            this.decoradoresToolStripMenuItem.Name = "decoradoresToolStripMenuItem";
            this.decoradoresToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.decoradoresToolStripMenuItem.Text = "Decoradores";
            // 
            // visualizarDecoradoresToolStripMenuItem
            // 
            this.visualizarDecoradoresToolStripMenuItem.Name = "visualizarDecoradoresToolStripMenuItem";
            this.visualizarDecoradoresToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.visualizarDecoradoresToolStripMenuItem.Text = "Visualizar Decoradores";
            this.visualizarDecoradoresToolStripMenuItem.Click += new System.EventHandler(this.visualizarDecoradoresToolStripMenuItem_Click);
            // 
            // locaisToolStripMenuItem
            // 
            this.locaisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizarLocaisToolStripMenuItem,
            this.cadastrarLocaisToolStripMenuItem});
            this.locaisToolStripMenuItem.Name = "locaisToolStripMenuItem";
            this.locaisToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.locaisToolStripMenuItem.Text = "Locais";
            // 
            // visualizarLocaisToolStripMenuItem
            // 
            this.visualizarLocaisToolStripMenuItem.Name = "visualizarLocaisToolStripMenuItem";
            this.visualizarLocaisToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.visualizarLocaisToolStripMenuItem.Text = "Visualizar Locais";
            this.visualizarLocaisToolStripMenuItem.Click += new System.EventHandler(this.visualizarLocaisToolStripMenuItem_Click);
            // 
            // btnGerarContrato
            // 
            this.btnGerarContrato.Location = new System.Drawing.Point(15, 40);
            this.btnGerarContrato.Name = "btnGerarContrato";
            this.btnGerarContrato.Size = new System.Drawing.Size(140, 30);
            this.btnGerarContrato.TabIndex = 1;
            this.btnGerarContrato.Text = "Gerar Contrato";
            this.btnGerarContrato.UseVisualStyleBackColor = true;
            this.btnGerarContrato.Click += new System.EventHandler(this.btnGerarContrato_Click);
            // 
            // cadastrarProdutosToolStripMenuItem
            // 
            this.cadastrarProdutosToolStripMenuItem.Name = "cadastrarProdutosToolStripMenuItem";
            this.cadastrarProdutosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cadastrarProdutosToolStripMenuItem.Text = "Cadastrar Produtos";
            this.cadastrarProdutosToolStripMenuItem.Click += new System.EventHandler(this.cadastrarProdutosToolStripMenuItem_Click);
            // 
            // cadastrarAcessoresToolStripMenuItem
            // 
            this.cadastrarAcessoresToolStripMenuItem.Name = "cadastrarAcessoresToolStripMenuItem";
            this.cadastrarAcessoresToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.cadastrarAcessoresToolStripMenuItem.Text = "Cadastrar Acessores";
            this.cadastrarAcessoresToolStripMenuItem.Click += new System.EventHandler(this.cadastrarAcessoresToolStripMenuItem_Click);
            // 
            // cadastrarDecoradoresToolStripMenuItem
            // 
            this.cadastrarDecoradoresToolStripMenuItem.Name = "cadastrarDecoradoresToolStripMenuItem";
            this.cadastrarDecoradoresToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.cadastrarDecoradoresToolStripMenuItem.Text = "Cadastrar Decoradores";
            this.cadastrarDecoradoresToolStripMenuItem.Click += new System.EventHandler(this.cadastrarDecoradoresToolStripMenuItem_Click);
            // 
            // cadastrarLocaisToolStripMenuItem
            // 
            this.cadastrarLocaisToolStripMenuItem.Name = "cadastrarLocaisToolStripMenuItem";
            this.cadastrarLocaisToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cadastrarLocaisToolStripMenuItem.Text = "Cadastrar Locais";
            this.cadastrarLocaisToolStripMenuItem.Click += new System.EventHandler(this.cadastrarLocaisToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGerarContrato);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem cadastrarClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarProdutosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarAcessoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarDecoradoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarLocaisToolStripMenuItem;
    }
}

