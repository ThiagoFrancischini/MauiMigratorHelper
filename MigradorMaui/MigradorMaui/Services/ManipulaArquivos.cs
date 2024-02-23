using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigradorMaui.Services
{
    public class ManipuladorArquivos
    {        
        private EntidadeGeral infos;
        public ManipuladorArquivos(EntidadeGeral infos)
        {
            this.infos = infos;
        }

        public void CopiaArquivo(string nomeArquivoOrigem, string pathArquivoOrigem, string pathPastaDestino)
        {
            try
            {
                string pathFinal = Path.Combine(pathPastaDestino, nomeArquivoOrigem);
                File.Copy(pathArquivoOrigem, pathFinal, true);
                string texto = File.ReadAllText(pathFinal);

                texto = texto.Replace("Xamarin.Forms", "Microsoft.Maui");
                texto = texto.Replace("using Xamarin.Essentials;", "");
                texto = texto.Replace("http://xamarin.com/schemas/2014/forms", "http://schemas.microsoft.com/dotnet/2021/maui");
                texto = texto.Replace(infos.NomeSolucaoVelha, infos.NomeSolucaoNova);

                File.WriteAllText(pathFinal, texto);
            }
            catch (UnauthorizedAccessException ex)
            {                
                return;
            }    
            catch(Exception ex) 
            {
                throw new Exception($"Erro ao copiar o arquivo {nomeArquivoOrigem}: {ex.Message}");
            }
        }
    }
}
