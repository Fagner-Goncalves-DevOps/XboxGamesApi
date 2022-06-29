using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XboxGamesApi.DTOs;
using XboxGamesApi.Errors;

namespace XboxGamesApi.Controllers
{
    public class ProdutoController : ApiBaseController
    {
        private readonly IRepository<Produto> _produtoRepository;
        private readonly IRepository<ProdutoGenero> _ProdutoGeneroRepository;
        private readonly IRepository<ProdutoTipo> _ProdutoTipoRepository;
        private readonly IMapper _mapper;


        public ProdutoController(
                                IRepository<Produto> produtoRepository,
                                IRepository<ProdutoGenero> produtoGeneroRepository, 
                                IRepository<ProdutoTipo> produtoTipoRepository,
                                IMapper mapper
                                 ) 
        {
            _produtoRepository = produtoRepository;
            _ProdutoGeneroRepository = produtoGeneroRepository;
            _ProdutoTipoRepository = produtoTipoRepository;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDto>> PegarProduto(int id) 
        {
            var spec = new ProdutoComTiposEGeneroSpec(id);
            var produto = await _produtoRepository.GetEntityWithSpec(spec);

            if (produto == null) return NotFound(new APIResponse(404));
            return _mapper.Map<Produto, ProdutoDto>(produto);     //implementar e configurar o aoutmapper para testar 

                    
        }



        [HttpGet("Jogos-Gênero")]
        public async Task<ActionResult<IReadOnlyList<ProdutoGenero>>> PegarProdutosGenero() 
        {
            return Ok(await _ProdutoGeneroRepository.ListAllAsync());

        }
        [HttpGet("Jogos-Tipos")]
        public async Task<ActionResult<IReadOnlyList<ProdutoTipo>>> PegarProdutoTipos() 
        {
            return Ok(await _ProdutoTipoRepository.ListAllAsync());
        }
    }
}
