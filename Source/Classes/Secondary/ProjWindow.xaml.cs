using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using static CreateObject;

namespace Fluxogrammer.Source;
public partial class ProjWindow : Window 
{
    public static ProjetoInfo projetoInfo = new();

    public ProjWindow()
    {
        int x = 0;
        DispatcherTimer timer = new DispatcherTimer();
        InitializeComponent();

        ProjectCanva.MouseRightButtonDown += (s, e) =>
        {
            ContextMenu menu = new ContextMenu();

            MenuItem item1 = new MenuItem();
            item1.Header = "Criar ideia";

            MenuItem save = new MenuItem();
            save.Header = "Salvar projeto";

            item1.Click += (s2, e2) =>
            {
                x++;

                Connect(ProjectCanva, x, projetoInfo);
            };

            save.Click += (s2, e2) =>
            {
                SaveProj(ProjectCanva, Title);
            };

            menu.Placement = PlacementMode.MousePoint;

            menu.Items.Add(item1);
            menu.Items.Add(save);
            menu.IsOpen = true;         
        };
    
        Closing += (s, e) =>
        {
            SaveProj(ProjectCanva, Title);
            timer.Stop();
        };
    
        timer.Interval = TimeSpan.FromMinutes(5);
        timer.Tick += (s, e) =>
        {
            SaveBackup(ProjectCanva, Title);
            SaveProj(ProjectCanva, Title);
        };
        timer.Start();
    }

    public void LoadProj(ProjetoInfo proj)
    {
        Dictionary<string, BlocoVisual> mapa = new();

        foreach(Objeto obj in proj.objetos)
        {
            BlocoVisual bloco = CreateFromFile(ProjectCanva, obj, projetoInfo);
            mapa[obj.Id] = bloco;
        }

        CalcularDeArquivo(projetoInfo, mapa, ProjectCanva);
    }

    public void CalcularDeArquivo(ProjetoInfo projetoInfo, Dictionary<string, BlocoVisual> mapa, Canvas canva)
    {
        foreach(Linhas linha in projetoInfo.linhas)
        {
            BlocoVisual origem = mapa[linha.OrigemId];
            BlocoVisual destino = mapa[linha.DestinoId];

            Connection connection = new Connection(origem, destino);

            origem.Connections.Add(connection);
            destino.Connections.Add(connection);

            canva.Children.Add(connection.Linha);
        }
    }

    private static void SaveProj(Canvas canva, string title)
    {
        string way = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        string path2 = Path.Combine(way, @"Fluxogramas\DataCenter");
        string path3 = Path.Combine(path2, title);
        Directory.CreateDirectory(path3);
        string path = Path.Combine(path3, title + ".flux");
        projetoInfo.Nome = title;
        projetoInfo.objetos.Clear();

        foreach (Grid bloco in canva.Children.OfType<Grid>())
        {
            TextBox txt = (TextBox)bloco.Children[1];

            projetoInfo.objetos.Add(new Objeto()
            {
                Id = bloco.Name,
                content = txt.Text,
                X = Canvas.GetLeft(bloco),
                Y = Canvas.GetTop(bloco),
                Wdt = bloco.Width,
                Hegt = bloco.ActualHeight
            });
        }

        FluxConverter.Save(path, projetoInfo);
    } 

    private static void SaveBackup(Canvas canva, string title)
    {
        string way = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        string path2 = Path.Combine(way, @"Fluxogramas\Backup");
        string path3 = Path.Combine(path2, title);

        Directory.CreateDirectory(path3);
        File.SetAttributes(path3, File.GetAttributes(path3) | FileAttributes.Hidden);

        int hora = DateTime.Now.Hour;
        int min = DateTime.Now.Minute;
        int dia = DateTime.Now.Day;
        int mes = DateTime.Now.Month;

        string fileName = title + "-" + dia + "-" + mes + "-" + hora + "hr" + min + ".flux";

        string path = Path.Combine(path3, fileName);
        projetoInfo.Nome = title;
        projetoInfo.objetos.Clear();

        foreach (Grid bloco in canva.Children.OfType<Grid>())
        {
            TextBox txt = (TextBox)bloco.Children[1];

            projetoInfo.objetos.Add(new Objeto()
            {
                Id = bloco.Name,
                content = txt.Text,
                X = Canvas.GetLeft(bloco),
                Y = Canvas.GetTop(bloco),
                Wdt = bloco.Width,
                Hegt = bloco.ActualHeight
            });
        }

        FluxConverter.Save(path, projetoInfo);
    } 
} 