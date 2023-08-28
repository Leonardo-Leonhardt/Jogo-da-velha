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

            jogador = Char.ToUpper(jogador);

            //Criar o tabuleito
            ImprimeTabuleiro(tabuleiro);

            //Console.WriteLine($"A maquina vai ficar com o {maquina} e o jogador fica com o {jogador}");

            //Ínicio do Jogo
            Inicio(jogador, maquina, tabuleiro);

        }
        else
        {

            Console.WriteLine();
            Console.WriteLine("Caractere inválida!!!");
            Console.WriteLine("Digite novamente!");
            Console.WriteLine();

            Main();
        }
    }

    static void ImprimeTabuleiro(char[,] tabuleiro)
    {
        //Criação do jogo
        Console.WriteLine();
        Console.WriteLine("");
        Console.WriteLine("Ínicio do Jogo");
        Console.WriteLine("");


        char num = '1';

        for (int x = 0; x < 3; x++)
        {
            int n = 0;
            for (int y = 0; y < 3; y++)
            {
                if (y < 3)
                {
                    Console.Write($" {num} ");
                    tabuleiro[x, y] = num;
                    num++;
                    n++;

                    if (y < 2)
                    {
                        Console.Write("│");
                    }


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
            n = 0;

        }
        Console.WriteLine("");


    }

    static char[,] Tabuleiro(char[,] tabuleiro, int numero)
    {
        //Imprime do jogo
        Console.WriteLine("");

        char num = '1';

        if (numero != 0)
        {
            for (int x = 0; x < 3; x++)
            {
                int n = 0;
                for (int y = 0; y < 3; y++)
                {
                    if (y < 3)
                    {
                        Console.Write($" {tabuleiro[x, y]} ");
                        num++;
                        n++;

                        if (y < 2)
                        {
                            Console.Write("│");
                        }


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
                n = 0;

            }
        }
        Console.WriteLine("");


        return tabuleiro;

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

    static void Inicio(char jogador, char maquina, char[,] tabuleiro)
    {
        int casas = 0;

        do
        {
            if (casas < 9)
            {
                Console.WriteLine("");
                Console.WriteLine("Qual casa você que jogar?");
                int casa = int.Parse(Console.ReadLine());

                if (casa > 0 && casa < 10)
                {
                    casas++;

                    InicioDoJogo(jogador, maquina, casa, tabuleiro);
                    if (casas >= 9)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Fim do jogo!!!");
                        Console.WriteLine("Empate!");
                        JogarNovamente();
                    }
                    else
                    {

                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("Jogada da maquina!!");

                        casas = JogadaDaMaquina(maquina, jogador, tabuleiro, casas);
                        Console.WriteLine($"{casas}");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Casa inválida!!!");
                    Console.WriteLine("Digite novamente!");
                    Console.WriteLine();
                }
            }
        } while (casas < 10);

    }

    static void JogarNovamente()
    {
        Console.WriteLine("");
        Console.WriteLine("Você quer jogar de novo? (S/N)");
        char resposta = char.Parse(Console.ReadLine());

        //Responde se que joga de novo ou não
        if (resposta == 's' || resposta == 'S')
        {
            Main();
        }
        else if (resposta == 'n' || resposta == 'N')
        {
            return;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Caractere inválida!!!");
            Console.WriteLine("Digite novamente!");
            Console.WriteLine();

            JogarNovamente();
        }
    }

    static void InicioDoJogo(char jogador, char maquina, int casa, char[,] tabuleiro)
    {
        int numero = 0;
        char[,] tabuleiroComCasas = new char[3, 3];
        tabuleiroComCasas = Tabuleiro(tabuleiro, numero);
        int num = 1;

        //Preencher a casa
        for (int x = 0; x < tabuleiro.GetLength(0); x++)
        {
            for (int i = 0; i < tabuleiro.GetLength(1); i++)
            {

                if (casa == num)
                {
                    tabuleiroComCasas[x, i] = jogador;
                }
                num++;
            }
        }

        //Imprime com a casa preenchida
        numero++;
        Tabuleiro(tabuleiroComCasas, numero);
    }
    static int JogadaDaMaquina(char maquina, char jogador, char[,] tabuleiro, int casas)
    {
        Random random = new Random();
        int num = random.Next(1, 10);
        int cont = 0;
        int numero = 0;

        //faz a jogada da maquina
        for (int x = 0; x < tabuleiro.GetLength(0); x++)
        {
            for (int i = 0; i < tabuleiro.GetLength(1); i++)
            {
                if (tabuleiro[x, i] != jogador && tabuleiro[x, i] != maquina)
                {
                    cont++;

                    if (cont == num)
                    {
                        tabuleiro[x, i] = maquina;
                        numero++;
                        Tabuleiro(tabuleiro, numero);
                        casas++;
                        return casas;
                    }
                }
            }
        }

        return JogadaDaMaquina(maquina, jogador, tabuleiro, casas);
    }

}

