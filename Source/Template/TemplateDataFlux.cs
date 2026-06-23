using System.IO;

public class TemplateDataFlux
{
    public static void TemplateArchive(string name, string description)
    {
        string mainWay = "C:/Users/angel";

        string fluxogramaFolder = Path.Combine(mainWay, "Fluxogramas");
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
        }
    }
}