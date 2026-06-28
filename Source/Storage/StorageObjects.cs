using System.ComponentModel;
using System.Dynamic;
using System.Windows.Controls;

public class StorageObjects
{
    private static StorageObjects _instance = new();
    public static StorageObjects Instance => _instance;

    public List<Grid> objetos { get; set; } = new List<Grid>(); 
}