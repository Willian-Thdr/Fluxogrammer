using System.Windows.Media;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

public class NotificationWindow
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int MessageBox(
        IntPtr hWnd,
        string txt,
        string caption,
        uint type
    );

    public static int Connect(string title, string message, uint type)
    {
        return MessageBox(IntPtr.Zero, message, title, type);
    }

    public Window Notification(string content, string color, Brush foreground)
    {
        
        Window message = new Window
        {
            Width = 800,
            Height = 400
        };

        Grid grid = new Grid
        {
            Margin = new Thickness(5),
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color))
        };

        ScrollViewer scroll = new ScrollViewer
        {
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Stretch,
            VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
            HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled            
        };

        TextBlock text = new TextBlock
        {
            TextWrapping = TextWrapping.Wrap,
            FontSize = 14,
            Foreground = foreground,
            Text = content
        };

        message.Content = grid;
        scroll.Content = text;
        grid.Children.Add(scroll);
        
        return message;
    }
}