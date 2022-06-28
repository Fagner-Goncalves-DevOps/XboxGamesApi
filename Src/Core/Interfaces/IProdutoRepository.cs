using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Produto>> GetProductsAsync();
        Task<IReadOnlyList<ProdutoGenero>> GetProductBrandsAsync(); 

        Task<IReadOnlyList<ProdutoTipo>> GetProductTypesAsync();


        // BRAND - MARCA = ACÃO, RPG, ACÃO/AVENTURA, TERROR, TIRO, MMORPG, SIMULAÇÃO ..
        // TYPE -  TYPO  - ONLINE, GRATIS, POPULARES,LANÇAMENTO    ETC..

    }
}
