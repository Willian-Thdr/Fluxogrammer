using System.IO;

public class TemplateDataFlux
{
    public static void TemplateArchive(String name)
    {
        string mainWay = "C:/Users/angel";

        string fluxogramaFolder = Path.Combine(mainWay, "Fluxogramas");
        string DataCenter = Path.Combine(fluxogramaFolder, "DataCenter");

        Directory.CreateDirectory(DataCenter);

        File.SetAttributes(fluxogramaFolder, File.GetAttributes(fluxogramaFolder) | FileAttributes.Hidden);
        File.SetAttributes(DataCenter, File.GetAttributes(DataCenter) | FileAttributes.Hidden);

        string path = Path.Combine(DataCenter, name + ".txt");

        File.WriteAllText(path, "Teste de escrita");
    }
}