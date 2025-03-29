using CpDotnet.Interfaces;
using CpDotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace CpDotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrinquedosController : ControllerBase
    {
        private readonly IBrinquedoRepository _repository;

        public BrinquedosController(IBrinquedoRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna todos os brinquedos cadastrados.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brinquedos = await _repository.GetAllAsync();
            return Ok(brinquedos);
        }

        /// <summary>
        /// Retorna um brinquedo específico pelo ID.
        /// </summary>
        /// <param name="id">ID do brinquedo</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brinquedo = await _repository.GetByIdAsync(id);
            if (brinquedo == null)
                return NotFound(new { Mensagem = "Brinquedo não encontrado." });

            return Ok(brinquedo);
        }

        /// <summary>
        /// Cria um novo brinquedo.
        /// </summary>
        /// <param name="brinquedo">Objeto do tipo Brinquedo</param>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Brinquedo brinquedo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // O ID será gerado automaticamente pelo banco de dados (não é necessário fornecê-lo)
            await _repository.AddAsync(brinquedo);

            return CreatedAtAction(nameof(GetById), new { id = brinquedo.Id_brinquedo }, brinquedo);
        }

        /// <summary>
        /// Atualiza um brinquedo existente.
        /// </summary>
        /// <param name="id">ID do brinquedo</param>
        /// <param name="brinquedo">Objeto do tipo Brinquedo</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Brinquedo brinquedo)
        {
            if (!ModelState.IsValid || id != brinquedo.Id_brinquedo)
                return BadRequest(new { Mensagem = "Dados inválidos ou IDs não correspondem." });

            var existingBrinquedo = await _repository.GetByIdAsync(id);
            if (existingBrinquedo == null)
                return NotFound(new { Mensagem = "Brinquedo não encontrado." });

            await _repository.UpdateAsync(brinquedo);
            return NoContent();
        }

        /// <summary>
        /// Exclui um brinquedo pelo ID.
        /// </summary>
        /// <param name="id">ID do brinquedo</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingBrinquedo = await _repository.GetByIdAsync(id);
            if (existingBrinquedo == null)
                return NotFound(new { Mensagem = "Brinquedo não encontrado." });

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
