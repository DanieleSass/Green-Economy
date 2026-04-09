namespace Green_Economy
{
    partial class FRelazioneDati
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
            plt_rapporto = new ScottPlot.WinForms.FormsPlot();
            dgv_dati = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_dati).BeginInit();
            SuspendLayout();
            // 
            // plt_rapporto
            // 
            plt_rapporto.Location = new Point(24, 49);
            plt_rapporto.Name = "plt_rapporto";
            plt_rapporto.Size = new Size(562, 317);
            plt_rapporto.TabIndex = 0;
            // 
            // dgv_dati
            // 
            dgv_dati.AllowUserToAddRows = false;
            dgv_dati.AllowUserToDeleteRows = false;
            dgv_dati.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_dati.Location = new Point(624, 107);
            dgv_dati.Name = "dgv_dati";
            dgv_dati.ReadOnly = true;
            dgv_dati.RowHeadersWidth = 51;
            dgv_dati.Size = new Size(478, 159);
            dgv_dati.TabIndex = 1;
            // 
            // FRelazioneDati
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LawnGreen;
            ClientSize = new Size(1126, 426);
            Controls.Add(dgv_dati);
            Controls.Add(plt_rapporto);
            Name = "FRelazioneDati";
            Text = "FRelazioneDati";
            Load += FRelazioneDati_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_dati).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot plt_rapporto;
        private DataGridView dgv_dati;
    }
}