using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XboxGamesApi.DTOs
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string PictureUrl { get; set; }
        public string ProdutoTipo { get; set; }
        public string ProdutoGenero { get; set; }


        //public int ProdutoTipoId { get; set; }
        //public int ProdutoGeneroId { get; set; }

    }
}
