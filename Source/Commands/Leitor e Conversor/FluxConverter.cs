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
                Console.WriteLine("Bloco salvo");

                writer.WriteLine(FluxTemplate.TemplateBlocos(obj));

                if (projeto.objetos.Count > 1 && x < projeto.objetos.Count)
                {
                    writer.WriteLine("");
                }
            }

            foreach (Linhas linhas in projeto.linhas)
            {
                y++;

                writer.WriteLine(FluxTemplate.TemplateLines(linhas));

                if (projeto.linhas.Count > 1 && y < projeto.linhas.Count)
                {
                    writer.WriteLine("");
                }
            }

            writer.WriteLine(")");
    
            writer.Close();
        }
    }
}