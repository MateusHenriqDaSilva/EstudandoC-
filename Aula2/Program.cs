using Juizes;

// Definindo namespace
namespace Futebols
{
    abstract class Futebol
    {
        protected string nomeJogador = string.Empty;
        protected Juiz juiz;
        protected string registrarNumero = string.Empty;
        public abstract void SetComportamento(Juiz juiz);
        public abstract void DisplayDetalhes();
    }

    class Carrinho : Futebol
    {
        public Carrinho(string id)
        {
            registrarNumero = id;
            nomeJogador = "Jogador";
            juiz = new FaltaSemPoderes();
        }

        public override void SetComportamento(Juiz juiz)
        {
            this.juiz = juiz;
        }

        public override void DisplayDetalhes()
        {
            Console.WriteLine("Carrinho: " + registrarNumero);
            juiz.Apitar();
        }
    }

    class Sobrenatural : Futebol
    {
        public Sobrenatural(string id)
        {
            registrarNumero = id;
            nomeJogador = "jogador";
            juiz = new FaltaComPoder();
        }

        public override void SetComportamento(Juiz juiz)
        {
            this.juiz = juiz;
        }

        public override void DisplayDetalhes()
        {
            Console.WriteLine("Sobrenatural: " + registrarNumero);
            juiz.Apitar();
        }
    }
}

namespace Juizes
{
    interface Juiz
    {
        void Apitar();
    }

    class FaltaSemPoderes : Juiz
    {
        public void Apitar()
        {
            Console.WriteLine("Cometeu falta sem usar poder");
        }
    }

    class FaltaComPoder : Juiz
    {
        public void Apitar()
        {
            Console.WriteLine("Cometeu falta com poder");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("***Comecou o jogo de Futebol Sobrenatural***");
            Console.WriteLine("Using a Carrinho");
            Futebols.Futebol futebol = new Futebols.Carrinho("B001");
            futebol.DisplayDetalhes();
            Console.WriteLine("****************");
            Juizes.Juiz Apitar = new Juizes.FaltaSemPoderes();
            Console.WriteLine("Definindo compotamento do juiz e verificando no painel falta sem poder");
            futebol.SetComportamento(Apitar);
            futebol.DisplayDetalhes();
            Console.WriteLine("****************");
            Console.WriteLine("Usando falta com poderes");
            futebol = new Futebols.Sobrenatural("A002");
            Console.WriteLine("Definindo compotamento do juiz e verificando no painel falta com poder");
            Apitar = new Juizes.FaltaSemPoderes();
            futebol.SetComportamento(Apitar);
            futebol.DisplayDetalhes();
            Console.WriteLine("****************");
            Console.WriteLine("Definindo compotamento do juiz e verificando no painel falta com poder");
            Apitar = new Juizes.FaltaComPoder();
            futebol.SetComportamento(Apitar);
            futebol.DisplayDetalhes();
            Console.WriteLine("****************");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }
    }
}