using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("--- Demonstração do princípio DRY ---");
            GameInformacao gameInformacao = new("SuperGame");
            GamePreco gamePreco = new();
            superGame.MostrarPreco();
            Game game = new(gameInformacao, gamePreco);
            game = new Game(gameInformacao, gamePreco);
            game.SobreJogo();
            game.MostrarPreco();
            game.MostrarPrecoComDesconto();
            superGame.MostrarPrecoComDesconto();
            superGame.MostrarPrecoAntesDoDesconto();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"mensagem {ex}");
        }
    }
}

public class GameInformacao
{
    readonly string empresaNome { get; set; }
    readonly string gameNome { get; set; }
    readonly string version { get; set; }
    readonly double anosNoMercado { get; set; }

    public GameInformacao(string gameName)
    {
        empresaNome = "SuperGame da empresa MDJV";
        gameNome = "SuperGame";
        version = "1.0";
        anosNoMercado = 10;
    }

    public void MostrarPrecoComDesconto()
    {
        Console.WriteLine("\nDetalhes de preço do jogo SuperGame da empresa MDJV:");
        Console.WriteLine($"Versão: 1.0\nPreço: {atualPreco}");
    }

    public void SobreJogo()
    {
        Console.WriteLine($"\n Game name: {gameNome}");
        Console.WriteLine($"Ano no mercado: {anosNoMercado}");
        Console.WriteLine($"version ocorrencia: {version}");
        Console.WriteLine($"essa é a compania {empresaNome}");
    }
    public void MostrarPrecoAntesDoDesconto()
    {
        Console.WriteLine("\nDetalhes de preço do jogo SuperGame da empresa MDJV:");
        Console.WriteLine("Desconto aplicado:");
        Console.WriteLine($"Jogo: {gameNome}\nVersão: {version} \nDesconto: {descontoPreco}");
    }
}

class GamePreco
{

    public double Preco { get; set; }
    public double DescontoPreco { get; set; }
    public void MostrarPreco()
    {
        Preco = 1000;
        descontoPreco = 800;
    }
}

class Game
{
    readonly string empresaNome;
    readonly string gameNome;
    readonly double minimoIdade;
    readonly string version;
    readonly double atualPreco;
    readonly double descontoPreco;
    public Game(GameInformacao gameInformacao, GamePreco gamePreco)
    {
        empresaNome = gameInformacao.empresaNome;
        gameNome = gameInformacao.gameNome;
        version = gameInformacao.version;
        anosNoMercado = gameInformacao.minimoIdade;
        atualPreco = gamePreco.Preco;
        descontoPreco = gamePreco.DescontoPreco;
    }

    public void SobreOGame()
    {
        Console.WriteLine($"Game name: {gameNome}");
        Console.WriteLine($"Anos da empresa: {anosNoMercado}");
        Console.WriteLine($"Versão: {versao}");
        Console.WriteLine($"Nome da empresa: {empresaNome}");
    }

    public void mostrarPreco()
    {
        Console.WriteLine($"{empresaNome} {gameNome} preco detalhes: ");
    }

    public void MostrarPrecoComDesconto()
    {
        Console.WriteLine($"\n {empresaNome} oferta de desconto BlackFriday");
        Console.WriteLine($"\n Detalhes do preco com desconto");
        Console.WriteLine($"\n {gameNome}  versao: {versao} Desconto Preco: {descontoPreco} ");
    }
}
