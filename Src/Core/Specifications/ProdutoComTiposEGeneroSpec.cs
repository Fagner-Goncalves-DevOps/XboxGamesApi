using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProdutoComTiposEGeneroSpec : BaseSpecification<Produto>
    {
        public ProdutoComTiposEGeneroSpec() 
        {
        }

        public ProdutoComTiposEGeneroSpec(int id) : base(x => x.Id == id) 
        {
            AddInclude(x => x.ProdutoTipo);
            AddInclude(x => x.ProdutoGenero);
        }
    }
}
