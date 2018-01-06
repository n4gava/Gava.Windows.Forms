namespace Gava.Windows.Forms.Example
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gavaButton1 = new Gava.Windows.Forms.GavaButton();
            this.SuspendLayout();
            // 
            // gavaButton1
            // 
            this.gavaButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(138)))), ((int)(((byte)(228)))));
            this.gavaButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(138)))), ((int)(((byte)(228)))));
            this.gavaButton1.BorderSize = 0;
            this.gavaButton1.ButtonType = Gava.Windows.Themes.EButtonTypes.Main;
            this.gavaButton1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(197)))), ((int)(((byte)(255)))));
            this.gavaButton1.DisabledForeColor = System.Drawing.Color.White;
            this.gavaButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(138)))), ((int)(((byte)(228)))));
            this.gavaButton1.FlatAppearance.BorderSize = 0;
            this.gavaButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(177)))), ((int)(((byte)(216)))));
            this.gavaButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(124)))), ((int)(((byte)(205)))));
            this.gavaButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gavaButton1.ForeColor = System.Drawing.Color.White;
            this.gavaButton1.Location = new System.Drawing.Point(149, 106);
            this.gavaButton1.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(177)))), ((int)(((byte)(216)))));
            this.gavaButton1.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(124)))), ((int)(((byte)(205)))));
            this.gavaButton1.Name = "gavaButton1";
            this.gavaButton1.Size = new System.Drawing.Size(121, 48);
            this.gavaButton1.TabIndex = 1;
            this.gavaButton1.Text = "gavaButton1";
            this.gavaButton1.ToolTip = "Clique aqui!";
            this.gavaButton1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(623, 494);
            this.Controls.Add(this.gavaButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "Gava.Windows.Forms.Example - Gava Example";
            this.ResumeLayout(false);

        }

        #endregion

        private GavaButton gavaButton1;
    }
}

