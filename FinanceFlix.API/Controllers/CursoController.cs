
using FinanceFlix.Application.Interfaces;
using FinanceFlix.Application.ViewModels.Curso.Request;
using Microsoft.AspNetCore.Mvc;

namespace FinanceFlix.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {

        private readonly ICursoApplicationService _cursoService;

        public CursoController(ICursoApplicationService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cursos = await _cursoService.GetAll();

                return Ok(cursos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var curso = await _cursoService.GetById(id);

                if (curso == null)
                {
                    return NotFound();
                }
                else
                {

                    return Ok(curso);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        [Route("AddCursoCategoriaExists")]
        public async Task<IActionResult> Add([FromBody] AddCursoRequestViewModel curso)
        {
            try
            {
                if (curso == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (await _cursoService.Add(curso) != false)
                {
                    return CreatedAtAction(nameof(GetById), new { id = curso.Nome }, curso);

                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); throw;
            }
        }


        [HttpPost]
        [Route("AddCursoCategoriaNoExists")]
        public async Task<IActionResult> AddCursoCategoria([FromBody] AddCursoCategoriaRequestViewModel curso)
        {
            try
            {
                if (curso == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (await _cursoService.AddCursoCategoria(curso) != false )
                {
                    return CreatedAtAction(nameof(GetById), new { id = curso.Nome }, curso);

                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EditCursoRequestViewModel curso)
        {
            try
            {
                if (curso == null)
                {
                    return BadRequest();
                }

                if (await _cursoService.Update(curso) == false)
                {
                    return BadRequest();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                /*     var curso = await _cursoService.GetById(id);

                 if (curso == null)
                 {
                     return NotFound();
                 }

                 if (await _cursoService.Delete(curso) == false)
                 {
                     return BadRequest();
                 }
                 else
                 {
                     return NoContent();
                 }*/

                return null;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); throw;
            }
        }



        [HttpGet]
        [Route("GetAllByCategoriaCurso/{id}")]
        public async Task<IActionResult> GetAllByCategoria(Guid id)
        {
            try
            {

                var cursos = await _cursoService.GetByCategoriaCurso(id);

                if (cursos == null)
                {
                    return NotFound();
                }
                
                return Ok(cursos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
