using System;
using System.Collections.Generic;

interface MineracaoAnterior
{
    void CarregarMineracaoAnterior();
}

interface ProcessarNovaMineracao
{
    void ProcessarNovaMineracao();
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("--- Demonstração LSP ---");
            AjudarJogador ajudar = new AjudarJogador();
            // Instanciando 2 registros de jogador
            RegistrarJogador jogador1 = new RegistrarJogador("jogador1");
            RegistrarJogador jogador2 = new RegistrarJogador("jogador2");
            // Chamando a classe AjudarJogador e adicionando jogadores
            ajudar.AdicionarJogador(jogador1);
            ajudar.AdicionarJogador(jogador2);
            // Processando mineração
            ajudar.MostrarMineracaoAnterior();
            ajudar.ProcessarNovaMineracao();
            // Adicionando jogador convidado para minerar
            JogadorConvidado jogadorConvidado1 = new JogadorConvidado();
            ajudar.AdicionarJogador(jogadorConvidado1);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }
    }
}

class RegistrarJogador : MineracaoAnterior, ProcessarNovaMineracao
{
    readonly string nome;

    public RegistrarJogador(string nome)
    {
        this.nome = nome;
    }

    public void CarregarMineracaoAnterior()
    {
        Console.WriteLine($"Recuperando últimos detalhes de mineração de {nome}");
    }

    public void ProcessarNovaMineracao()
    {
        Console.WriteLine($"Processando requisição de ocorrência de mineração para {nome}");
    }
}

class AjudarJogador
{
    readonly List<MineracaoAnterior> jogadores = new List<MineracaoAnterior>();

    public void AdicionarJogador(MineracaoAnterior jogador)
    {
        jogadores.Add(jogador);
    }

    public void MostrarMineracaoAnterior()
    {
        foreach (MineracaoAnterior jogador in jogadores)
        {
            jogador.CarregarMineracaoAnterior();
            Console.WriteLine("-----------");
        }
    }

    public void ProcessarNovaMineracao()
    {
        foreach (ProcessarNovaMineracao jogador in jogadores)
        {
            jogador.ProcessarNovaMineracao();
            Console.WriteLine("------------");
        }
    }
}

class JogadorConvidado : MineracaoAnterior, ProcessarNovaMineracao
{
    readonly List<MineracaoAnterior> mineracaoAnterior = new List<MineracaoAnterior>();
    readonly List<ProcessarNovaMineracao> processarNovaMineracao = new List<ProcessarNovaMineracao>();

    public void CarregarMineracaoAnterior()
    {
        Console.WriteLine("Carregando mineração anterior de jogador convidado");
    }

    public void ProcessarNovaMineracao()
    {
        Console.WriteLine("Processando nova mineração para jogador convidado");
    }
}