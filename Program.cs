using System;

class Program

{

    static void Main()
    {
        //Escolhendo o jogador
        char jogador;
        char maquina;
        char[,] tabuleiro = new char[3, 3];

        Console.WriteLine("");
        Console.WriteLine("");
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
            Inicio(jogador, maquina, tabuleiro);

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
        int numero = 0;

        //Criação do jogo
        Console.WriteLine();
        Console.WriteLine();

        if (numero < 1)
        {
            Console.WriteLine("");
            Console.WriteLine("Ínicio do Jogo");

            //numero++;
        }

        int num = 0;

        for (int x = 0; x < 3; x++)
        {
            int n = 0;
            for (int y = 0; y < 3; y++)
            {
                if (y < 3)
                {
                    Console.Write($" {num} ");
                    num++;
                    n++;

                    if (y < 2)
                    {
                        Console.Write("│");
                    }
                }

                if (x < 2)
                {
                    if (n == 3)
                    {

                        Console.WriteLine("");
                        Console.WriteLine("───┼───┼───");
                    }
                }
            }
            n = 0;

        }
        Console.WriteLine("");
        

    }

    static char Maquina(char jogador)
    {
        char maquina;

        if (jogador == 'x' || jogador == 'X')
        {
            maquina = 'O';
            jogador = 'X';
        }
        else
        {
            jogador = 'X';
            maquina = 'O';
        }

        return maquina;
    }


    static void Inicio(char jogador, char maquina, char[,] tabuleiro)
    {
        int casas = 1;

        do
        {
            if (casas < 10)
            {
                //Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Qual casa você que jogar?");
                int casa = int.Parse(Console.ReadLine());

                casas++;

                InicioDoJogo(jogador, maquina, casa, tabuleiro);
            }
        } while (casas < 10);

        if (casas >= 9)
        {
            JogarNovamente();
        }


    }

    static void JogarNovamente()
    {
        Console.WriteLine("");
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

    static void InicioDoJogo(char jogador, char maquina, int casa, char[,] tabuleiro)
    {
        int numero = 0;

        numero++;

        Tabuleiro(tabuleiro);
    }
}
