using System.IO;
using Fluxogrammer;
using Fluxogrammer.Fluxogramas;
using Fluxogrammer.Source;

public class TemplateDataFlux
{
    public static void TemplateArchive(string name, string description, Action close)
    {
        string mainWay = AppDomain.CurrentDomain.BaseDirectory;
        string projWay = Directory.GetParent(mainWay).Parent.Parent.Parent.FullName;

        string fluxogramaFolder = Path.Combine(projWay, "Fluxogramas");
        string DataCenter = Path.Combine(fluxogramaFolder, "DataCenter");

        Directory.CreateDirectory(DataCenter);

        File.SetAttributes(fluxogramaFolder, File.GetAttributes(fluxogramaFolder) | FileAttributes.Hidden);
        File.SetAttributes(DataCenter, File.GetAttributes(DataCenter) | FileAttributes.Hidden);

        string archiveName = name + " description.txt";
        string path = Path.Combine(DataCenter, archiveName);

        if (Path.Exists(path))
        {
            Console.WriteLine("ERRO: Arquivo com esse nome já existente.");
        }
        else
        {
            string content = "Nome: " + name + "\n" + "Descrição: " + description; 

            File.WriteAllText(path, content);
            Console.WriteLine("Criado");
            close.Invoke();
            ProjWindow project = new ProjWindow();
            project.Title = name;
            project.Show();
        }
    }
}