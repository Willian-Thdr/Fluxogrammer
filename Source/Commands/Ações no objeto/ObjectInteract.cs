using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using static CreateObject;
public class ObjectInteract 
{
    public static Connection connection;

    public static void Connect(Canvas canva, BlocoVisual bloco, Objeto obj, ProjetoInfo projeto) 
    { 
        bloco.Grid.PreviewMouseRightButtonDown += (s, e) => 
        { 
            ContextMenu menu = new();

            MenuItem item1 = new MenuItem(); 
            item1.Header = "Renomear"; 

            MenuItem Expandir = new MenuItem(); 
            Expandir.Header = "Expandir"; 

            MenuItem Recolher = new MenuItem(); 
            Recolher.Header = "Recolher"; 

            MenuItem item4 = new MenuItem(); 
            item4.Header = "Deletar"; 

            MenuItem item5 = new MenuItem();
            item5.Header = "Criar progresso"; 

            item1.Click += (s2, e2) => 
            { 
                bloco.TextBox.IsReadOnly = false; 
                bloco.TextBox.Focus(); 
            }; 

            Expandir.Click += (s2, e2) => 
            {                
                bloco.Grid.Height= double.NaN;
                bloco.Grid.UpdateLayout();
                obj.Hegt = bloco.Grid.ActualHeight;

                foreach(Connection connection in bloco.Connections)
                {
                    connection.Atualizar();
                }
            }; 

            Recolher.Click += (s2, e2) => 
            { 
                bloco.Grid.Height= 27;
                obj.Hegt = 27;
            }; 

            item4.Click += (s2, e2) => 
            { 
                canva.Children.Remove(bloco.Grid);

                foreach (Connection connection in bloco.Connections)
                {
                    canva.Children.Remove(connection.Linha);

                    BlocoVisual outroBloco = connection.Origem == bloco ? connection.Destino : connection.Origem;
                    outroBloco.Connections.Remove(connection);

                    GetPointObject.connections.Remove(connection);
                }
            }; 

            item5.Click += (s2, e2) =>
            {
                GetPointObject.GetPointOrigem(bloco);
            }; 

            menu.Placement = PlacementMode.MousePoint;
            menu.Items.Add(item1); 

            if (bloco.Grid.Height <= 27) 
            { 
                menu.Items.Add(Expandir);
                menu.Items.Remove(Recolher); 
            } 
            else
            { 
                menu.Items.Add(Recolher); 
                menu.Items.Remove(Expandir); 
            } 

            menu.Items.Add(item4); 
            menu.Items.Add(item5);

            menu.IsOpen = true; 
        }; 
    }
}