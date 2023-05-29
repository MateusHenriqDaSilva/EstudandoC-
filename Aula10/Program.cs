using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            //  Criando Leao
            FabricarMonstro fabricarMonstro = new FabricarLeao();
            IMonstro monstro = fabricarMonstro.fazerMonstro("black");
            monstro.mostrarMonstro();
            // Criando tigres
            fabricarMonstro = new FabricarTigre();
            monstro = fabricarMonstro.fazerMonstro("blue");
            monstro.mostrarMonstro();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Mensagem: {ex.Message}");
        }
    }
}

// Regiao dos monstros
interface IMonstro
{
    void mostrarMonstro();
}

class Tigre : IMonstro
{
    public Tigre()
    {
        Console.WriteLine("\n O tigre foi criado.");
    }

    public void mostrarMonstro()
    {
        Console.WriteLine("\"ROAAAAAAAAAARRRRRRRR\"");
    }
}

class Leao : IMonstro
{
    public Leao()
    {
        Console.WriteLine("\n Leao foi criado.");
    }

    public void mostrarMonstro()
    {
        Console.WriteLine("\n Uf!! Roarddss!!");
    }
}

// Regiao de fabricacao
abstract class FabricarMonstro
{
    public IMonstro fazerMonstro(string cor)
    {
        Console.WriteLine($"\n O mosntro criado com a cor: {cor}");
        IMonstro monstro = criarMonstro();
        return monstro;
    }

    public abstract IMonstro criarMonstro();
}

class FabricarTigre : FabricarMonstro
{
    public override IMonstro criarMonstro()
    {
        return new Tigre();
    }
}

class FabricarLeao : FabricarMonstro
{
    public override IMonstro criarMonstro()
    {
        return new Leao();
    }
}