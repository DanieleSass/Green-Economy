namespace Green_Economy
{
    partial class FImpostazioni
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
            lbl_giorni = new Label();
            lbl_citta = new Label();
            cmb_citta = new ComboBox();
            nmr_giorni = new NumericUpDown();
            chc_dati = new CheckedListBox();
            btn_salva = new Button();
            btn_annulla = new Button();
            lbl_title = new Label();
            ((System.ComponentModel.ISupportInitialize)nmr_giorni).BeginInit();
            SuspendLayout();
            // 
            // lbl_giorni
            // 
            lbl_giorni.AutoSize = true;
            lbl_giorni.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_giorni.Location = new Point(81, 237);
            lbl_giorni.Name = "lbl_giorni";
            lbl_giorni.Size = new Size(197, 28);
            lbl_giorni.TabIndex = 0;
            lbl_giorni.Text = "Giorni da visualizzare";
            // 
            // lbl_citta
            // 
            lbl_citta.AutoSize = true;
            lbl_citta.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_citta.Location = new Point(81, 151);
            lbl_citta.Name = "lbl_citta";
            lbl_citta.Size = new Size(171, 28);
            lbl_citta.TabIndex = 1;
            lbl_citta.Text = "Città da analizzare";
            // 
            // cmb_citta
            // 
            cmb_citta.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmb_citta.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb_citta.FormattingEnabled = true;
            cmb_citta.Location = new Point(258, 155);
            cmb_citta.Name = "cmb_citta";
            cmb_citta.Size = new Size(277, 28);
            cmb_citta.TabIndex = 2;
            // 
            // nmr_giorni
            // 
            nmr_giorni.Location = new Point(301, 242);
            nmr_giorni.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_giorni.Name = "nmr_giorni";
            nmr_giorni.Size = new Size(234, 27);
            nmr_giorni.TabIndex = 3;
            nmr_giorni.TextAlign = HorizontalAlignment.Center;
            nmr_giorni.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // chc_dati
            // 
            chc_dati.FormattingEnabled = true;
            chc_dati.Location = new Point(600, 155);
            chc_dati.Name = "chc_dati";
            chc_dati.Size = new Size(143, 114);
            chc_dati.TabIndex = 4;
            // 
            // btn_salva
            // 
            btn_salva.BackColor = Color.PaleGreen;
            btn_salva.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_salva.Location = new Point(147, 357);
            btn_salva.Name = "btn_salva";
            btn_salva.Size = new Size(198, 60);
            btn_salva.TabIndex = 5;
            btn_salva.Text = "Salva ed Esci";
            btn_salva.UseVisualStyleBackColor = false;
            btn_salva.Click += btn_salva_Click;
            // 
            // btn_annulla
            // 
            btn_annulla.BackColor = Color.FromArgb(255, 128, 128);
            btn_annulla.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_annulla.Location = new Point(471, 357);
            btn_annulla.Name = "btn_annulla";
            btn_annulla.Size = new Size(198, 60);
            btn_annulla.TabIndex = 6;
            btn_annulla.Text = "Annulla ed Esci";
            btn_annulla.UseVisualStyleBackColor = false;
            btn_annulla.Click += btn_annulla_Click;
            // 
            // lbl_title
            // 
            lbl_title.Font = new Font("Verdana", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_title.Location = new Point(207, 9);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(437, 64);
            lbl_title.TabIndex = 7;
            lbl_title.Text = "IMPOSTAZIONI";
            // 
            // FImpostazioni
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LawnGreen;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_title);
            Controls.Add(btn_annulla);
            Controls.Add(btn_salva);
            Controls.Add(chc_dati);
            Controls.Add(nmr_giorni);
            Controls.Add(cmb_citta);
            Controls.Add(lbl_citta);
            Controls.Add(lbl_giorni);
            Name = "FImpostazioni";
            Text = "FImpostazioni";
            Load += FImpostazioni_Load;
            ((System.ComponentModel.ISupportInitialize)nmr_giorni).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_giorni;
        private Label lbl_citta;
        private ComboBox cmb_citta;
        private NumericUpDown nmr_giorni;
        private CheckedListBox chc_dati;
        private Button btn_salva;
        private Button btn_annulla;
        private Label lbl_title;
    }
}