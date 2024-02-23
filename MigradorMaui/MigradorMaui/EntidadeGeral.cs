using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigradorMaui
{
    public class EntidadeGeral
    {
        public EntidadeGeral()
        {
            nomeSolucaoNova = string.Empty;
            nomeSolucaoVelha = string.Empty;
            DiretorioSolucaoNova = string.Empty;
            DiretorioSolucaoVelha = string.Empty;
        }

        private string nomeSolucaoNova;
        private string nomeSolucaoVelha;
        public string NomeSolucaoVelha 
        {
            get { return nomeSolucaoNova; } 
            set {  nomeSolucaoNova = value.Replace(".sln", "");}
        }
        public string DiretorioSolucaoVelha { get; set; }
        public string NomeSolucaoNova
        {
            get { return nomeSolucaoVelha; }
            set { nomeSolucaoVelha = value.Replace(".sln", ""); }
        }
        public string DiretorioSolucaoNova { get; set; }

        public bool InformacoesValidas()
        {
            if (string.IsNullOrEmpty(NomeSolucaoNova) || string.IsNullOrEmpty(DiretorioSolucaoNova) || string.IsNullOrEmpty(NomeSolucaoVelha) || string.IsNullOrEmpty(DiretorioSolucaoVelha))
            {
                return false;
            }

            return true;
        }
    }
}
