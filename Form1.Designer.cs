namespace Task_1
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.PC = new System.Windows.Forms.Button();
            this.PLAYERS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PC
            // 
            this.PC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PC.Location = new System.Drawing.Point(95, 161);
            this.PC.Name = "PC";
            this.PC.Size = new System.Drawing.Size(484, 218);
            this.PC.TabIndex = 0;
            this.PC.Text = "Play with PC";
            this.PC.UseVisualStyleBackColor = true;
            this.PC.Click += new System.EventHandler(this.PC_Click);
            // 
            // PLAYERS
            // 
            this.PLAYERS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PLAYERS.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PLAYERS.Location = new System.Drawing.Point(756, 161);
            this.PLAYERS.Name = "PLAYERS";
            this.PLAYERS.Size = new System.Drawing.Size(484, 218);
            this.PLAYERS.TabIndex = 1;
            this.PLAYERS.Text = "Play on 2 players";
            this.PLAYERS.UseVisualStyleBackColor = true;
            this.PLAYERS.Click += new System.EventHandler(this.PLAYERS_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 633);
            this.Controls.Add(this.PLAYERS);
            this.Controls.Add(this.PC);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PC;
        private System.Windows.Forms.Button PLAYERS;
    }
}

