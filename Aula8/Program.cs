using System;

interface IDeposito
{
    void salvarNoDeposito(string id);
}

class Deposito : IDeposito
{
    readonly IDeposito deposito;

    public Deposito(IDeposito deposito)
    {
        this.deposito = deposito;
    }

    public void salvarNoDeposito(string id)
    {
        Console.WriteLine($"O id: {id} salvo no Deposito");
    }
}

class DepositoDinheiro : IDeposito
{
    public void salvarNoDeposito(string id)
    {
        Console.WriteLine($"O id: {id} está salvo no depósito");
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            IDeposito deposito = new Deposito(null);
            Deposito usarDeposito = new Deposito(deposito);
            usarDeposito.salvarNoDeposito("0001");

            // Usando deposito
            deposito = new DepositoDinheiro();
            usarDeposito = new Deposito(deposito);
            usarDeposito.salvarNoDeposito("0002");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }
    }
}