namespace marcador
{
    //Marcador do tipo (X)
    //Herdando os atributos da classe Marcador
    class MarcadorX : Marcador
    {

        //Construtor com atribudo vindo de uma herança
        public MarcadorX() 
            : base(Cor.Preta)
        {

        }


        //Sobrescrevendo metodo e retornando o tipo do marcador
        public override string ToString()
        {
            return "X";
        }
    }
}
