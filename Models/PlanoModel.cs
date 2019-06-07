using Microsoft.Extensions.Primitives;

namespace PontoDigital.Models
{
    public class PlanoModel : ProdutoModel
    {
        public PlanoModel()
        {
        }

        public PlanoModel(StringValues Nome, double Preco){
            this.Nome = Nome;
            this.Preco = Preco;
        }
    }
}