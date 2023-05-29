// Testando se 2 é maior que 3?
// Console.WriteLine(2 > 3);
/* Usando multi linha 
-----------------
para comentarios */

// Example 1

/* Criando a classe Jogador que contem 3 atributos vida e saude e leitura 
Criando a classe Jogador que contem 2 metodos RecuperarVida e RecuperarEstamina*/

class Jogador
{
    /* readonly é garantir a imutabilidade de um campo após sua 
    atribuição inicial. Isso pode ser útil em situações 
    em que você deseja ter um valor constante ou que não 
    pode ser modificado após a inicialização */
    readonly double vida;
    readonly double saude;
    readonly string nome = "Leitura";

    public RecuperarVida(double vida)
    {
        vida = vida + 20;
    }

    public RecuperarSaude(double saude)
    {
        saude = saude + 20;
    }

    public RecuperarVidaESaude(double vida, double saude)
    {
        saude = saude + 10;
        vida = vida + 10;
    }

    public Saudacao()
    {
        Console.WriteLine($"{nome}: \n Ola, Player2");
    }

    public Motivar()
    {
        Console.WriteLine($"{nome}: Junto iremos vencer");
        Console.WriteLine("Pra cima !!!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enchendo a Vida");
            // Instanciando o Objeto vida
            Jogador player1 = new();
            // Chamada do metodo recuperar vida no player1
            player1.RecuperarVida();
            // Chamada do metodo recuperar saude no player1
            Console.WriteLine("Enchendo a Saude");
            player1.RecuperarSaude();
            // Chamada do metodo recuperar vida e saude no player1
            Console.WriteLine("Enchendo a Saude e Vida");
            player1.RecuperarVidaESaude();
            // Chamada do metodo Saudar
            player1.Saudacao();
            // Chamada do metodo Motivar
            player1.motivar();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }
    }
}