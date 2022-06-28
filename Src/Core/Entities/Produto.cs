using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string PictureUrl { get; set; }
        public int ProdutoTipoId { get; set; }
        public int ProdutoGeneroId { get; set; }

        public ProdutoTipo ProdutoTipo { get; set; }
        public ProdutoGenero ProdutoGenero { get; set; }

    }
}
