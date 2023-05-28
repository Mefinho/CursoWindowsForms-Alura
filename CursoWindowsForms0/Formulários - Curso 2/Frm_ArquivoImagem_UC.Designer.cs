namespace CursoWindowsForms0.Formulários___User_Control
{
    partial class Frm_ArquivoImagem_UC
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lbl_ArquivoIMG = new System.Windows.Forms.Label();
            this.Pic_Imagem = new System.Windows.Forms.PictureBox();
            this.Btn_Cor = new System.Windows.Forms.Button();
            this.Btn_Fonte = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Imagem)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_ArquivoIMG
            // 
            this.Lbl_ArquivoIMG.AutoSize = true;
            this.Lbl_ArquivoIMG.Location = new System.Drawing.Point(17, 36);
            this.Lbl_ArquivoIMG.Name = "Lbl_ArquivoIMG";
            this.Lbl_ArquivoIMG.Size = new System.Drawing.Size(35, 13);
            this.Lbl_ArquivoIMG.TabIndex = 0;
            this.Lbl_ArquivoIMG.Text = "label1";
            // 
            // Pic_Imagem
            // 
            this.Pic_Imagem.Location = new System.Drawing.Point(20, 70);
            this.Pic_Imagem.Name = "Pic_Imagem";
            this.Pic_Imagem.Size = new System.Drawing.Size(261, 209);
            this.Pic_Imagem.TabIndex = 1;
            this.Pic_Imagem.TabStop = false;
            // 
            // Btn_Cor
            // 
            this.Btn_Cor.Location = new System.Drawing.Point(512, 70);
            this.Btn_Cor.Name = "Btn_Cor";
            this.Btn_Cor.Size = new System.Drawing.Size(101, 23);
            this.Btn_Cor.TabIndex = 2;
            this.Btn_Cor.Text = "Trocar Cor";
            this.Btn_Cor.UseVisualStyleBackColor = true;
            this.Btn_Cor.Click += new System.EventHandler(this.Btn_Cor_Click);
            // 
            // Btn_Fonte
            // 
            this.Btn_Fonte.Location = new System.Drawing.Point(512, 113);
            this.Btn_Fonte.Name = "Btn_Fonte";
            this.Btn_Fonte.Size = new System.Drawing.Size(101, 23);
            this.Btn_Fonte.TabIndex = 3;
            this.Btn_Fonte.Text = "Trocar Fonte";
            this.Btn_Fonte.UseVisualStyleBackColor = true;
            this.Btn_Fonte.Click += new System.EventHandler(this.Btn_Fonte_Click);
            // 
            // Frm_ArquivoImagem_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Btn_Fonte);
            this.Controls.Add(this.Btn_Cor);
            this.Controls.Add(this.Pic_Imagem);
            this.Controls.Add(this.Lbl_ArquivoIMG);
            this.Name = "Frm_ArquivoImagem_UC";
            this.Size = new System.Drawing.Size(639, 394);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Imagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_ArquivoIMG;
        private System.Windows.Forms.PictureBox Pic_Imagem;
        private System.Windows.Forms.Button Btn_Cor;
        private System.Windows.Forms.Button Btn_Fonte;
    }
}
