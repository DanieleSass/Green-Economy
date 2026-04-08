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
            ((System.ComponentModel.ISupportInitialize)nmr_giorni).BeginInit();
            SuspendLayout();
            // 
            // lbl_giorni
            // 
            lbl_giorni.AutoSize = true;
            lbl_giorni.Location = new Point(85, 197);
            lbl_giorni.Name = "lbl_giorni";
            lbl_giorni.Size = new Size(215, 20);
            lbl_giorni.TabIndex = 0;
            lbl_giorni.Text = "Quanti giorni vuoi visualizzare?";
            // 
            // lbl_citta
            // 
            lbl_citta.AutoSize = true;
            lbl_citta.Location = new Point(85, 116);
            lbl_citta.Name = "lbl_citta";
            lbl_citta.Size = new Size(132, 20);
            lbl_citta.TabIndex = 1;
            lbl_citta.Text = "Città da analizzare";
            // 
            // cmb_citta
            // 
            cmb_citta.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmb_citta.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb_citta.FormattingEnabled = true;
            cmb_citta.Location = new Point(254, 116);
            cmb_citta.Name = "cmb_citta";
            cmb_citta.Size = new Size(277, 28);
            cmb_citta.TabIndex = 2;
            // 
            // nmr_giorni
            // 
            nmr_giorni.Location = new Point(322, 194);
            nmr_giorni.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmr_giorni.Name = "nmr_giorni";
            nmr_giorni.Size = new Size(116, 27);
            nmr_giorni.TabIndex = 3;
            nmr_giorni.TextAlign = HorizontalAlignment.Center;
            nmr_giorni.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // chc_dati
            // 
            chc_dati.FormattingEnabled = true;
            chc_dati.Location = new Point(97, 241);
            chc_dati.Name = "chc_dati";
            chc_dati.Size = new Size(434, 180);
            chc_dati.TabIndex = 4;
            // 
            // btn_salva
            // 
            btn_salva.BackColor = Color.FromArgb(128, 255, 128);
            btn_salva.Location = new Point(569, 161);
            btn_salva.Name = "btn_salva";
            btn_salva.Size = new Size(198, 60);
            btn_salva.TabIndex = 5;
            btn_salva.Text = "Salva ed Esci";
            btn_salva.UseVisualStyleBackColor = false;
            btn_salva.Click += btn_salva_Click;
            // 
            // btn_annulla
            // 
            btn_annulla.BackColor = Color.FromArgb(255, 192, 192);
            btn_annulla.Location = new Point(567, 242);
            btn_annulla.Name = "btn_annulla";
            btn_annulla.Size = new Size(200, 51);
            btn_annulla.TabIndex = 6;
            btn_annulla.Text = "Annulla ed Esci";
            btn_annulla.UseVisualStyleBackColor = false;
            btn_annulla.Click += btn_annulla_Click;
            // 
            // FImpostazioni
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(800, 450);
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
    }
}