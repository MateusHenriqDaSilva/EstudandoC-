using System;

// Iniciando Programa
// Classe abstrata chamada RoboCompras
// Funções: visitarLugar -> visitar -> lugar
// Funções: proximoPasso -> executar -> passos
// Funções: gastosAteOLugar -> valor -> gasto
    // verificaSefoiGeradoCupom -> verifica -> cupom
    // pegarCupom -> pegar -> cupom
// Funções: carregarProduto -> pegar -> produto

/* Classes -> derivadas -> override */
// SelecionarProduto -> selecionar -> produto
// ComprarProduto -> comprar -> Produto
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("--- Demonstração do método utilizando template");
            Console.WriteLine("--- Criaremos o método RoboCompras -> Frutas ---");
            RoboCompras roboCompras = new Maca();
            roboCompras.ComprarProduto();
            Console.WriteLine(" Criando um novo robô ");
            roboCompras = new Banana();
            roboCompras.ComprarProduto();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Mensagem: {ex}");
        }
    }
}

// <Sumario>
// ComprarProduto -> Estrutura dos passo a passo
// </Sumario>
public abstract class RoboCompras
{
    // passo 1:
    protected void visitarMercado()
    {
        Console.WriteLine("1. Vá visitar o mercado agora por gentileza");
    }

    // passo 2:
    protected abstract void selecionarProduto();

    // passo 3:
    protected void gastosAteOLugar()
    {
        Console.WriteLine("3. Gerando contas de pagamento");
    }

    // passo 4:
    protected void carregarProduto()
    {
        Console.WriteLine("4. O Produto foi pego");
    }

    // Método Completo
    public void ComprarProduto()
    {
        // Passo 1:
        visitarMercado();

        // Passo 2:
        selecionarProduto();
        if (verificaSefoiGeradoCupom())
        {
            pegarCupom();
        }

        // Passo 3:
        gastosAteOLugar();

        // Passo 4:
        carregarProduto();
    }

    protected virtual void pegarCupom()
    {
        Console.WriteLine("\t Guia do cupom foi Pega");
    }

    protected virtual bool verificaSefoiGeradoCupom()
    {
        return false;
    }
}

// Criando a classe completa: Maca
public class Maca : RoboCompras
{
    protected override bool verificaSefoiGeradoCupom()
    {
        return true;
    }

    protected override void selecionarProduto()
    {
        Console.WriteLine("2. Pegando Maçã");
    }
}

// Criando a classe completa: Banana
public class Banana : RoboCompras
{
    protected override void selecionarProduto()
    {
        Console.WriteLine("2. Pegando banana");
    }
}
