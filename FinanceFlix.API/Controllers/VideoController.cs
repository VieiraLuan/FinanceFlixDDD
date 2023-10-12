using FinanceFlix.API.Entities;
using FinanceFlix.Application.Interfaces;
using FinanceFlix.Application.ViewModels;
using FinanceFlix.Application.ViewModels.Video.Request;
using FinanceFlix.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceFlix.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {

        private readonly IVideoApplicationService _videoService;

        public VideoController(IVideoApplicationService videoService)
        {
            _videoService = videoService;
        }

        //Lista todos os videos existentes  
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var videos = await _videoService.GetAll();

                return Ok(videos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        //Lista um video pelo id 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                if (_videoService.GetById == null)
                {
                    return NotFound();
                }
                else
                {
                    var video = await _videoService.GetById(id);
                    return Ok(video);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        //Adiciona um novo video e relaciona a um curso
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddVideoRequestViewModel video)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (await _videoService.Add(video) == false)
                {
                    return BadRequest();
                }
                else
                {
                    return CreatedAtAction(nameof(GetById), new { id = video.Nome }, video);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); throw;
            }
        }

        //Relaciona um video a uma coleção de cursos
        [HttpPost]
        [Route("AddVideoToCurso")]
        public async Task<IActionResult> AddVideoToCurso([FromBody] AddVideoToCursoRequestViewModel video)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (await _videoService.AddVideoCurso(video) == false)
                {
                    return BadRequest();
                }
                else
                {
                    return CreatedAtAction(nameof(GetById), new { id = video.VideoId }, video);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); throw;
            }
        }

        //Atualiza um video
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EditVideoRequestViewModel video)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (await _videoService.Update(video) == false)
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

        //Deleta um video
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id.Equals(Guid.Empty))
                {
                    return BadRequest();
                }

                if (await _videoService.Delete(id) == true)
                {
                    return NoContent();
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

        //Assiste um video especifico
        [HttpGet("WatchVideo/{id}")]
        public async Task<IActionResult> WatchVideoUrl(Guid id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }

                var video = await _videoService.WatchVideoUrl(id);

                if (video == null)
                {
                    return NotFound();
                }

                return Ok(video);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        //Lista todos os videos de um curso especifico
        [HttpGet("GetAllVideosByCurso/{id}")]
        public async Task<IActionResult> GetAllVideosByCurso(Guid id)
        {
            try
            {
                if (id.Equals(Guid.Empty))
                {
                    return BadRequest();
                }

                var videos = await _videoService.GetAllVideosByCurso(id);

                if (videos == null)
                {
                    return NotFound();
                }

                return Ok(videos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


    }
}
