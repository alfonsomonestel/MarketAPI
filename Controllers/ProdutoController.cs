using MarketAPI.Data;
using MarketAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace MarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Produto
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoria">Indicar o código da categoria a ser filtrado</param>
        /// <param name="descricao">Realizar busca por palavra</param>
        /// <param name="situacao">Situação do produto (todos, ativo ou inativo)</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> GetProduto(long? categoria = null, string? descricao = null, bool? situacao = null)
        {
            try
            {
                if (_context.Produto == null)
                    return NotFound();


                var retorno = await _context.Produto.Where(c => (categoria != null ? c.CategoriaId.Equals(categoria) : !c.CategoriaId.Equals(null)) &&
                                                          (!string.IsNullOrEmpty(descricao) ? c.Descricao.ToLower().Contains(descricao.ToLower()) : !c.Descricao.Equals(null)) &&
                                                          (situacao != null ? c.Situacao.Equals(situacao) : !c.Situacao.Equals(situacao))).ToListAsync();


                return retorno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(this.Url + " - Erro: " + ex.Message);
                return Problem("Erro ao realizar busca, verifique os parâmetros informados.");
            }
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> GetProdutoModel(decimal id)
        {
            try
            {
                if (_context.Produto == null)
                {
                    return NotFound();
                }
                var produtoModel = await _context.Produto.FindAsync(id);

                if (produtoModel == null)
                {
                    return NotFound();
                }

                return produtoModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(this.Url + " - Erro: " + ex.Message);
                return Problem("Erro ao realizar busca, verifique os parâmetros informados.");
            }
        }

        // PUT: api/Produto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutoModel(decimal id, ProdutoModel produtoModel)
        {
            try
            {
                if (id != produtoModel.Id)
                {
                    return BadRequest();
                }

                _context.Entry(produtoModel).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoModelExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(this.Url + " - Erro: " + ex.Message);
                return Problem("Erro ao realizar busca, verifique os parâmetros informados.");
            }
        }

        // POST: api/Produto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> PostProdutoModel(ProdutoModel produtoModel)
        {
            try
            {
                if (_context.Produto == null)
                {
                    return Problem("Entity set 'AppDbContext.Produto'  is null.");
                }
                _context.Produto.Add(produtoModel);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (ProdutoModelExists(produtoModel.Id))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

                return CreatedAtAction("GetProdutoModel", new { id = produtoModel.Id }, produtoModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(this.Url + " - Erro: " + ex.Message);
                return Problem("Erro ao realizar busca, verifique os parâmetros informados.");
            }
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutoModel(decimal id)
        {
            try
            {
                if (_context.Produto == null)
                {
                    return NotFound();
                }
                var produtoModel = await _context.Produto.FindAsync(id);
                if (produtoModel == null)
                {
                    return NotFound();
                }

                _context.Produto.Remove(produtoModel);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(this.Url + " - Erro: " + ex.Message);
                return Problem("Erro ao realizar busca, verifique os parâmetros informados.");
            }
        }

        private bool ProdutoModelExists(decimal id)
        {
            return (_context.Produto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
