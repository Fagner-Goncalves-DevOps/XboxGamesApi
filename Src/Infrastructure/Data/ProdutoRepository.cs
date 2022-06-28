using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly SqlDbContext _context;

        public ProdutoRepository(SqlDbContext context) 
        {
            _context = context;
        }



        public async Task<IReadOnlyList<ProdutoGenero>> GetProductBrandsAsync()
        {
            return await _context.ProdutoGenero.ToArrayAsync();
        }
        public async Task<Produto> GetProductByIdAsync(int id)
        {
            return await _context.Produto.Include(p => p.ProdutoGenero)
                                         .Include(p => p.ProdutoTipo)
                                         .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IReadOnlyList<Produto>> GetProductsAsync()
        {
            return await _context.Produto.Include(p => p.ProdutoGenero)
                                         .Include(p => p.ProdutoTipo)
                                         .ToListAsync();
        }
        public async Task<IReadOnlyList<ProdutoTipo>> GetProductTypesAsync()
        {
            return await _context.ProdutoTipo.ToListAsync();
        }
    }
}
