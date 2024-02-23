namespace MigradorMaui
{
    partial class Home
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
            lbl_nomeSolucaoNova = new Label();
            lblDiretorioNovaSolucao = new Label();
            lblnomeSolucaoVelha = new Label();
            lblDiretorioSolucaoVelha = new Label();
            lblTitulo = new Label();
            txtNomeSolucaoNova = new TextBox();
            txtDiretorioSolucaoNova = new TextBox();
            txtNomeSolucaoVelha = new TextBox();
            txtDiretorioSolucaoVelha = new TextBox();
            btn_gerar = new Button();
            lblError = new Label();
            SuspendLayout();
            // 
            // lbl_nomeSolucaoNova
            // 
            lbl_nomeSolucaoNova.AutoSize = true;
            lbl_nomeSolucaoNova.Location = new Point(48, 137);
            lbl_nomeSolucaoNova.Name = "lbl_nomeSolucaoNova";
            lbl_nomeSolucaoNova.Size = new Size(154, 15);
            lbl_nomeSolucaoNova.TabIndex = 0;
            lbl_nomeSolucaoNova.Text = "New Solution Name (MAUI)";
            // 
            // lblDiretorioNovaSolucao
            // 
            lblDiretorioNovaSolucao.AutoSize = true;
            lblDiretorioNovaSolucao.Location = new Point(35, 188);
            lblDiretorioNovaSolucao.Name = "lblDiretorioNovaSolucao";
            lblDiretorioNovaSolucao.Size = new Size(167, 15);
            lblDiretorioNovaSolucao.TabIndex = 1;
            lblDiretorioNovaSolucao.Text = "New Solution Directory(MAUI)";
            // 
            // lblnomeSolucaoVelha
            // 
            lblnomeSolucaoVelha.AutoSize = true;
            lblnomeSolucaoVelha.Location = new Point(30, 237);
            lblnomeSolucaoVelha.Name = "lblnomeSolucaoVelha";
            lblnomeSolucaoVelha.Size = new Size(172, 15);
            lblnomeSolucaoVelha.TabIndex = 2;
            lblnomeSolucaoVelha.Text = "Old Solution Name (XAMARIN)";
            // 
            // lblDiretorioSolucaoVelha
            // 
            lblDiretorioSolucaoVelha.AutoSize = true;
            lblDiretorioSolucaoVelha.Location = new Point(14, 276);
            lblDiretorioSolucaoVelha.Name = "lblDiretorioSolucaoVelha";
            lblDiretorioSolucaoVelha.Size = new Size(188, 15);
            lblDiretorioSolucaoVelha.TabIndex = 3;
            lblDiretorioSolucaoVelha.Text = "Old Solution Directory (XAMARIN)";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F);
            lblTitulo.Location = new Point(243, 41);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(308, 32);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "Migration to MAUI - Helper";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtNomeSolucaoNova
            // 
            txtNomeSolucaoNova.Location = new Point(214, 134);
            txtNomeSolucaoNova.Name = "txtNomeSolucaoNova";
            txtNomeSolucaoNova.Size = new Size(518, 23);
            txtNomeSolucaoNova.TabIndex = 5;
            // 
            // txtDiretorioSolucaoNova
            // 
            txtDiretorioSolucaoNova.Location = new Point(214, 185);
            txtDiretorioSolucaoNova.Name = "txtDiretorioSolucaoNova";
            txtDiretorioSolucaoNova.Size = new Size(518, 23);
            txtDiretorioSolucaoNova.TabIndex = 6;
            // 
            // txtNomeSolucaoVelha
            // 
            txtNomeSolucaoVelha.Location = new Point(214, 234);
            txtNomeSolucaoVelha.Name = "txtNomeSolucaoVelha";
            txtNomeSolucaoVelha.Size = new Size(518, 23);
            txtNomeSolucaoVelha.TabIndex = 7;
            // 
            // txtDiretorioSolucaoVelha
            // 
            txtDiretorioSolucaoVelha.Location = new Point(214, 276);
            txtDiretorioSolucaoVelha.Name = "txtDiretorioSolucaoVelha";
            txtDiretorioSolucaoVelha.Size = new Size(518, 23);
            txtDiretorioSolucaoVelha.TabIndex = 8;
            // 
            // btn_gerar
            // 
            btn_gerar.Location = new Point(337, 383);
            btn_gerar.Name = "btn_gerar";
            btn_gerar.Size = new Size(171, 23);
            btn_gerar.TabIndex = 9;
            btn_gerar.Text = "Generate";
            btn_gerar.UseVisualStyleBackColor = true;
            btn_gerar.Click += btn_gerar_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 12F);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(48, 382);
            lblError.Name = "lblError";
            lblError.Size = new Size(136, 21);
            lblError.TabIndex = 10;
            lblError.Text = "Fill all information";
            lblError.Visible = false;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblError);
            Controls.Add(btn_gerar);
            Controls.Add(txtDiretorioSolucaoVelha);
            Controls.Add(txtNomeSolucaoVelha);
            Controls.Add(txtDiretorioSolucaoNova);
            Controls.Add(txtNomeSolucaoNova);
            Controls.Add(lblTitulo);
            Controls.Add(lblDiretorioSolucaoVelha);
            Controls.Add(lblnomeSolucaoVelha);
            Controls.Add(lblDiretorioNovaSolucao);
            Controls.Add(lbl_nomeSolucaoNova);
            Name = "Home";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_nomeSolucaoNova;
        private Label lblDiretorioNovaSolucao;
        private Label lblnomeSolucaoVelha;
        private Label lblDiretorioSolucaoVelha;
        private Label lblTitulo;
        private TextBox txtNomeSolucaoNova;
        private TextBox txtDiretorioSolucaoNova;
        private TextBox txtNomeSolucaoVelha;
        private TextBox txtDiretorioSolucaoVelha;
        private Button btn_gerar;
        private Label lblError;
    }
}
