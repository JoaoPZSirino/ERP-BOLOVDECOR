namespace ERPBOLOV2
{
    partial class VizualizarLocal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvLocais;
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
            this.dgvLocais = new System.Windows.Forms.DataGridView();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.buttonFiltrarPorNome = new System.Windows.Forms.Button();
            this.txtFiltroNome = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocais)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLocais
            // 
            this.dgvLocais.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLocais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocais.Location = new System.Drawing.Point(12, 12);
            this.dgvLocais.Name = "dgvLocais";
            this.dgvLocais.Size = new System.Drawing.Size(560, 300);
            this.dgvLocais.TabIndex = 0;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionar.Location = new System.Drawing.Point(12, 326);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(112, 23);
            this.btnAdicionar.TabIndex = 1;
            this.btnAdicionar.Text = "Adicionar Novo";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // buttonFiltrarPorNome
            // 
            this.buttonFiltrarPorNome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFiltrarPorNome.Location = new System.Drawing.Point(286, 326);
            this.buttonFiltrarPorNome.Name = "buttonFiltrarPorNome";
            this.buttonFiltrarPorNome.Size = new System.Drawing.Size(97, 23);
            this.buttonFiltrarPorNome.TabIndex = 4;
            this.buttonFiltrarPorNome.Text = "Filtrar por Nome:";
            this.buttonFiltrarPorNome.UseVisualStyleBackColor = true;
            // 
            // txtFiltroNome
            // 
            this.txtFiltroNome.Location = new System.Drawing.Point(389, 326);
            this.txtFiltroNome.Name = "txtFiltroNome";
            this.txtFiltroNome.Size = new System.Drawing.Size(183, 20);
            this.txtFiltroNome.TabIndex = 5;
            // 
            // VizualizarLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.txtFiltroNome);
            this.Controls.Add(this.buttonFiltrarPorNome);
            this.Controls.Add(this.dgvLocais);
            this.Controls.Add(this.btnAdicionar);
            this.Name = "VizualizarLocal";
            this.Text = "Vizualizar Locais";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocais)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFiltrarPorNome;
        private System.Windows.Forms.TextBox txtFiltroNome;
    }
}