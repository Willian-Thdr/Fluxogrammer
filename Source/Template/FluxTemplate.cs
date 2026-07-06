public class FluxTemplate
{
    public static string TemplateBlocos(Objeto obj)
    {
        return $$"""
    Blocos --[
        blc.-id: {{obj.Id}}
        blc.-txt: {{obj.content}}
        blc.-x: {{obj.X}}
        blc.-y: {{obj.Y}}
        blc.-wdt: {{obj.Wdt}}
        blc.-hgth: {{obj.Hegt}}
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