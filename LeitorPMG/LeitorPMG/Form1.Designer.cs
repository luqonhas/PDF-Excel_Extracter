
namespace LeitorPMG
{
    partial class Form1
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_arquivo = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.btn_pasta = new System.Windows.Forms.Button();
            this.list = new System.Windows.Forms.ListBox();
            this.btn_enviar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btn_arquivo
            // 
            this.btn_arquivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_arquivo.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btn_arquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_arquivo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_arquivo.Location = new System.Drawing.Point(487, 30);
            this.btn_arquivo.Name = "btn_arquivo";
            this.btn_arquivo.Size = new System.Drawing.Size(100, 73);
            this.btn_arquivo.TabIndex = 0;
            this.btn_arquivo.Text = "Arquivo";
            this.btn_arquivo.UseVisualStyleBackColor = true;
            this.btn_arquivo.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox.Enabled = false;
            this.textBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(39, 30);
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(415, 73);
            this.textBox.TabIndex = 1;
            this.textBox.Text = "";
            // 
            // btn_pasta
            // 
            this.btn_pasta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_pasta.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btn_pasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pasta.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_pasta.Location = new System.Drawing.Point(616, 30);
            this.btn_pasta.Name = "btn_pasta";
            this.btn_pasta.Size = new System.Drawing.Size(100, 73);
            this.btn_pasta.TabIndex = 2;
            this.btn_pasta.Text = "Pasta";
            this.btn_pasta.UseVisualStyleBackColor = true;
            this.btn_pasta.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // list
            // 
            this.list.FormattingEnabled = true;
            this.list.Location = new System.Drawing.Point(39, 116);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(679, 173);
            this.list.TabIndex = 3;
            // 
            // btn_enviar
            // 
            this.btn_enviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_enviar.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btn_enviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_enviar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_enviar.Location = new System.Drawing.Point(251, 346);
            this.btn_enviar.Name = "btn_enviar";
            this.btn_enviar.Size = new System.Drawing.Size(238, 42);
            this.btn_enviar.TabIndex = 5;
            this.btn_enviar.Text = "Enviar";
            this.btn_enviar.UseVisualStyleBackColor = true;
            this.btn_enviar.Click += new System.EventHandler(this.btn_enviar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(39, 306);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(679, 23);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 405);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_enviar);
            this.Controls.Add(this.list);
            this.Controls.Add(this.btn_pasta);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.btn_arquivo);
            this.Name = "Form1";
            this.Text = "PMG Reader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_arquivo;
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.Button btn_pasta;
        private System.Windows.Forms.ListBox list;
        private System.Windows.Forms.Button btn_enviar;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

