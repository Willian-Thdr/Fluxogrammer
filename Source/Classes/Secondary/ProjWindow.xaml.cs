using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Fluxogrammer.Source;
public partial class ProjWindow : Window 
{
    public ProjWindow()
    {
        int x = 0;

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

                CreateObject.Connect(ProjectCanva, x);
            };

            save.Click += (s2, e2) =>
            {
                ProjetoInfo projetoInfo = new();

                projetoInfo.Nome = Title;

                foreach (Grid bloco in ProjectCanva.Children.OfType<Grid>())
                {
                    TextBox txt = (TextBox)bloco.Children[1];

                    projetoInfo.objetos.Add(new Objeto()
                    {
                        Id = bloco.Name,
                        content = txt.Text,
                        X = Canvas.GetLeft(bloco),
                        Y = Canvas.GetTop(bloco),
                        Wdt = bloco.Width,
                        Hegt = bloco.Height
                    });
                }

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fluxogramas", "DataCenter", Title, Title + ".flux");
                FluxConverter.Save(path, projetoInfo);
            };

            menu.Placement = PlacementMode.MousePoint;

            menu.Items.Add(item1);
            menu.Items.Add(save);
            menu.IsOpen = true;         
        };
    }

    public void LoadProj(ProjetoInfo proj)
    {

        foreach(Objeto obj in proj.objetos)
        {
            CreateObject.CreateFromFile(ProjectCanva, obj);
        }
    }
} 