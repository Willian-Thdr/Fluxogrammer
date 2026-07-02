using System.IO;

public class FluxTemplate
{
    public static string TemplateBlocos(Objeto obj)
    {
        return $$"""
    Blocos --[
        blc.-ID: {{obj.Id}}
        blc.-TX7: {{obj.content}}
        blc.-X: {{obj.X}}
        blc.-Y: {{obj.Y}}
        blc.-Wd7: {{obj.Wdt}}
        blc.-Hg7h: {{obj.Hegt}}
    ]
""";
    }

    public static string TemplateLines(Linhas linha)
    {
        return $$"""
    Conexão --[
        ln.-cnct_orgm: {{linha.OrigemId}}
        ln.-cnct_dstn: {{linha.DestinoId}}
    ]    
""";
    }
}