using Microsoft.AspNetCore.Mvc;
using Youxel.FileStorge.Application.Interfaces;
using Youxel.FileStorge.Application.Services;

namespace Youxel.FileStorge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile( IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is not selected");

           

            var result = await _fileService.UploadFileAsync(file);
            return Ok(new { fileId = result });
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadFile(Guid id)
        {
            var fileStream = await _fileService.DownloadFileAsync(id);
            if (fileStream == null) return NotFound();
            return File(fileStream, "application/octet-stream");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteFile(Guid id)
        {
            var result = await _fileService.DeleteFileAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
