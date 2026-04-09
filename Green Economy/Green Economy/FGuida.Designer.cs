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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FGuida));
            lbl_text = new Label();
            btn_esci = new Button();
            lbl_title = new Label();
            SuspendLayout();
            // 
            // lbl_text
            // 
            lbl_text.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_text.Location = new Point(50, 86);
            lbl_text.Name = "lbl_text";
            lbl_text.Size = new Size(1041, 484);
            lbl_text.TabIndex = 0;
            lbl_text.Text = resources.GetString("lbl_text.Text");
            // 
            // btn_esci
            // 
            btn_esci.BackColor = Color.FromArgb(255, 128, 128);
            btn_esci.Cursor = Cursors.Hand;
            btn_esci.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_esci.Location = new Point(920, 12);
            btn_esci.Name = "btn_esci";
            btn_esci.Size = new Size(96, 56);
            btn_esci.TabIndex = 1;
            btn_esci.Text = "Esci";
            btn_esci.UseVisualStyleBackColor = false;
            btn_esci.Click += btn_esci_Click;
            // 
            // lbl_title
            // 
            lbl_title.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_title.Location = new Point(421, 12);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(333, 56);
            lbl_title.TabIndex = 2;
            lbl_title.Text = "INFORMAZIONI";
            // 
            // FGuida
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LawnGreen;
            ClientSize = new Size(1126, 619);
            Controls.Add(lbl_title);
            Controls.Add(btn_esci);
            Controls.Add(lbl_text);
            Name = "FGuida";
            Text = "FGuida";
            Load += FGuida_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_text;
        private Button btn_esci;
        private Label lbl_title;
    }
}