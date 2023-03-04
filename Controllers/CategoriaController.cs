using MarketAPI.Data;
using MarketAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaModel>>> GetCategorias(string nome = "", bool? situacao = null)
        {

            try
            {
                if (_context.Categoria == null)
                    return NotFound();

                var retorno = await _context.Categoria.Where(c => (!string.IsNullOrEmpty(nome) ? c.Nome.Contains(nome) : !c.Nome.Equals("")) &&
                                                           (situacao != null ? c.Situacao.Equals(situacao) : !c.Situacao.Equals(situacao))).ToListAsync();

                return retorno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(this.Url + " - Erro: " + ex.Message);
                return Problem("Erro ao realizar busca, verifique os parâmetros informados.");
            }

        }

        // GET: api/Categoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaModel>> GetCategoriaModel(long id)
        {
            try
            {
                if (_context.Categoria == null)
                {
                    return NotFound();
                }
                var categoriaModel = await _context.Categoria.FindAsync(id);

                if (categoriaModel == null)
                {
                    return NotFound();
                }

                return categoriaModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(this.Url + " - Erro: " + ex.Message);
                return Problem("Erro ao realizar busca, verifique os parâmetros informados.");
            }
        }

        // PUT: api/Categoria/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaModel(decimal id, CategoriaModel categoriaModel)
        {
            try
            {
                if (id != categoriaModel.Id)
                {
                    return BadRequest();
                }

                _context.Entry(categoriaModel).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaModelExists(id))
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

        // POST: api/Categoria
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriaModel>> PostCategoriaModel(CategoriaModel categoriaModel)
        {
            try
            {
                if (_context.Categoria == null)
                {
                    return Problem("Entity set 'CategoriaContext.Categorias'  is null.");
                }

                if (CategoriaModelExists(categoriaModel.Id))
                    return Problem("Categoria já existe com este código. Sugestão de código " + (_context.Categoria.Max(c => c.Id) + 1));

                _context.Categoria.Add(categoriaModel);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCategoriaModel", new { id = categoriaModel.Id }, categoriaModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(this.Url + " - Erro: " + ex.Message);
                return Problem("Erro ao realizar busca, verifique os parâmetros informados.");
            }
        }

        // DELETE: api/Categoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaModel(decimal id)
        {
            try
            {
                if (_context.Categoria == null)
                {
                    return NotFound();
                }
                var categoriaModel = await _context.Categoria.FindAsync(id);
                if (categoriaModel == null)
                {
                    return NotFound();
                }

                _context.Categoria.Remove(categoriaModel);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(this.Url + " - Erro: " + ex.Message);
                return Problem("Erro ao realizar busca, verifique os parâmetros informados.");
            }
        }

        private bool CategoriaModelExists(decimal id)
        {
            return (_context.Categoria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
