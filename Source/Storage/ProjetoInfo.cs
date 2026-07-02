public class ProjetoInfo
{
    public string Nome { get; set; }
    public List<Objeto> objetos { get; set; } = new();
    public List<Linhas> linhas { get; set; } = new();
}