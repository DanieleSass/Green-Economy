namespace Green_Economy
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            plt_tempo_temperatura = new ScottPlot.WinForms.FormsPlot();
            btn_avvia = new Button();
            dgv_tempo_temperatura = new DataGridView();
            lbl_titolo = new Label();
            lbl_nomi = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btn_rapporto_misure = new Button();
            btn_scelta = new Button();
            btn_esci = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_tempo_temperatura).BeginInit();
            SuspendLayout();
            // 
            // plt_tempo_temperatura
            // 
            plt_tempo_temperatura.Location = new Point(27, 202);
            plt_tempo_temperatura.Name = "plt_tempo_temperatura";
            plt_tempo_temperatura.Size = new Size(516, 338);
            plt_tempo_temperatura.TabIndex = 0;
            // 
            // btn_avvia
            // 
            btn_avvia.BackgroundImage = Properties.Resources.PlayButton;
            btn_avvia.BackgroundImageLayout = ImageLayout.Zoom;
            btn_avvia.FlatAppearance.BorderSize = 0;
            btn_avvia.FlatStyle = FlatStyle.Flat;
            btn_avvia.ForeColor = Color.Transparent;
            btn_avvia.Location = new Point(40, 57);
            btn_avvia.Name = "btn_avvia";
            btn_avvia.Size = new Size(100, 100);
            btn_avvia.TabIndex = 1;
            btn_avvia.UseVisualStyleBackColor = false;
            // 
            // dgv_tempo_temperatura
            // 
            dgv_tempo_temperatura.AllowUserToAddRows = false;
            dgv_tempo_temperatura.AllowUserToDeleteRows = false;
            dgv_tempo_temperatura.AllowUserToResizeColumns = false;
            dgv_tempo_temperatura.AllowUserToResizeRows = false;
            dgv_tempo_temperatura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_tempo_temperatura.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_tempo_temperatura.BackgroundColor = Color.FromArgb(192, 255, 192);
            dgv_tempo_temperatura.BorderStyle = BorderStyle.Fixed3D;
            dgv_tempo_temperatura.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgv_tempo_temperatura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(0, 64, 0);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_tempo_temperatura.DefaultCellStyle = dataGridViewCellStyle2;
            dgv_tempo_temperatura.Location = new Point(560, 202);
            dgv_tempo_temperatura.MultiSelect = false;
            dgv_tempo_temperatura.Name = "dgv_tempo_temperatura";
            dgv_tempo_temperatura.ReadOnly = true;
            dgv_tempo_temperatura.RowHeadersVisible = false;
            dgv_tempo_temperatura.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgv_tempo_temperatura.ScrollBars = ScrollBars.Vertical;
            dgv_tempo_temperatura.Size = new Size(421, 338);
            dgv_tempo_temperatura.TabIndex = 2;
            // 
            // lbl_titolo
            // 
            lbl_titolo.AutoSize = true;
            lbl_titolo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_titolo.Location = new Point(452, 32);
            lbl_titolo.Name = "lbl_titolo";
            lbl_titolo.Size = new Size(275, 41);
            lbl_titolo.TabIndex = 3;
            lbl_titolo.Text = "GREEN ECONOMY";
            // 
            // lbl_nomi
            // 
            lbl_nomi.AutoSize = true;
            lbl_nomi.Location = new Point(862, 589);
            lbl_nomi.Name = "lbl_nomi";
            lbl_nomi.Size = new Size(283, 20);
            lbl_nomi.TabIndex = 4;
            lbl_nomi.Text = "Fatto da Davide Bisello e Sassaro Daniele";
            lbl_nomi.Click += lbl_nomi_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(285, 73);
            label1.Name = "label1";
            label1.Size = new Size(815, 20);
            label1.TabIndex = 5;
            label1.Text = "meteo e inquinamento (Y) confrontati con tempo (X), ma non viene confrontato la x come meteo e inquiniamento come y";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(224, 93);
            label2.Name = "label2";
            label2.Size = new Size(876, 20);
            label2.TabIndex = 6;
            label2.Text = "si può fare altro form con altro grafico per questo (dovrebbe essere tipo y=mx), oppure fare calcoli basati su medie giornaliere ecc";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(247, 121);
            label3.Name = "label3";
            label3.Size = new Size(163, 20);
            label3.TabIndex = 7;
            label3.Text = "mettere unità di misura";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(452, 153);
            label4.Name = "label4";
            label4.Size = new Size(603, 20);
            label4.TabIndex = 8;
            label4.Text = "fare in modo che si possa devidere quale citta analizzare, con quanti giorni di analisi ecc...";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(194, 601);
            label5.Name = "label5";
            label5.Size = new Size(238, 20);
            label5.TabIndex = 9;
            label5.Text = "fare notifyIcon e contextMenuStrip";
            // 
            // btn_rapporto_misure
            // 
            btn_rapporto_misure.Location = new Point(987, 202);
            btn_rapporto_misure.Name = "btn_rapporto_misure";
            btn_rapporto_misure.Size = new Size(174, 104);
            btn_rapporto_misure.TabIndex = 10;
            btn_rapporto_misure.Text = "Visualizza il rapporto grafico tra inquinamento e temperatura";
            btn_rapporto_misure.UseVisualStyleBackColor = true;
            btn_rapporto_misure.Click += btn_rapporto_misure_Click;
            // 
            // btn_scelta
            // 
            btn_scelta.BackgroundImage = Properties.Resources.SettingsButton;
            btn_scelta.BackgroundImageLayout = ImageLayout.Zoom;
            btn_scelta.FlatAppearance.BorderSize = 0;
            btn_scelta.FlatStyle = FlatStyle.Flat;
            btn_scelta.Location = new Point(1020, 347);
            btn_scelta.Name = "btn_scelta";
            btn_scelta.Size = new Size(80, 80);
            btn_scelta.TabIndex = 11;
            btn_scelta.UseVisualStyleBackColor = true;
            btn_scelta.Click += btn_scelta_Click;
            // 
            // btn_esci
            // 
            btn_esci.BackgroundImage = Properties.Resources.ExitButton;
            btn_esci.BackgroundImageLayout = ImageLayout.Zoom;
            btn_esci.FlatAppearance.BorderSize = 0;
            btn_esci.FlatStyle = FlatStyle.Flat;
            btn_esci.Location = new Point(1020, 460);
            btn_esci.Name = "btn_esci";
            btn_esci.Size = new Size(80, 80);
            btn_esci.TabIndex = 12;
            btn_esci.UseVisualStyleBackColor = true;
            btn_esci.Click += btn_esci_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 255, 128);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1320, 659);
            Controls.Add(btn_esci);
            Controls.Add(btn_scelta);
            Controls.Add(btn_rapporto_misure);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbl_nomi);
            Controls.Add(lbl_titolo);
            Controls.Add(dgv_tempo_temperatura);
            Controls.Add(btn_avvia);
            Controls.Add(plt_tempo_temperatura);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_tempo_temperatura).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot plt_tempo_temperatura;
        private Button btn_avvia;
        private DataGridView dgv_tempo_temperatura;
        private Label lbl_titolo;
        private Label lbl_nomi;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btn_rapporto_misure;
        private Button btn_scelta;
        private Button btn_esci;
    }
}
