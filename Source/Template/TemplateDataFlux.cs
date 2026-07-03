using System.IO;
using Fluxogrammer.Source;

public class TemplateDataFlux
{
    public static void TemplateArchive(string name, string? description, Action close)
    {
        string mainWay = @"C:\Users\angel";

        string fluxogramaFolder = Path.Combine(mainWay, "Fluxogramas");
        string DataCenter = Path.Combine(fluxogramaFolder, "DataCenter");
        string projectNameFolder = Path.Combine(DataCenter, name);

        Directory.CreateDirectory(projectNameFolder);

        File.SetAttributes(fluxogramaFolder, File.GetAttributes(fluxogramaFolder) | FileAttributes.Hidden);
        File.SetAttributes(DataCenter, File.GetAttributes(DataCenter) | FileAttributes.Hidden);

        if (string.IsNullOrEmpty(name))
        {
            WindowError error = new WindowError();
            error.Connect("ERRO: Arquivo com esse nome já existente.");
            error.ShowDialog();
            return;
        } 
    
        foreach(char c in Path.GetInvalidFileNameChars())
        {
            name = name.Replace(c, '_');
        }

        string archiveName = name + " description.txt";
        string path = Path.Combine(projectNameFolder, archiveName);
        
        if (Path.Exists(path))
        {
            WindowError error = new WindowError();
            error.Connect("ERRO: Campo de nome está vazio. Por favor, preencha-o.");
            error.ShowDialog();            
        }
        else
        {
            string l1 = "Nome: " + name + ";\n"; 
            string l2 = "Descrição: " + description + ";\n";
            string finalText;

            if (string.IsNullOrEmpty(description))
            {
                l2 = "Descrição: " + " NaN" + ";\n";
            }

            finalText = l1 + l2;
            File.WriteAllText(path, finalText);

            close.Invoke();
            ProjWindow project = new ProjWindow();
            project.Title = name;
            project.Show();
        }
    }
}