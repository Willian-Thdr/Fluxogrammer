public class xamlCodeTemplate
{
    public static String codeTemplate()
    {
        return """
        <Window x:Class="nomeDoProjeto.subPastasDoArquivo.NomeDoArquivo"
                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                xmlns:local="clr-namespace:nomeDoProjeto"
                mc:Ignorable="d"
                Title="nomeDaJanela" Height="450" Width="800">

        </Window>
        """;
    }
}