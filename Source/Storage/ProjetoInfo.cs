public class ProjetoInfo
{
    public string Nome { get; set; }
    public List<Objeto> objetos { get; set; } = new();
    public List<LinhaStorage> linhass { get; set; } = new();
}