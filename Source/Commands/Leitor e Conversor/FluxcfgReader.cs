using System.IO;
using Fluxogrammer.Source;

public class FluxcfgReader
{
    public static void Connect(string file)
    {
        File.SetAttributes(file, File.GetAttributes(file) | FileAttributes.Normal);
        string[] content = File.ReadAllLines(file);
        string theme = "";

        foreach(string line in content)
        {
            string linha = line.Trim();

            if (linha.StartsWith("Fluxograma.theme..."))
            {
                theme = linha.Substring(19).Trim().Trim(';');
                ColorFont.Change(theme);
            }
        }

        File.SetAttributes(file, File.GetAttributes(file) | FileAttributes.Hidden);
    }
}