namespace WindowsFormsApplication1
{
    partial class OpisStartowy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.fdgdfg = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fdgdfg
            // 
            this.fdgdfg.Enabled = false;
            this.fdgdfg.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fdgdfg.Location = new System.Drawing.Point(17, 63);
            this.fdgdfg.Multiline = true;
            this.fdgdfg.Name = "fdgdfg";
            this.fdgdfg.Size = new System.Drawing.Size(755, 254);
            this.fdgdfg.TabIndex = 0;
            this.fdgdfg.Text = "Program ma pomóc w wyborze odpowiedniego mieszkania, w tym celu wymagane jest wyb" +
    "ranie 5 kategori(np cena) aby jak najlepiej dobrać odpowiedniego kadydata.\r\n\r\nKl" +
    "iknij dalej aby zacząć proces.\r\n\r\n\r\n\r\n";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 323);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(755, 199);
            this.button1.TabIndex = 1;
            this.button1.Text = "Dalej";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(17, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(755, 45);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "System wspomagania decyzji zakupu mieszkań przy pomocy metody AHP\r\n";
            // 
            // OpisStartowy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fdgdfg);
            this.Name = "OpisStartowy";
            this.Text = "OpisStartowy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fdgdfg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}