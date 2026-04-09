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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            plt_tempo_temperatura = new ScottPlot.WinForms.FormsPlot();
            btn_avvia = new Button();
            dgv_tempo_temperatura = new DataGridView();
            lbl_titolo = new Label();
            lbl_nomi = new Label();
            btn_rapporto_misure = new Button();
            btn_scelta = new Button();
            btn_esci = new Button();
            btn_info = new Button();
            lbl_citta = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_tempo_temperatura).BeginInit();
            SuspendLayout();
            // 
            // plt_tempo_temperatura
            // 
            plt_tempo_temperatura.Location = new Point(27, 167);
            plt_tempo_temperatura.Name = "plt_tempo_temperatura";
            plt_tempo_temperatura.Size = new Size(572, 338);
            plt_tempo_temperatura.TabIndex = 0;
            // 
            // btn_avvia
            // 
            btn_avvia.BackgroundImage = Properties.Resources.PlayButton;
            btn_avvia.BackgroundImageLayout = ImageLayout.Zoom;
            btn_avvia.Cursor = Cursors.Hand;
            btn_avvia.FlatAppearance.BorderSize = 0;
            btn_avvia.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_avvia.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_avvia.FlatStyle = FlatStyle.Flat;
            btn_avvia.ForeColor = Color.Transparent;
            btn_avvia.Location = new Point(27, 16);
            btn_avvia.Name = "btn_avvia";
            btn_avvia.Size = new Size(70, 70);
            btn_avvia.TabIndex = 1;
            btn_avvia.UseVisualStyleBackColor = false;
            btn_avvia.Click += btn_avvia_Click;
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(0, 64, 0);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_tempo_temperatura.DefaultCellStyle = dataGridViewCellStyle1;
            dgv_tempo_temperatura.Location = new Point(643, 167);
            dgv_tempo_temperatura.MultiSelect = false;
            dgv_tempo_temperatura.Name = "dgv_tempo_temperatura";
            dgv_tempo_temperatura.ReadOnly = true;
            dgv_tempo_temperatura.RowHeadersVisible = false;
            dgv_tempo_temperatura.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgv_tempo_temperatura.ScrollBars = ScrollBars.Vertical;
            dgv_tempo_temperatura.Size = new Size(520, 338);
            dgv_tempo_temperatura.TabIndex = 2;
            // 
            // lbl_titolo
            // 
            lbl_titolo.AutoSize = true;
            lbl_titolo.Font = new Font("Verdana", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_titolo.Location = new Point(365, 16);
            lbl_titolo.Name = "lbl_titolo";
            lbl_titolo.Size = new Size(486, 57);
            lbl_titolo.TabIndex = 3;
            lbl_titolo.Text = "GREEN ECONOMY";
            // 
            // lbl_nomi
            // 
            lbl_nomi.AutoSize = true;
            lbl_nomi.Font = new Font("Verdana", 10.2F, FontStyle.Bold);
            lbl_nomi.Location = new Point(781, 630);
            lbl_nomi.Name = "lbl_nomi";
            lbl_nomi.Size = new Size(403, 20);
            lbl_nomi.TabIndex = 4;
            lbl_nomi.Text = "Fatto da Davide Bisello e Sassaro Daniele";
            lbl_nomi.Click += lbl_nomi_Click;
            // 
            // btn_rapporto_misure
            // 
            btn_rapporto_misure.Cursor = Cursors.Hand;
            btn_rapporto_misure.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_rapporto_misure.Location = new Point(534, 562);
            btn_rapporto_misure.Name = "btn_rapporto_misure";
            btn_rapporto_misure.Size = new Size(157, 68);
            btn_rapporto_misure.TabIndex = 10;
            btn_rapporto_misure.Text = "Visualizza Rapporto";
            btn_rapporto_misure.UseVisualStyleBackColor = true;
            btn_rapporto_misure.Click += btn_rapporto_misure_Click;
            // 
            // btn_scelta
            // 
            btn_scelta.BackgroundImage = Properties.Resources.SettingsButton;
            btn_scelta.BackgroundImageLayout = ImageLayout.Zoom;
            btn_scelta.Cursor = Cursors.Hand;
            btn_scelta.FlatAppearance.BorderSize = 0;
            btn_scelta.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_scelta.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_scelta.FlatStyle = FlatStyle.Flat;
            btn_scelta.Location = new Point(1093, 16);
            btn_scelta.Name = "btn_scelta";
            btn_scelta.Size = new Size(70, 70);
            btn_scelta.TabIndex = 11;
            btn_scelta.UseVisualStyleBackColor = true;
            btn_scelta.Click += btn_scelta_Click;
            // 
            // btn_esci
            // 
            btn_esci.BackgroundImage = Properties.Resources.ExitButton;
            btn_esci.BackgroundImageLayout = ImageLayout.Zoom;
            btn_esci.Cursor = Cursors.Hand;
            btn_esci.FlatAppearance.BorderSize = 0;
            btn_esci.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_esci.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_esci.FlatStyle = FlatStyle.Flat;
            btn_esci.Location = new Point(27, 562);
            btn_esci.Name = "btn_esci";
            btn_esci.Size = new Size(66, 57);
            btn_esci.TabIndex = 12;
            btn_esci.UseVisualStyleBackColor = true;
            btn_esci.Click += btn_esci_Click;
            // 
            // btn_info
            // 
            btn_info.BackColor = Color.Transparent;
            btn_info.BackgroundImage = Properties.Resources.GuideButton;
            btn_info.BackgroundImageLayout = ImageLayout.Zoom;
            btn_info.Cursor = Cursors.Hand;
            btn_info.FlatAppearance.BorderSize = 0;
            btn_info.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_info.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_info.FlatStyle = FlatStyle.Flat;
            btn_info.ForeColor = Color.Transparent;
            btn_info.Location = new Point(134, 16);
            btn_info.Name = "btn_info";
            btn_info.Size = new Size(70, 70);
            btn_info.TabIndex = 13;
            btn_info.UseVisualStyleBackColor = false;
            btn_info.Click += btn_info_Click;
            // 
            // lbl_citta
            // 
            lbl_citta.AutoSize = true;
            lbl_citta.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_citta.Location = new Point(27, 131);
            lbl_citta.Name = "lbl_citta";
            lbl_citta.Size = new Size(67, 20);
            lbl_citta.TabIndex = 14;
            lbl_citta.Text = "Città: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LawnGreen;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1196, 659);
            Controls.Add(lbl_citta);
            Controls.Add(btn_info);
            Controls.Add(btn_esci);
            Controls.Add(btn_scelta);
            Controls.Add(btn_rapporto_misure);
            Controls.Add(lbl_nomi);
            Controls.Add(lbl_titolo);
            Controls.Add(dgv_tempo_temperatura);
            Controls.Add(btn_avvia);
            Controls.Add(plt_tempo_temperatura);
            Name = "Form1";
            Text = "Green Economy";
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
        private Button btn_rapporto_misure;
        private Button btn_scelta;
        private Button btn_esci;
        private Button btn_info;
        private Label lbl_citta;
    }
}
