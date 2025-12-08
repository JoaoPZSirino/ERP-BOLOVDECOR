namespace ERPBOLOV2
{
    partial class VizualizarDecorador
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvDecoradores;
        private System.Windows.Forms.Button btnAdicionar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvDecoradores = new System.Windows.Forms.DataGridView();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.txtFiltroNome = new System.Windows.Forms.TextBox();
            this.buttonFiltrarPorNome = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDecoradores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDecoradores
            // 
            this.dgvDecoradores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDecoradores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDecoradores.Location = new System.Drawing.Point(12, 12);
            this.dgvDecoradores.Name = "dgvDecoradores";
            this.dgvDecoradores.Size = new System.Drawing.Size(560, 300);
            this.dgvDecoradores.TabIndex = 0;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionar.Location = new System.Drawing.Point(12, 326);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(97, 23);
            this.btnAdicionar.TabIndex = 1;
            this.btnAdicionar.Text = "Adicionar Novo";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // txtFiltroNome
            // 
            this.txtFiltroNome.Location = new System.Drawing.Point(389, 326);
            this.txtFiltroNome.Name = "txtFiltroNome";
            this.txtFiltroNome.Size = new System.Drawing.Size(183, 20);
            this.txtFiltroNome.TabIndex = 2;
            // 
            // buttonFiltrarPorNome
            // 
            this.buttonFiltrarPorNome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFiltrarPorNome.Location = new System.Drawing.Point(286, 324);
            this.buttonFiltrarPorNome.Name = "buttonFiltrarPorNome";
            this.buttonFiltrarPorNome.Size = new System.Drawing.Size(97, 23);
            this.buttonFiltrarPorNome.TabIndex = 3;
            this.buttonFiltrarPorNome.Text = "Filtrar por Nome:";
            this.buttonFiltrarPorNome.UseVisualStyleBackColor = true;
            this.buttonFiltrarPorNome.Click += new System.EventHandler(this.buttonFiltrarPorNome_Click);
            // 
            // VizualizarDecorador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.buttonFiltrarPorNome);
            this.Controls.Add(this.txtFiltroNome);
            this.Controls.Add(this.dgvDecoradores);
            this.Controls.Add(this.btnAdicionar);
            this.Name = "VizualizarDecorador";
            this.Text = "Vizualizar Decoradores";
            this.Load += new System.EventHandler(this.VizualizarDecorador_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDecoradores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFiltroNome;
        private System.Windows.Forms.Button buttonFiltrarPorNome;
    }
}