using System;

class Program
{

    static void Main()
    {
        //Escolhendo o jogador
        char jogador;
        char maquina;
        char[,] tabuleiro = new char[3, 3];

        Console.WriteLine("Você que jogar com X ou O? ");
        jogador = char.Parse(Console.ReadLine());

        if (jogador == 'x' || jogador == 'X' || jogador == 'o' || jogador == 'O')
        {
            //Dar o jogador da maquina
            maquina = Maquina(jogador);

            //Criar o tabuleito
            Tabuleiro(tabuleiro);

            //Console.WriteLine($"A maquina vai ficar com o {maquina} e o jogador fica com o {jogador}");

            //Ínicio do Jogo
            Inicio(jogador, maquina);

        }
        else
        {

            Console.WriteLine();
            Console.WriteLine("Caractere Errado!!!");
            Console.WriteLine("Digite novamente!");
            Console.WriteLine();

            Main();
        }
    }

    static void Tabuleiro(char[,] tabuleiro)
    {
        //Criação do jogo
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Ínicio do Jogo");
        Console.WriteLine();

        int num = 1;

        for (int x = 0; x < 5; x++)
        {
            if (x % 2 != 0)
            {
                Console.Write("───┼───┼───");
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write($" {num} ");
                        num++;
                    }
                    else
                    {
                        Console.Write("│");
                    }
                }
            }
            Console.WriteLine();
        }
    }

    static char Maquina(char jogador)
    {
        char maquina;

        if (jogador == 'x' || jogador == 'X')
        {
            maquina = 'O';
        }
        else
        {
            maquina = 'X';
        }

        return maquina;
    }


    static void Inicio(char jogador, char maquina)
    {
        int casas = 1;

        do
        {
            if (casas < 10)
            {
                Console.WriteLine("Qual casa você que jogar?");
                int casa = int.Parse(Console.ReadLine());

                casas++;
            }
        } while (casas < 10);

        if (casas >= 9)
        {
            JogarNovamente();
        }


    }

    static void JogarNovamente()
    {
        Console.WriteLine("Você quer jogar de novo? (S/N)");
        char resposta = char.Parse(Console.ReadLine());

        if (resposta == 's' || resposta == 'S')
        {
            Main();
        }
        else if (resposta == 'n' || resposta == 'N')
        {

        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Caractere Errado!!!");
            Console.WriteLine("Digite novamente!");
            Console.WriteLine();

            JogarNovamente();
        }
    }

}