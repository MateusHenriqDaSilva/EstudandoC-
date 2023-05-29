using System;
using System.Collections.Generic;

interface IMagia
{
    void DarMagia();
}

interface ICanalizarMagia
{
    void CanalizarMagia();
}

interface IEncherVida
{
    void EncherVida();
}

class EncherMetadeDaVida : IEncherVida
{
    public void EncherVida()
    {
        Console.WriteLine("Recuperando metade da vida");
    }
}

class EncherVidaToda : IEncherVida
{
    public void EncherVida()
    {
        Console.WriteLine("Recuperando a vida toda");
    }
}

class MagiaAvancada : IMagia, ICanalizarMagia
{
    public void DarMagia()
    {
        Console.WriteLine("Usando magia avançada");
    }

    public void CanalizarMagia()
    {
        Console.WriteLine("Canalizando magia");
    }
}

class MagiaBasica : IMagia
{
    public void DarMagia()
    {
        Console.WriteLine("Usando magia básica");
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("--- Demonstração do ISP ---");
            IMagia magia = new MagiaAvancada();
            magia.DarMagia();
            ((ICanalizarMagia)magia).CanalizarMagia();

            List<IMagia> magias = new List<IMagia>
            {
                new MagiaAvancada(),
                new MagiaBasica()
            };

            foreach (IMagia magiaItem in magias)
            {
                magiaItem.DarMagia();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }
    }
}