namespace Green_Economy
{
    partial class FGuida
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
            label1 = new Label();
            btn_esci = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(271, 133);
            label1.Name = "label1";
            label1.Size = new Size(278, 20);
            label1.TabIndex = 0;
            label1.Text = "mettere guida o docimentazione tecnica";
            // 
            // btn_esci
            // 
            btn_esci.Location = new Point(560, 280);
            btn_esci.Name = "btn_esci";
            btn_esci.Size = new Size(171, 97);
            btn_esci.TabIndex = 1;
            btn_esci.Text = "Esci";
            btn_esci.UseVisualStyleBackColor = true;
            btn_esci.Click += btn_esci_Click;
            // 
            // FGuida
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lime;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_esci);
            Controls.Add(label1);
            Name = "FGuida";
            Text = "FGuida";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btn_esci;
    }
}