using FinanceFlix.API.Entities;
using FinanceFlix.Application.Interfaces;
using FinanceFlix.Application.ViewModels;
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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
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

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] VideoViewModel video)
        {
            try
            {
                if (video == null)
                {
                    return BadRequest();
                }

                if (await _videoService.Add(video) == false)
                {
                    return BadRequest();
                }
                else
                {
                    return CreatedAtAction(nameof(GetById), new { id = video.Id }, video);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); throw;
            }
        }


        [HttpPost]
        [Route("AddCursoVideo")]
        public async Task<IActionResult> AddCursoVideo([FromBody] CursoVideoViewModel video)
        {
            try
            {
                if (video == null)
                {
                    return BadRequest();
                }

                if (await _videoService.AddVideoCurso(video.VideoId, video.CursoId) == false)
                {
                    return BadRequest();
                }
                else
                {
                    return CreatedAtAction(nameof(GetById), new { id = video.CursoVideoId }, video);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VideoViewModel video)
        {
            try
            {
                if (video == null)
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

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var categoria = await _videoService.GetById(id);

                if (categoria == null)
                {
                    return NotFound();
                }

                if (await _videoService.Delete(categoria) == false)
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

        [HttpGet("WatchVideo/{id}")]
        public async Task<IActionResult> WatchVideoUrl(int id)
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

        [HttpGet("GetAllVideosByCurso/{id}")]
        public async Task<IActionResult> GetAllVideosByCurso(int id)
        {
            try
            {
                if (id == null)
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
