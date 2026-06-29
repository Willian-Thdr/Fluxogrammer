using System.Windows.Controls;
using static CreateObject;

public class FluxConnectionManager
{
    private static BlocoVisual? origem;

    public static void StartConnect(Canvas canva, BlocoVisual bloco)
    {
        origem = bloco;
    }

    public static void EndConnect(Canvas canva, BlocoVisual destino)
    {
        if (origem == null || origem == destino)
            return;

        LinhaStorage linha = new LinhaStorage(origem, destino);

        canva.Children.Add(linha.Path);

        origem = null;
    }
}