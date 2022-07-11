using marcador;

namespace marcador
{
    //Marcador do tipo (O)
    //Herdando os atributos da classe Marcador
    class MarcadorO : Marcador
    {

        //Construtor com atribudo vindo de uma herança
        public MarcadorO() 
            : base(Cor.Branca)
        {
        }

        //Sobrescrevendo metodo e retornando o tipo do marcador
        public override string ToString()
        {
            return "O";
        }
    }
}
