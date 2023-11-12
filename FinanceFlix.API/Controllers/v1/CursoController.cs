using FinanceFlix.Application.Interfaces;
using FinanceFlix.Application.ViewModels.Curso.Request;
using FinanceFlix.Application.ViewModels.CursoCategoria.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceFlix.API.Controllers.v1
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        [Route("AddCursoCategoriaExists")]
        public async Task<IActionResult> Add([FromBody] AddCursoRequestViewModel curso)
        {
            try
            {
                if (!ModelState.IsValid)
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
        [Authorize]
        [Route("AddCursoCategoriaNoExists")]
        public async Task<IActionResult> AddCursoCategoria([FromBody] AddCursoCategoriaRequestViewModel curso)
        {
            try
            {
                if (curso == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (await _cursoService.AddCursoCategoria(curso) != false)
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
        [Authorize]
        public async Task<IActionResult> Update([FromBody] EditCursoRequestViewModel curso)
        {
            try
            {
                if (!ModelState.IsValid)
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
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id.Equals(Guid.Empty))
                {
                    return BadRequest();
                }

                if (await _cursoService.Delete(id) == false)
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



        [HttpGet]
        [Route("GetAllByCategoriaCurso/{id}")]
        [Authorize]
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
