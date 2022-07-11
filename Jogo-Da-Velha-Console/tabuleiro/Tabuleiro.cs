using System;
using marcador;
using enums;
using exceptions;

namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; private set; }
        public int colunas { get; private set; }
        public bool turno { get; private set; }
        public int qntJogadas { get; set; }
        public bool fimDaPartida { get; set; }
        public string resultado { get; set; }
        public Marcador[,] marcadores { get; set; }

        // A base do jogo da velha contem 3 linhas por 3 colunas
        public Tabuleiro()
        {
            linhas = 3;
            colunas = 3;
            turno = false;
            qntJogadas = 1;
            fimDaPartida = false;
            resultado = "Partida Empatada";
            marcadores = new Marcador[linhas, colunas];
        }

        //adiciona marcador no tabuleiro do jogo.
        //recebe um marcador e sua posição
        public void addMarcor(PosicaoMarcador posicao)
        {
            //alterando o tipo de marcador conforme o status do turno
            //turno == true (MarcadorO)
            if (turno)
            {
                //atribuindo o marcador ao seu lugar na matriz
                marcadores[posicao.linha, posicao.coluna] = new MarcadorO();
                //atribuindo a posicao do marcador
                marcadores[posicao.linha, posicao.coluna].posicao = posicao;
            }
            //turno == false (MarcadorX)
            else
            {
                //atribuindo o marcador ao seu lugar na matriz
                marcadores[posicao.linha, posicao.coluna] = new MarcadorX();
                //atribuindo a posicao do marcador
                marcadores[posicao.linha, posicao.coluna].posicao = posicao;
            }

            mudarTurno();
        }

        // converte o que foi digitado pelo usuario para um formato que seja possivel utilizar nos metodos.
        public PosicaoMarcador lerPosicaoTabuleiro()
        {
            string jogada = " ";
            char coluna = ' ';
            int linha = 0;

            do
            {                
                try
                {
                    Console.Write("Digite coluna/linha da jogada: ");
                    jogada = Console.ReadLine();

                    //verifica se o usuario não está passando nenhum valor
                    if (jogada == "")
                    {
                        //alterando o valor da entrada para que não passe no while.
                        jogada = "x9";

                        throw new MarcadorException("Coluna/Linha não foram inseridas.");
                    }

                    //convertendo o resultado da digitação do usuario
                    //coluna - pegando o primeiro caractere da digitação e convertendo para string com a expressão ( + "" ) e utilizando o metodo ToLower() para deixar o caractere com letra em minusculo.
                    coluna = (jogada[0] + " ").ToLower()[0];
                    linha = int.Parse(jogada[1] + "");                    

                    //verifica se a quantidade de linhas maior que 2, pois o limite de linhas são 2, contagem de 0 a 2
                    //verifica se a entrada possui + de 2 caracteres.
                    if (int.Parse(jogada[1] + "") > 2 || jogada.Length > 2)
                    {
                        //alterando o valor da entrada para que não passe no while.
                        jogada = "x9";

                        throw new MarcadorException("Os unicos valores permitidos para as COLUNAS são: (a,b ou c) e para LINHAS são: (0,1 ou 2).");
                    }

                    //testando se o valor digitado está de acordo com os padrões de entradas aceitos pelo jogo, caso seja possivel a conversão então o programa pode continuar.
                    Enum.Parse<ColunaLinha>($"{coluna}{linha}");


                    //verifica se existe algum marcador na posição selecionada.
                    //(coluna - 'a') faz a conversão de char para int
                    if (marcadores[linha, coluna - 'a'] != null)
                    {
                        //alterando o valor da entrada para que não passe no while.
                        jogada = "x9";

                        throw new MarcadorException("Posição já possui um marcador, inserir em uma posição vazia.");
                    }

                }
                catch (MarcadorException e)
                {
                    Console.WriteLine();
                    Console.WriteLine("Error no Metodo: lerPosicaoTabuleiro");
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine();
                    Console.WriteLine("Error no Metodo: lerPosicaoTabuleiro");
                    Console.WriteLine("Os unicos valores permitidos para as COLUNAS são: (a,b ou c) e para LINHAS são: (0,1 ou 2).");
                    Console.WriteLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.WriteLine("Error no Metodo: lerPosicaoTabuleiro");
                    Console.WriteLine("A digitação deve seguir o padrão coluna/linha.");
                    Console.WriteLine();
                }

            } while (jogada[1] > 2 && jogada[0] != 'a' && jogada[0] != 'b' && jogada[0] != 'c');

            //retorna a posição do marcador no tabuleiro
            return new PosicaoMarcador(linha, coluna);
        }

        //altera turno de true para false e de false para true
        public void mudarTurno()
        {
            turno = turno ? false : true;
        }        
    }
}
