using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MigradorMaui.Services
{
    public class CopiaArquivos
    {
        private EntidadeGeral infos;
        private ManipuladorArquivos manipuladorArquivos;
        private DirectoryInfo raizProjetoAntigo;
        private DirectoryInfo raizProjetoNovo;

        public CopiaArquivos(EntidadeGeral entidadeGeral)
        {
            this.infos = entidadeGeral;
            manipuladorArquivos = new ManipuladorArquivos(entidadeGeral);
        }

        public void Start()
        {       
            DirectoryInfo diretorioSolucaoAntiga = new DirectoryInfo(infos.DiretorioSolucaoVelha);
            DirectoryInfo diretorioSolucaoNova = new DirectoryInfo(infos.DiretorioSolucaoNova);

            if (!diretorioSolucaoAntiga.Exists)
            {
                throw new DirectoryNotFoundException("Diretório do projeto antigo não encontrado!");
            }

            raizProjetoAntigo = RetornaDiretorioProjetoApp(diretorioSolucaoAntiga.GetDirectories());
            raizProjetoNovo = RetornaDiretorioProjetoApp(diretorioSolucaoNova.GetDirectories());

            foreach (DirectoryInfo pasta in raizProjetoAntigo.GetDirectories())
            {
                //TODO: OUTROS IFs

                if (pasta.Name.ToUpper().Contains("DROID") || pasta.Name.ToUpper().Contains("ANDROID"))
                {
                    CriaCopiaArquivosAndroid(pasta, null);
                }
                else if (pasta.Name.ToUpper().Contains("IOS") || pasta.Name.ToUpper().Contains("IOS"))
                {
                    CopiaArquivosIOS(pasta);
                }
                else if (pasta.Name.ToUpper().Contains("APP") || pasta.Name.ToUpper().Contains(".APP"))
                {
                    CriaCopiaDosArquivos(pasta, raizProjetoNovo);
                }
            }
        }        

        public void CriaCopiaDosArquivos(DirectoryInfo pastaOrigem, DirectoryInfo pastaDestino)
        {
            //COPIA OS ARQUIVOS "GERAIS" DE CONFIG / MAIN / COISAS ASSIM
            foreach (FileInfo file in pastaOrigem.GetFiles())
            {
                if (file.Extension.Contains("Xamarin") || file.Extension.Contains("shproj") || file.Name.ToUpper().Contains("APP") || file.Name.ToUpper().Contains("CACHE"))
                {
                    continue;
                }

                manipuladorArquivos.CopiaArquivo(file.Name, file.FullName, pastaDestino.FullName);
            }

            foreach(var subpasta in pastaOrigem.GetDirectories())
            {
                string nomePasta = subpasta.Name;

                if (nomePasta.Contains("bin") || nomePasta.Contains("obj"))
                {
                    continue;
                }                

                string diretorioPastaNova = Path.Combine(pastaDestino.FullName, nomePasta);
                if (!Directory.Exists(diretorioPastaNova))
                {
                    Directory.CreateDirectory(diretorioPastaNova);
                }

                CriaCopiaDosArquivos(subpasta, new DirectoryInfo(diretorioPastaNova));
            }
        }

        public void CriaCopiaArquivosAndroid(DirectoryInfo pastaOrigem, DirectoryInfo? pastaDestino)
        {            
            if(pastaDestino == null)
            {
                pastaDestino = new DirectoryInfo(Path.Combine(raizProjetoNovo.FullName, "Platforms\\Android"));
            }

            foreach (FileInfo file in pastaOrigem.GetFiles())
            {
                if (file.Name.Contains("packages"))
                {
                    string conteudoOrigem = File.ReadAllText(file.FullName);
                    
                    string pattern = @"<package id=""(.*?)"".*?version=""(.*?)""";
                    
                    MatchCollection matches = Regex.Matches(conteudoOrigem, pattern);
                    
                    string novosPackageReferences = "";
                    
                    foreach (Match match in matches)
                    {
                        string id = match.Groups[1].Value;
                        string version = match.Groups[2].Value;
                        
                        if (!id.Contains("Xamarin") && !id.Contains("System"))
                        {
                            novosPackageReferences += $"\n        <PackageReference Include=\"{id}\" Version=\"{version}\" />";
                        }
                    }
                    
                    string conteudoDestino = File.ReadAllText(Path.Combine(raizProjetoNovo.FullName, infos.NomeSolucaoNova + ".csproj"));

                    int index = conteudoDestino.IndexOf("</Project>");

                    novosPackageReferences = "\n  <ItemGroup>" + novosPackageReferences + "\n   </ItemGroup>\n";

                    conteudoDestino = conteudoDestino.Insert(index, novosPackageReferences);                    
                    
                    File.WriteAllText(Path.Combine(raizProjetoNovo.FullName, infos.NomeSolucaoNova + ".csproj"), conteudoDestino);
                }


                if (file.Extension.Contains("config") || file.FullName.ToUpper().Contains("CACHE") || file.Name.ToUpper().Contains("USER"))
                {
                    continue;
                }

                if (file.Name.ToUpper().Contains("MAINACTIVITY"))
                {
                    manipuladorArquivos.CopiaArquivo("_backupXF_" + file.Name, file.FullName, pastaDestino.FullName);
                    continue;
                }

                manipuladorArquivos.CopiaArquivo(file.Name, file.FullName, pastaDestino.FullName);
            }

            foreach (var subpasta in pastaOrigem.GetDirectories())
            {
                string nomePasta = subpasta.Name;

                if (nomePasta.Contains("bin") || nomePasta.Contains("obj") || nomePasta.Contains("Assets"))
                {
                    continue;
                }

                if (nomePasta.Contains("Properties"))
                {
                    foreach(var file in subpasta.GetFiles())
                    {
                        manipuladorArquivos.CopiaArquivo("_backupXF_" + file.Name, file.FullName, pastaDestino.FullName);
                    }

                    continue;
                }

                if (nomePasta.Contains("Resources"))
                {
                    foreach (DirectoryInfo drawables in subpasta.GetDirectories())
                    {
                        if (drawables.Name.Contains("xhdpi"))
                        {
                            CopiaImagens(drawables);
                        }
                    }

                    continue;
                }

                string diretorioPastaNova = Path.Combine(pastaDestino.FullName, nomePasta);
                if (!Directory.Exists(diretorioPastaNova))
                {
                    Directory.CreateDirectory(diretorioPastaNova);
                }

                CriaCopiaDosArquivos(subpasta, new DirectoryInfo(diretorioPastaNova));
            }
        }

        public void CopiaArquivosIOS(DirectoryInfo pastaOrigem)
        {
            DirectoryInfo pastaDestino = new DirectoryInfo(Path.Combine(raizProjetoNovo.FullName, "Platforms\\iOS"));

            foreach(var file in pastaOrigem.GetFiles())
            {
                if (file.Extension.Contains("config") || file.FullName.ToUpper().Contains("CACHE") || file.Name.ToUpper().Contains("USER"))
                {
                    continue;
                }

                if (file.Name.ToUpper().Contains("INFO") || file.Name.ToUpper().Contains("DELEGATE"))
                {
                    manipuladorArquivos.CopiaArquivo("_backupXF_" + file.Name, file.FullName, pastaDestino.FullName);
                    continue;
                }

                manipuladorArquivos.CopiaArquivo(file.Name, file.FullName, pastaDestino.FullName);
            }

            foreach (var subpasta in pastaOrigem.GetDirectories())
            {
                string nomePasta = subpasta.Name;

                if (nomePasta.Contains("bin") || nomePasta.Contains("obj") || nomePasta.Contains("Assets"))
                {
                    continue;
                }                

                string diretorioPastaNova = Path.Combine(pastaDestino.FullName, nomePasta);
                if (!Directory.Exists(diretorioPastaNova))
                {
                    Directory.CreateDirectory(diretorioPastaNova);
                }

                CriaCopiaDosArquivos(subpasta, new DirectoryInfo(diretorioPastaNova));
            }
        }

        public void CopiaImagens(DirectoryInfo diretorioImagens)
        {
            //Metodo não muito eficiente, pega a raiz das imagens na pasta drawable do android e redireciona para a pasta de resources do MAUI

            DirectoryInfo diretorioDestino = new DirectoryInfo(Path.Combine(raizProjetoNovo.FullName, "Resources\\Images"));

            foreach (var file in diretorioImagens.GetFiles())
            {
                manipuladorArquivos.CopiaArquivo(file.Name, file.FullName, diretorioDestino.FullName);
            }            
        }

        public DirectoryInfo RetornaDiretorioProjetoApp(DirectoryInfo[] diretorios)
        {
            foreach (var diretorio in diretorios)
            {
                if (diretorio.Name.ToUpper() == "APP" || diretorio.Name.ToUpper().Contains(".APP") || diretorio.Name.ToUpper().Contains(infos.NomeSolucaoNova.ToUpper()))
                {
                    return diretorio;
                }
            }

            throw new Exception("Pasta de projeto não encontrada, verifique a nomenclatura das pastas");
        }
    }
}
