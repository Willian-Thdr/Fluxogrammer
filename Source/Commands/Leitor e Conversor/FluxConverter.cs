using System.IO;
using System.Windows.Controls;

public class FluxConverter
{
    public static void Save(string way, ProjetoInfo projeto)
    {
        int x = 0;

        using (StreamWriter writer = new StreamWriter(way))
        {
            writer.WriteLine($"ProjectName: {projeto.Nome} --(");
    
            writer.WriteLine("  Blocos --[");
            foreach (Objeto obj in projeto.objetos)
            {
                writer.WriteLine($"     blc.-ID: {obj.Id}");
                writer.WriteLine($"     blc.-TX7: {obj.content}");
                writer.WriteLine($"     blc.-X: {obj.X}");
                writer.WriteLine($"     blc.-Y: {obj.Y}");
                writer.WriteLine($"     blc.-Wd7: {obj.Wdt}");
                writer.WriteLine($"     blc.-Hg7h: {obj.Hegt}");
                x++;

                if (projeto.objetos.Count > 1 && x < projeto.objetos.Count)
                {
                    writer.WriteLine("");
                }
            }
            writer.WriteLine("  ]");
            writer.WriteLine(")");
    
            writer.Close();
        }
    }
}