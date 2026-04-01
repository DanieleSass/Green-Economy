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
            plt_tempo_temperatura = new ScottPlot.WinForms.FormsPlot();
            btn_avvia = new Button();
            SuspendLayout();
            // 
            // plt_tempo_temperatura
            // 
            plt_tempo_temperatura.Location = new Point(206, 56);
            plt_tempo_temperatura.Name = "plt_tempo_temperatura";
            plt_tempo_temperatura.Size = new Size(792, 431);
            plt_tempo_temperatura.TabIndex = 0;
            // 
            // btn_avvia
            // 
            btn_avvia.Location = new Point(40, 57);
            btn_avvia.Name = "btn_avvia";
            btn_avvia.Size = new Size(160, 75);
            btn_avvia.TabIndex = 1;
            btn_avvia.Text = "AVVIA LETTURA DATI METEO";
            btn_avvia.UseVisualStyleBackColor = true;
            btn_avvia.Click += btn_avvia_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1320, 523);
            Controls.Add(btn_avvia);
            Controls.Add(plt_tempo_temperatura);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot plt_tempo_temperatura;
        private Button btn_avvia;
    }
}
