namespace ERPBOLOV2
{
    partial class VizualizarAssessor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvAssessores;
        private System.Windows.Forms.Button btnAdicionar;

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
            this.dgvAssessores = new System.Windows.Forms.DataGridView();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.txtFiltroPorNome = new System.Windows.Forms.TextBox();
            this.buttonFiltroPorNome = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssessores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAssessores
            // 
            this.dgvAssessores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAssessores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssessores.Location = new System.Drawing.Point(12, 12);
            this.dgvAssessores.Name = "dgvAssessores";
            this.dgvAssessores.Size = new System.Drawing.Size(560, 300);
            this.dgvAssessores.TabIndex = 0;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionar.Location = new System.Drawing.Point(12, 318);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(96, 23);
            this.btnAdicionar.TabIndex = 1;
            this.btnAdicionar.Text = "Adicionar Novo";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // txtFiltroPorNome
            // 
            this.txtFiltroPorNome.Location = new System.Drawing.Point(383, 320);
            this.txtFiltroPorNome.Name = "txtFiltroPorNome";
            this.txtFiltroPorNome.Size = new System.Drawing.Size(189, 20);
            this.txtFiltroPorNome.TabIndex = 2;
            // 
            // buttonFiltroPorNome
            // 
            this.buttonFiltroPorNome.Location = new System.Drawing.Point(273, 318);
            this.buttonFiltroPorNome.Name = "buttonFiltroPorNome";
            this.buttonFiltroPorNome.Size = new System.Drawing.Size(104, 23);
            this.buttonFiltroPorNome.TabIndex = 3;
            this.buttonFiltroPorNome.Text = "Filtrar por Nome:";
            this.buttonFiltroPorNome.UseVisualStyleBackColor = true;
            this.buttonFiltroPorNome.Click += new System.EventHandler(this.buttonFiltroPorNome_Click);
            // 
            // VizualizarAssessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.buttonFiltroPorNome);
            this.Controls.Add(this.txtFiltroPorNome);
            this.Controls.Add(this.dgvAssessores);
            this.Controls.Add(this.btnAdicionar);
            this.Name = "VizualizarAssessor";
            this.Text = "Vizualizar Assessores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssessores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFiltroPorNome;
        private System.Windows.Forms.Button buttonFiltroPorNome;
    }
}