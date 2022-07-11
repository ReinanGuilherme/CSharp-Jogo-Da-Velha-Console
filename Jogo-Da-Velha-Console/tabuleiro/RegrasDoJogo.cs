using System;
using marcador;
using exceptions;

namespace tabuleiro
{
    class RegrasDoJogo
    {
        public static void verificarSeTemVencedor(Tabuleiro tabuleiro, PosicaoMarcador posicao)
        {
            int contadorLinhas = 0;
            int contadorColunas = 0;

            // For responsavel por percorrer todas as linhas da matriz de uma mesma coluna como base e verificar se todos os elementos são iguais
            for (int contador = 0; contador < 3; contador ++)
            {
                //para cada elemento igual é incrementado +1 para o contadorLinhas.
                if((tabuleiro.marcadores[0, posicao.coluna] + "") == (tabuleiro.marcadores[contador, posicao.coluna] + ""))
                {
                    contadorLinhas++;

                    // quando o contadorLinhas for igual a 3 então significa que temos um vencedor, pois, todas as linhas da mesma coluna possuem o mesmo Marcador.
                    if(contadorLinhas == 3)
                    {
                        tabuleiro.fimDaPartida = true;
                        tabuleiro.resultado = $"Jogador ({tabuleiro.marcadores[posicao.linha, posicao.coluna]}) foi o vencedor.";
                    }
                }
            }

            // For responsavel por percorrer todas as colunas da matriz de uma mesma linha como base e verificar se todos os elementos são iguais
            for (int contador = 0; contador < 3; contador++)
            {
                //para cada elemento igual é incrementado +1 para o contadorColunas.
                if ((tabuleiro.marcadores[posicao.linha, 0] + "") == (tabuleiro.marcadores[posicao.linha, contador] + ""))
                {
                    contadorColunas++;

                    // quando o contadorColunas for igual a 3 então significa que temos um vencedor, pois, todas as colunas da mesma linha possuem o mesmo Marcador.
                    if (contadorColunas == 3)
                    {
                        tabuleiro.fimDaPartida = true;
                        tabuleiro.resultado = $"Jogador ({tabuleiro.marcadores[posicao.linha, posicao.coluna]}) foi o vencedor.";
                    }
                }
            }

            // Responsavel por verificar em um angulo diagonal da posição(a0 para c2)
            if ((tabuleiro.marcadores[0, 0] + "") == (tabuleiro.marcadores[1, 1] + "") && (tabuleiro.marcadores[0, 0] + "") == (tabuleiro.marcadores[2, 2] + "") && (tabuleiro.marcadores[0, 0]) != null)
            {
                tabuleiro.fimDaPartida = true;
                tabuleiro.resultado = $"Jogador ({tabuleiro.marcadores[posicao.linha, posicao.coluna]}) foi o vencedor.";

            }
            // Responsavel por verificar em um angulo diagonal da posição(a2 para c0)
            else if ((tabuleiro.marcadores[0, 2] + "") == (tabuleiro.marcadores[1, 1] + "") && (tabuleiro.marcadores[0, 2] + "") == (tabuleiro.marcadores[2, 0] + "") && (tabuleiro.marcadores[0, 2]) != null)
            {
                tabuleiro.fimDaPartida = true;
                tabuleiro.resultado = $"Jogador ({tabuleiro.marcadores[posicao.linha, posicao.coluna]}) foi o vencedor.";
            }


        }

        //verifica a quantidade maxima de jogadas, limitando em 6 jogadas.
        public static void verificarQntMaximaDeJogadas(Tabuleiro tabuleiro)
        {
            //caso menos que 9 jogadas adiciona +1 no contador de jogadas
            if (tabuleiro.qntJogadas < 9)
            {
                tabuleiro.qntJogadas++;
            }
            //caso a qntJogadas seja maior que 9 então finaliza o jogo.
            else
            {
                tabuleiro.fimDaPartida = true;
            }
        }
    }
}
