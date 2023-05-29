using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Sistema de punição");

            // Jogador 1
            Jogador Kazak = new Jogador("Kazak", 5000, true);

            // Iniciando verificação de status
            VerificaStatus verificaStatus = new VerificaStatus();
            bool aprovadoStatus = verificaStatus.JaFoiViolento(Kazak);

            string status;
            string reacao;

            if (!aprovadoStatus)
            {
                status = "Protegido";
                reacao = "Pode entrar em zonas seguras";
            }
            else
            {
                status = "Violento";
                reacao = "Não pode entrar em zonas seguras";
            }

            Console.WriteLine($"{Kazak.nome} aplicacao status: {status}");
            Console.WriteLine($"Relembrando sua reacao: {reacao}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message: {ex.Message}");
        }
    }
}

class Jogador
{
    public string nome;
    public double dinheiro;
    public bool foiStatusViolento;

    public Jogador(string nome, double dinheiro = 10000, bool foiStatusViolento = false)
    {
        this.nome = nome;
        this.dinheiro = dinheiro;
        this.foiStatusViolento = foiStatusViolento;
    }
}

class VerificaStatus
{
    public bool JaFoiViolento(Jogador jogador)
    {
        Console.WriteLine($"Verifica se {jogador.nome} já foi violento");
        return jogador.foiStatusViolento;
    }
}
