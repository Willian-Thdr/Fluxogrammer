public class FluxcfgConverter
{
    public static string WriteConfig(string tema)
    {
        return $$"""
            Fluxogrammer configs:
            {
                Fluxograma.theme... {{tema}};
            }
        """;
    }
}