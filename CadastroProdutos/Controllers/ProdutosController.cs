using CadastroProdutos.Data;
using CadastroProdutos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProdutos.Controllers
{
    [ApiController]
    [Route("api/v1/produtos")]
    public class ProdutosController : Controller
    {
        private DataContext _context;

        public ProdutosController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public Produto Create(Produto produto)
        {
            _context.produtos.Add(produto);
            _context.SaveChanges();

            return produto;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetAll()
        {
            var result =  _context.produtos.ToList();
            return result;
        }

        [HttpGet("{id:int}")]
        public Produto GetById(int id)
        {
            var result = _context.Find<Produto>(id);
            return result;
        }

        [HttpDelete("{id:int}")]
        public string Delete(int id)
        {
            var r = GetById(id);
            if (r == null) return "nenhum objeto encontrado";

            _context.Remove<Produto>(r);
            _context.SaveChanges();
            return "objeto excluido!";
        }

        [HttpPut]
        public async Task<ActionResult<Produto>> UpdateProduto(int id, [FromBody] Produto produto)
        {
            if (id != produto.ID) return BadRequest();

            _context.produtos.Update(produto);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
