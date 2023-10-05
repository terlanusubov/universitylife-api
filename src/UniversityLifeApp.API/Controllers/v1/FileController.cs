using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json.Serialization;
using UniveristyLifeApp.Models.v1.Upload;

namespace UniversityLifeApp.API.Controllers.v1
{


    [ApiController]
    [Route("api/v{version:apiVersion}/file")]
    [ApiVersion("1.0")]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public FileController(IWebHostEnvironment env)
        {
            _env = env;
        }
        [HttpPost]
        public async Task<ActionResult<string>> UploadFile([FromForm]UploadRequest request)
        {
            foreach (var item in request.UploadDto)
            {
                string path = Path.Combine(_env.WebRootPath, request.Folder, item.FileName);

                using FileStream stream = new FileStream(path, FileMode.Create);
                item.File.CopyTo(stream);
            }
            
            //todo : save to database
            return request.Folder;
        }
    }
}
