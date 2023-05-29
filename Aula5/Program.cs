using System;
using System.Collections.Generic;

// • Princípio de Responsabilidade Única (SRP)
// • Princípio Aberto/Fechado (OCP)
// • Princípio da Substituição de Liskov (LSP)
// • Princípio de Segregação de Interface (ISP)
// • Princípio de Inversão de Dependência (DIP) 

/*é um dos princípios do SOLID, um conjunto de princípios de design de software que visam promover a construção de código mais modular, extensível e de fácil manutenção.

O OCP estabelece que uma entidade de software (uma classe, 
módulo, função, etc.) deve estar aberta para extensão, mas 
fechada para modificação. Em outras palavras, o comportamento de
uma entidade deve poder ser estendido sem a necessidade de alterar 
seu código fonte*/

// OCP EXAMPLE: 
// Criar uma classe monstro onde monstro tem uma caixa de detalhes, tem seu nivel de conhecimento, e um ID Auto-Generativo

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("*** Demonstração do OCP ***");
            List<Jogador> guerreiroJogadores = Ajudante.CriarListaDeJogadorArqueiro();
            List<Jogador> arqueiroJogadores = Ajudante.CriarListaDeJogadorGuerreiro();
            Console.WriteLine("=== Resultados ===");
            foreach (Jogador jogador in guerreiroJogadores)
            {
                Console.WriteLine(jogador);
            }
            foreach (Jogador jogador in arqueiroJogadores)
            {
                Console.WriteLine(jogador);
            }
            // Para jogadores guerreiros
            IDecidirVocacao decidirJogador = new DecidirVocacaoGuerreiro();
            foreach (Jogador jogador in guerreiroJogadores)
            {
                decidirJogador.EscolherVocacao(jogador);
            }
            // Para jogadores arqueiros
            decidirJogador = new DecidirVocacaoArqueiro();
            foreach (Jogador jogador in arqueiroJogadores)
            {
                decidirJogador.EscolherVocacao(jogador);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }
    }
}

class Jogador
{
    internal string nome;
    internal string registrarNumero;
    internal double nivel;
    internal string vocacao;

    public Jogador(string nome, string registrarNumero, double nivel, string vocacao)
    {
        this.nome = nome;
        this.registrarNumero = registrarNumero;
        this.nivel = nivel;
        this.vocacao = vocacao;
    }

    public override string ToString()
    {
        return $@"
        Nome: {nome}
        Registrar número: {registrarNumero}
        Nível: {nivel}
        Vocação: {vocacao}
        ***********
        ";
    }
}

interface IDecidirVocacao
{
    void EscolherVocacao(Jogador jogador);
}

class DecidirVocacaoArqueiro : IDecidirVocacao
{
    public void EscolherVocacao(Jogador jogador)
    {
        if (jogador.vocacao == "arqueiro")
        {
            if (jogador.nivel > 20)
            {
                Console.WriteLine($"{jogador.registrarNumero} recebeu a vocação Arqueiro especialista em bestas");
            }
        }
    }
}

class DecidirVocacaoGuerreiro : IDecidirVocacao
{
    public void EscolherVocacao(Jogador jogador)
    {
        if (jogador.vocacao == "guerreiro")
        {
            if (jogador.nivel > 20)
            {
                Console.WriteLine($"{jogador.registrarNumero} recebeu a distinção de guerreiro especialista em espadas de 2 mãos");
            }
        }
    }
}

class Ajudante
{
    public static List<Jogador> CriarListaDeJogadorArqueiro()
    {
        Jogador alienados = new Jogador("Alienados", "001", 20, "guerreiro");
        Jogador springs = new Jogador("Springs", "002", 40, "guerreiro");

        List<Jogador> jogadores = new List<Jogador>
        {
        alienados,
        springs
        };
        return jogadores;
    }

    public static List<Jogador> CriarListaDeJogadorGuerreiro()
    {
        Jogador clonados = new Jogador("Clonados", "003", 20, "arqueiro");
        Jogador revelados = new Jogador("Revelados", "004", 40, "arqueiro");

        List<Jogador> jogadores = new List<Jogador>
        {
            clonados,
            revelados
        };

        return jogadores;
    }
}