using System;
using tabuleiro;
using marcador;
using exceptions;

namespace Jogo_Da_Velha_Console
{
    class Program
    {
        static void Main(string[] args)
        {

            //10 jogadas
            for (int contador = 0; contador < 10; contador++)
            {
                Tabuleiro tabuleiro = new Tabuleiro();
                try
                {
                    while (tabuleiro.fimDaPartida == false)
                    {
                        //Limpando o console.
                        Console.Clear();

                        //Imprimindo uma nova tela pro console.
                        Tela.imprimirTabuleiro(tabuleiro);

                        //Captura a posição onde o marcador será adicionado
                        PosicaoMarcador destino = tabuleiro.lerPosicaoTabuleiro();

                        //adiciona o marcador na posição selecionada
                        tabuleiro.addMarcor(destino);

                        RegrasDoJogo.verificarQntMaximaDeJogadas(tabuleiro);
                        RegrasDoJogo.verificarSeTemVencedor(tabuleiro, destino);
                    }

                    //Resultado
                    //Limpando o console.
                    Console.Clear();
                    Tela.imprimirTabuleiro(tabuleiro);
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }
            }
        }
    }
}
