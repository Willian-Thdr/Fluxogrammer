using System.IO;

public class FluxConverter
{
    public static void Save(string way, ProjetoInfo projeto)
    {
        int x = 0;
        int y = 0;

        using (StreamWriter writer = new StreamWriter(way))
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
    }
}