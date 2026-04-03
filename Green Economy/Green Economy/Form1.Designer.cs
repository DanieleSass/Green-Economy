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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            ((System.ComponentModel.ISupportInitialize)dgv_tempo_temperatura).BeginInit();
            SuspendLayout();
            // 
            // plt_tempo_temperatura
            // 
            plt_tempo_temperatura.Location = new Point(27, 138);
            plt_tempo_temperatura.Name = "plt_tempo_temperatura";
            plt_tempo_temperatura.Size = new Size(516, 335);
            plt_tempo_temperatura.TabIndex = 0;
            // 
            // btn_avvia
            // 
            btn_avvia.Cursor = Cursors.Hand;
            btn_avvia.Location = new Point(40, 57);
            btn_avvia.Name = "btn_avvia";
            btn_avvia.Size = new Size(160, 75);
            btn_avvia.TabIndex = 1;
            btn_avvia.Text = "AVVIA LETTURA DATI METEO";
            btn_avvia.UseVisualStyleBackColor = true;
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(0, 192, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(0, 64, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgv_tempo_temperatura.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_tempo_temperatura.Location = new Point(549, 138);
            dgv_tempo_temperatura.MultiSelect = false;
            dgv_tempo_temperatura.Name = "dgv_tempo_temperatura";
            dgv_tempo_temperatura.ReadOnly = true;
            dgv_tempo_temperatura.RowHeadersVisible = false;
            dgv_tempo_temperatura.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgv_tempo_temperatura.ScrollBars = ScrollBars.Vertical;
            dgv_tempo_temperatura.Size = new Size(519, 301);
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
            lbl_nomi.Location = new Point(878, 473);
            lbl_nomi.Name = "lbl_nomi";
            lbl_nomi.Size = new Size(283, 20);
            lbl_nomi.TabIndex = 4;
            lbl_nomi.Text = "Fatto da Davide Bisello e Sassaro Daniele";
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
            label4.Location = new Point(919, 13);
            label4.Name = "label4";
            label4.Size = new Size(603, 20);
            label4.TabIndex = 8;
            label4.Text = "fare in modo che si possa devidere quale citta analizzare, con quanti giorni di analisi ecc...";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(252, 477);
            label5.Name = "label5";
            label5.Size = new Size(238, 20);
            label5.TabIndex = 9;
            label5.Text = "fare notifyIcon e contextMenuStrip";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 255, 128);
            ClientSize = new Size(1320, 523);
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
    }
}
