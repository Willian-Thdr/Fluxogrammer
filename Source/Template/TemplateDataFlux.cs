using System.Data;
using System.Windows.Media;
using System.IO;
using Fluxogrammer.Source;

public class TemplateDataFlux
{
    private static NotificationWindow error = new NotificationWindow();

    public static void TemplateArchive(string name, string? description, Action close)
    {
        string mainWay = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        string fluxogramaFolder = Path.Combine(mainWay, "Fluxogramas");
        string DataCenter = Path.Combine(fluxogramaFolder, "DataCenter");

        string Backup = Path.Combine(fluxogramaFolder, "Backup");
        string projectNameFolder = Path.Combine(DataCenter, name);

        Directory.CreateDirectory(projectNameFolder);
        Directory.CreateDirectory(Backup);

        File.SetAttributes(Backup, File.GetAttributes(Backup) | FileAttributes.Hidden);
        
        if (string.IsNullOrEmpty(name))
        {
            error.Notification("ERRO: Campo de nome está vazio. Por favor, preencha-o.", "#1d1d1d", Brushes.Red).ShowDialog();
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
            error.Notification("ERRO: Arquivo com esse nome já existente.", "#1d1d1d", Brushes.Red).ShowDialog();
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