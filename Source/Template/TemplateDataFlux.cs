using System.Data;
using System.IO;
using Fluxogrammer.Source;

public class TemplateDataFlux
{
    public static void TemplateArchive(string name, string? description, Action close)
    {
        string mainWay = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        string fluxogramaFolder = Path.Combine(mainWay, "Fluxogramas");
        string DataCenter = Path.Combine(fluxogramaFolder, "DataCenter");
        string projectNameFolder = Path.Combine(DataCenter, name);

        Directory.CreateDirectory(projectNameFolder);

        if (string.IsNullOrEmpty(name))
        {
            WindowError error = new WindowError();
            error.Connect("ERRO: Campo de nome está vazio. Por favor, preencha-o.");
            error.ShowDialog();
            return;
        } 
    
        foreach(char c in Path.GetInvalidFileNameChars())
        {
            name = name.Replace(c, '_');
        }

        string archiveName = name + " description.txt";
        string path = Path.Combine(projectNameFolder, archiveName);
        int hora = DateTime.Now.Hour;
        int minuto = DateTime.Now.Minute;
        int dia = DateTime.Now.Day;
        int mes = DateTime.Now.Month;
        int ano = DateTime.Now.Year;

        string horario = "Horário: " + hora + ":" + minuto;
        string calendario = "Data: " + dia + "/" + mes + "/" + ano;

        if (Path.Exists(path))
        {
            WindowError error = new WindowError();
            error.Connect("ERRO: Arquivo com esse nome já existente.");
            error.ShowDialog();            
        }
        else
        {
            string l1 = "Nome: " + name + ";\n"; 
            string l2 = "Descrição: " + description + ";\n";
            string l3 = horario + ";\n";
            string l4 = calendario + ";\n";

            string finalText;

            if (string.IsNullOrEmpty(description))
            {
                l2 = "Descrição: " + " NaN" + ";\n";
            }

            finalText = l1 + l2 + l3 + l4;
            File.WriteAllText(path, finalText);

            close.Invoke();
            ProjWindow project = new ProjWindow();
            project.Title = name;
            project.Show();
        }
    }
}