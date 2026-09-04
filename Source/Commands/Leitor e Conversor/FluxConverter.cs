using System.IO;

public class FluxConverter
{
    public static void Save(string fileWay, ProjetoInfo projeto, string folderWay, string name)
    {
        int x = 0;
        int y = 0;

        using (StreamWriter writer = new StreamWriter(fileWay))
        {
            writer.WriteLine($"ProjectName: {projeto.Nome} --(");

            foreach (Objeto obj in projeto.objetos)
            {
                x++;

                writer.WriteLine(FluxTemplate.TemplateBlocos(obj));

                if (projeto.objetos.Count > 1 && x < projeto.objetos.Count)
                {
                    writer.WriteLine("");
                }
            }

            foreach (Linhas linhas in projeto.linhas)
            {
                y++;
                
                writer.WriteLine("");
                writer.WriteLine(FluxTemplate.TemplateLines(linhas));
            }

            writer.WriteLine(")");
    
            writer.Close();
        }

        #pragma warning disable CS8604 // Possible null reference argument.

        string txtEncrypt = Encrypt.Connect(null, File.ReadAllLines(fileWay), 
        Environment.GetEnvironmentVariable("Fluxogrammer_Keys", EnvironmentVariableTarget.User));

        #pragma warning restore CS8604 // Possible null reference argument.

        using (StreamWriter writer = new StreamWriter(fileWay))
        {
            writer.WriteLine(txtEncrypt);
            writer.Close();
        };
    }
}