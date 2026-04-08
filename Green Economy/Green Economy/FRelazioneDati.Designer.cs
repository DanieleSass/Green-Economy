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
            SuspendLayout();
            // 
            // plt_rapporto
            // 
            plt_rapporto.Location = new Point(165, 78);
            plt_rapporto.Name = "plt_rapporto";
            plt_rapporto.Size = new Size(562, 317);
            plt_rapporto.TabIndex = 0;
            // 
            // FRelazioneDati
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(800, 450);
            Controls.Add(plt_rapporto);
            Name = "FRelazioneDati";
            Text = "FRelazioneDati";
            Load += FRelazioneDati_Load;
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot plt_rapporto;
    }
}