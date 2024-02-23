using MigradorMaui.Services;

namespace MigradorMaui
{
    public partial class Home : Form
    {
        private EntidadeGeral entidadeGeral;
        public Home()
        {
            entidadeGeral = new EntidadeGeral();

            InitializeComponent();
        }

        private void btn_gerar_Click(object sender, EventArgs e)
        {
            entidadeGeral.NomeSolucaoVelha = txtNomeSolucaoVelha.Text;
            entidadeGeral.DiretorioSolucaoVelha = txtDiretorioSolucaoVelha.Text;
            entidadeGeral.NomeSolucaoNova = txtNomeSolucaoNova.Text;
            entidadeGeral.DiretorioSolucaoNova = txtDiretorioSolucaoNova.Text;            

            if (!entidadeGeral.InformacoesValidas())
            {
                lblError.Visible = true;
                return;
            }

            lblError.Visible = false;

            CopiaArquivos copier = new CopiaArquivos(entidadeGeral);

            copier.Start();

            MessageBox.Show("Done!", "Maui Migration", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
