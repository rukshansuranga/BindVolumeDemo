using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace DockerVolumeDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private readonly ILogger<FileController> _logger;

    public FileController(ILogger<FileController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        string path = Path.Combine("files");

        var files = from file in Directory.EnumerateFiles(path) select file;

        List<string> contents = new List<string>();

        foreach(var file in files)
        {
            string text = System.IO.File.ReadAllText(file, Encoding.UTF8);
            contents.Add(text);
        }

        
        return Ok(contents);
    }

        [HttpGet]
        [Route("test")]
    public IActionResult Test()
    {
        return Ok("test");
    }
}
