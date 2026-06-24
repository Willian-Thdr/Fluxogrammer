using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Fluxogrammer.Fluxogramas;
public partial class ProjWindow : Window 
{
    public ProjWindow()
    {
        InitializeComponent();

        ProjectCanva.MouseRightButtonDown += (s, e) =>
        {
            ContextMenu menu = new ContextMenu();

            MenuItem item1 = new MenuItem();
            item1.Header = "Criar ideia";

            item1.Click += (s2, e2) =>
            {
                CreateObject.Connect(ProjectCanva);
                Console.WriteLine("Objeto criado");
            };

            menu.Placement = PlacementMode.MousePoint;

            menu.Items.Add(item1);
            menu.IsOpen = true;         
        };
    }
} 