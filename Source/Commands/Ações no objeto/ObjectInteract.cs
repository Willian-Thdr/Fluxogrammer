using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using static CreateObject;
public class ObjectInteract 
{ 
    public static void Connect(Canvas canva, BlocoVisual bloco) 
    { 
        bloco.Grid.PreviewMouseRightButtonDown += (s, e) => 
        { 
            ContextMenu menu = new(); 

            MenuItem item1 = new MenuItem(); 
            item1.Header = "Renomear"; 

            MenuItem item2 = new MenuItem(); 
            item2.Header = "Expandir"; 

            MenuItem item3 = new MenuItem(); 
            item3.Header = "Recolher"; 

            MenuItem item4 = new MenuItem(); 
            item4.Header = "Deletar"; 

            MenuItem item5 = new MenuItem();
            item5.Header = "Criar progresso"; 

            item1.Click += (s2, e2) => { 
                bloco.TextBox.IsReadOnly = false; 
                bloco.TextBox.Focus(); 
            }; 

            item2.Click += (s2, e2) => 
            { 
                bloco.Grid.Height = double.NaN; 
            }; 

            item3.Click += (s2, e2) => 
            { 
                bloco.Grid.Height = 25; 
            }; 

            item4.Click += (s2, e2) => 
            { 
                canva.Children.Remove(bloco.Grid); 
            }; 

            item5.Click += (s2, e2) =>
            {
                
            }; 

            menu.Placement = PlacementMode.MousePoint;
            menu.Items.Add(item1); 

            if (bloco.Grid.Height <= 27) 
            { 
                menu.Items.Add(item2);
                menu.Items.Remove(item3); 
            } 
            else 
            { 
                menu.Items.Add(item3); 
                menu.Items.Remove(item2); 
            } 

            menu.Items.Add(item4); 
            menu.Items.Add(item5);

            menu.IsOpen = true; 
        }; 
    } 
}