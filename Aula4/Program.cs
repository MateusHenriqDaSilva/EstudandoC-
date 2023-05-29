using System;

// • Princípio de Responsabilidade Única (SRP)
// • Princípio Aberto/Fechado (OCP)
// • Princípio da Substituição de Liskov (LSP)
// • Princípio de Segregação de Interface (ISP)
// • Princípio de Inversão de Dependência (DIP) 

// SRP EXAMPLE: 
// Criar uma classe monstro onde monstro tem uma caixa de detalhes, tem seu nivel de conhecimento, e um ID Auto-Generativo

class Monstro
{
    public string id;
    public string primeiroNome;
    public string segundoNome;
    public double experiencia;

    public void gerarMonstro(string primeiroNome, string segundoNome, double experiencia)
    {
        this.primeiroNome = primeiroNome;
        this.segundoNome = segundoNome;
        this.experiencia = experiencia;
        id = "Não gerar ID";
    }

    public void mostrarDetalhes()
    {
        Console.WriteLine($"O nome do Monstro: {primeiroNome} {segundoNome}");
        Console.WriteLine($"Experiencia do monstro: {experiencia}");
    }

    public string checarNivelDoMonstro()
    {
        if (experiencia < 1000)
            return "Facil";
        else if (experiencia > 1000 && experiencia < 10000)
            return "Medio";
        else
            return "Dificil";
    }

    public string gerarId()
    {
        int random = new Random().Next(1000);
        id = string.Concat(primeiroNome[0], random);
        return id;
    }
}



// --------------------------------------------------------------------------------------------------------------------------
// Exemplo de SRP 2
class Monstro2
{
    public string id;
    public string primeiroNome;
    public string segundoNome;
    public double experiencia;

    public void gerarMonstro(string primeiroNome, string segundoNome, double experiencia)
    {
        this.primeiroNome = primeiroNome;
        this.segundoNome = segundoNome;
        this.experiencia = experiencia;
        id = "Não gerar ID";
    }

    public void mostrarDetalhes()
    {
        Console.WriteLine($"O nome do Monstro: {primeiroNome} {segundoNome}");
        Console.WriteLine($"Experiência do monstro: {experiencia}");
    }
}

class ChecarNivel
{
    public string checarNivelDoMonstro(double experiencia)
    {
        if (experiencia < 1000)
            return "Facil";
        else if (experiencia > 1000 && experiencia < 10000)
            return "Medio";
        else
            return "Dificil";
    }
}

class GerarId
{
    public string gerarId(string primeiroNome)
    {
        int random = new Random().Next(1000);
        string id = string.Concat(primeiroNome[0], random);
        return id;
    }

    public void mostrarDetalhes(string primeiroNome, string segundoNome, double experiencia)
    {
        Console.WriteLine($"O nome do Monstro: {primeiroNome} {segundoNome}");
        Console.WriteLine($"Experiencia do monstro: {experiencia}");
    }
}

class MapearMonstro
{
    public static void mostrarMonstroDetalhes(Monstro2 monstro)
    {
        monstro.mostrarDetalhes();
    }

    public static void mostrarMonstroId(Monstro2 monstro)
    {
        GerarId idGerador = new GerarId();
        string monstroId = idGerador.gerarId(monstro.primeiroNome);
        Console.WriteLine($"O monstro id: {monstroId}");
    }

    public static void mostrarNivelMonstro(Monstro2 monstro)
    {
        ChecarNivel checarNivel = new ChecarNivel();
        string nivel = checarNivel.checarNivelDoMonstro(monstro.experiencia);
        Console.WriteLine($"Esse monstro é: {nivel}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Exemplo 1
            Console.WriteLine("*** Demonstracao do SRP ***");
            Monstro tartaruga = new Monstro();
            tartaruga.gerarMonstro("Tartaruga", "Pequena", 200);
            tartaruga.mostrarDetalhes();
            string monstroId = tartaruga.gerarId();
            Console.WriteLine($"O monstro id: {monstroId}");
            Console.WriteLine($"Essa tartaruga tem a experiencia: {tartaruga.checarNivelDoMonstro()}");
            Console.WriteLine("*********");
            Monstro tartarugaMedia = new Monstro();
            tartarugaMedia.gerarMonstro("tartaruga", "media", 700);
            tartarugaMedia.mostrarDetalhes();
            string tartarugaMediaId = tartarugaMedia.gerarId();
            Console.WriteLine($"A tartaruga media tem a experiencia: {tartarugaMedia.checarNivelDoMonstro()}");
            // Exemplo 2
            Console.WriteLine("*** Demonstracao do SRP MAIN 2***");
            Monstro2 tartaruga1 = new Monstro2();
            tartaruga1.gerarMonstro("Tartaruga", "Pequena", 200);
            MapearMonstro.mostrarMonstroDetalhes(tartaruga1);
            MapearMonstro.mostrarMonstroId(tartaruga1);
            MapearMonstro.mostrarNivelMonstro(tartaruga1);
            Console.WriteLine("*********");
            Monstro2 tartarugaMedia2 = new Monstro2();
            tartarugaMedia2.gerarMonstro("Tartaruga", "Média", 5000);
            MapearMonstro.mostrarMonstroDetalhes(tartarugaMedia2);
            MapearMonstro.mostrarMonstroId(tartarugaMedia2);
            MapearMonstro.mostrarNivelMonstro(tartarugaMedia2);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }
    }
}

