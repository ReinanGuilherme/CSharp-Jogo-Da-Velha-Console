namespace marcador
{
    class PosicaoMarcador
    {
        public int linha { get; set; }
        public int coluna { get; set; }

        //define a linha e a coluna que o marcador vai ocupar
        public PosicaoMarcador(int linha, char colunaChar)
        {
            this.linha = linha;
            //convertendo a coluna do tipo char para int antes de atribuir o valor
            this.coluna = colunaChar - 'a';
        }
    }
}
