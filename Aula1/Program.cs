using System;

namespace Funcoes
{
    class Exemplos
    {
        static void Main(string[] args)
        {
            // Polimorfismo
            Console.WriteLine("Sons de diferentes Tipos de Pessoas");
            // Objeto Humano Instanciado
            IPessoa humano = new Humano();
            humano.Som();
            // Objeto Ogro
            IPessoa ogro = new Ogro();
            ogro.Som();
            // Objeto Elfo
            IPessoa elfo = new Elfo();
            elfo.Som();

            // Definindo sons de diferentes pessoas 
            Console.WriteLine("Sons aleatorios de diferentes pessoas");
            // Criando uma fabrica de pessoas aleatoriamente
            IPessoa pessoa = PessoaProducao.GetPessoa();
            Console.WriteLine("aleatorio: 1");
            // chamando funcao interna para criar som 
            PessoaProducao.CriarSom(pessoa);
            Console.WriteLine("aleatorio: 2");
            pessoa = PessoaProducao.GetPessoa();
            // chamando funcao interna para criar som 
            PessoaProducao.CriarSom(pessoa);
            Console.WriteLine("aleatorio: 3");
            pessoa = PessoaProducao.GetPessoa();
            // chamando funcao interna para criar som 
            PessoaProducao.CriarSom(pessoa);

            Console.ReadKey();
        }

        // Definindo Interface Super Types
        interface IPessoa
        {
            void Som();
        }
        // Criando a classe pessoa de forma abstrata e os metodos abstratos
        abstract class Pessoa {
            public abstract void Som();
        }
        // Classes abstratas de Tipos de Pessoas 
        // Difinicao da Classe humano e override nas classes

        // Ao usar override, estamos dizendo ao compilador que o método na subclasse deve substituir o comportamento do método da superclasse, 
        // em vez de simplesmente ocultá-lo. Dessa forma, a subclasse herda a funcionalidade do método da superclasse, 
        // mas também pode adicionar ou modificar comportamentos específicos, de acordo com as necessidades da subclasse.
        class Humano : IPessoa
        {
            public void Som()
            {
                Console.WriteLine("Inteligencia educação resolve tudo !!!");
            }
        }
        // Definicao da classe Ogro
        class Ogro : IPessoa
        {
            public void Som()
            {
                Console.WriteLine("Ola seres inferiores !!!");
            }
        }
        // Definicao da classe Elfo
        class Elfo : IPessoa
        {
            public void Som()
            {
                Console.WriteLine("Humanos Fracos e inuteis !!!");
            }
        }
        // Criando a classe abstrata de producao de pessoas 
        class PessoaProducao
        {
            // Definindo um metodo STATIC dentro da classe pessoa
            internal static IPessoa GetPessoa()
            {
                IPessoa pessoa;
                // Instanciando uma classe random
                Random random = new Random();
                // Definindo temporariamente os numeros aleatorios
                int temporario = random.Next(0, 3);
                // Verificação da criação de fabrica aleatoria utilizando switch
                pessoa = temporario switch
                {
                    0 => new Humano(),
                    1 => new Ogro(),
                    _ => new Elfo()
                };
                // verificação de fabrica aleatoria utilizando IF
                // if (temporario == 0)
                // {
                //     pessoa = new Humano();
                // }
                // else if (temporario == 1)
                // {
                //     pessoa = new Ogro();
                // }
                // else
                // {
                //     pessoa = new Elfo();
                // }

                // Retorna o objeto criado
                return pessoa;
            }
            // Funcao interna da classe estatica para criar som de pessoas 
            
            internal static void CriarSom(IPessoa pessoa)
            {
                pessoa.Som();
            }
        }
    }
}