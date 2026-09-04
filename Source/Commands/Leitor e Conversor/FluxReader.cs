using System.IO;
using Fluxogrammer.Source;

public class Fluxreader
{
    public static void Connect(string way)
    {
        string[] content = Checker(way);
        ProjetoInfo projetoInfo = new();
        Objeto? objeto = null;

        foreach(string line in content)
        {
            string lines = line.Trim();

            if (lines.StartsWith("ProjectName"))
            {
                projetoInfo.Nome = lines.Replace("ProjectName:", "").Replace("--(", "").Trim();
            } 
            else if (lines.StartsWith("blc.-id:"))
            {
                objeto = new Objeto();
                objeto.Id = lines.Substring(8).Trim();    
                projetoInfo.objetos.Add(objeto);
            }
            else if (lines.StartsWith("blc.-txt:"))
            {
                objeto.content = lines.Substring(10);
            }
            else if (lines.StartsWith("blc.-x:"))
            {
                objeto.X = double.Parse(lines.Substring(7));
            }
            else if (lines.StartsWith("blc.-y:"))
            {
                objeto.Y = double.Parse(lines.Substring(7));
            }
            else if (lines.StartsWith("blc.-wdt:"))
            {
                objeto.Wdt = double.Parse(lines.Substring(9));
            }
            else if (lines.StartsWith("blc.-hgth:"))
            {
                objeto.Hegt = double.Parse(lines.Substring(10));
            } 
            else if (lines.StartsWith("ln.-cnct_orgm:"))
            {
                projetoInfo.linhas.Add(new Linhas()
                {
                    OrigemId = lines.Substring(14).Trim()
                });
            }
            else if (lines.StartsWith("ln.-cnct_dstn:"))
            {
                projetoInfo.linhas[^1].DestinoId = lines.Substring(14).Trim();
            }
        }

        ProjWindow proj = new();
        
        proj.Title = projetoInfo.Nome;
        proj.LoadProj(projetoInfo);
        proj.Show();
    }
    
    private static string Checker(string way)
    {
        string fileContent = File.ReadAllText(way);
        string key = Environment.GetEnvironmentVariable("Fluxogrammer_Keys", EnvironmentVariableTarget.User);
        
        try
        {
            string txt = Encrypt.Decrypt(fileContent.Trim(), key);
            return txt.Split("\n");
        }
        catch (Exception)
        {
            return fileContent.Split("\n");
        }
    }
}