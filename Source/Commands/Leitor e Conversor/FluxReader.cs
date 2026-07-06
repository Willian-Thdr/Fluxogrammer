using System.IO;
using Fluxogrammer.Source;

public class Fluxreader
{
    public static void Connect(string way)
    {
        string[] content = File.ReadAllLines(way);
        ProjetoInfo projetoInfo = new();
        Objeto? objeto = null;

        foreach(string line in content)
        {
            string linha = line.Trim();

            if (linha.StartsWith("ProjectName"))
            {
                projetoInfo.Nome = linha.Replace("ProjectName:", "").Replace("--(", "").Trim();
            } 
            else if (linha.StartsWith("blc.-id:"))
            {
                objeto = new Objeto();
                objeto.Id = linha.Substring(8).Trim();    
                projetoInfo.objetos.Add(objeto);
            }
            else if (linha.StartsWith("blc.-txt:"))
            {
                objeto.content = linha.Substring(10);
            }
            else if (linha.StartsWith("blc.-x:"))
            {
                objeto.X = double.Parse(linha.Substring(7));
            }
            else if (linha.StartsWith("blc.-y:"))
            {
                objeto.Y = double.Parse(linha.Substring(7));
            }
            else if (linha.StartsWith("blc.-wdt:"))
            {
                objeto.Wdt = double.Parse(linha.Substring(9));
            }
            else if (linha.StartsWith("blc.-hgth:"))
            {
                objeto.Hegt = double.Parse(linha.Substring(10));
            } 
            else if (linha.StartsWith("ln.-cnct_orgm:"))
            {
                projetoInfo.linhas.Add(new Linhas()
                {
                    OrigemId = linha.Substring(12).Trim()
                });  
            }
            else if (linha.StartsWith("ln.-cnct_dstn:"))
            {
                projetoInfo.linhas[^1].DestinoId = linha.Substring(13).Trim(); 
            }
        }

        ProjWindow proj = new();
        
        proj.Title = projetoInfo.Nome;
        proj.LoadProj(projetoInfo);
        proj.Show();
    }
}