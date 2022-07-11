namespace marcador
{
    //classe abstrata
    abstract class Marcador
    {
        public PosicaoMarcador posicao { get; set; }
        public Cor cor { get; set; }

        //construtor, posição inicia com valor null
        public Marcador( Cor cor)
        {
            this.cor = cor;
            this.posicao = null;
        }
    }
}
