using System;
using tabuleiro;
using marcador;

namespace Jogo_Da_Velha_Console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tabuleiro)
        {
            // Exibindo colunas referencia para o lançamento dos marcadores
            Console.WriteLine("  A B C");

            for (int linha = 0; linha < tabuleiro.linhas; linha++)
            {
                // Exibindo linhas referencia para o lançamento dos marcadores
                Console.Write(linha + " ");
                for (int coluna = 0; coluna < tabuleiro.colunas; coluna++)
                {
                    formatarTabuleiro(tabuleiro, linha, coluna);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("-------------------------------");


            //Exibindo mensagem do resultado quando a partida chega ao fim.
            if(tabuleiro.fimDaPartida)
            {
                Console.WriteLine();
                Console.WriteLine(tabuleiro.resultado);
            }
        } 
        
        // Organiza como os marcadores serão exibidos no console.
        public static void formatarTabuleiro(Tabuleiro tabuleiro, int linha, int coluna)
        {
            //posição vazia do tabuleiro
            if (tabuleiro.marcadores[linha, coluna] == null)
            {
                if(coluna == 1)
                {
                    //colocando duas barras na coluna do meio
                    Console.Write("| |");
                } else
                {
                    Console.Write(" ");
                }
            }
            //posição com marcadores
            else
            {
                if(coluna == 1)
                {
                    //colocando um marcador entre as duas barras na coluna do meio
                    if (tabuleiro.marcadores[linha, coluna].cor == Cor.Branca)
                    {
                        Console.Write($"|{tabuleiro.marcadores[linha, coluna]}|");
                    }
                    else
                    {
                        //ConsoleColor alterando a cor do X no console
                        //armazenando a cor padrão do console
                        ConsoleColor aux = Console.ForegroundColor;
                        //modificando a cor padrão para amarelo
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        //imprimindo em amarelo
                        Console.Write($"|{tabuleiro.marcadores[linha, coluna]}|");
                        //retornando a cor padrão do console.
                        Console.ForegroundColor = aux;

                    }
                } else
                {
                    if (tabuleiro.marcadores[linha, coluna].cor == Cor.Branca)
                    {
                        Console.Write($"{tabuleiro.marcadores[linha, coluna]}");
                    }
                    else
                    {
                        //ConsoleColor alterando a cor do X no console
                        //armazenando a cor padrão do console
                        ConsoleColor aux = Console.ForegroundColor;
                        //modificando a cor padrão para amarelo
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        //imprimindo em amarelo
                        Console.Write($"{tabuleiro.marcadores[linha, coluna]}");
                        //retornando a cor padrão do console.
                        Console.ForegroundColor = aux;

                    }
                }
            }
        }

    }
}
