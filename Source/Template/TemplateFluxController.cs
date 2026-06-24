public class TemplateFluxController
{
    public static String codeBase(string nameClass)
    {
        return $$"""
        using System.Windows;

        namespace Fluxogrammer.Fluxogramas;
        public partial class {{nameClass}} : Window 
        {
            public {{nameClass}}()
            {
                InitializeComponent();
            }
        } 
        """;
    }
}