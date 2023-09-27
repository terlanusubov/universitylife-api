using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Upload;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class UploadService : IUploadService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IFileProvider _fileProvider;
        public UploadService(IWebHostEnvironment env, IFileProvider provider)
        {
            _env = env;
            _fileProvider = provider;
        }
        public async Task<ApiResult<UploadResponse>> Upload(UploadRequest request)
        {
            string filename = request.ImageName;
            //filename = filename.Length <= 64 ? filename : (filename.Substring(filename.Length - 64, 64));
            //filename = Guid.NewGuid().ToString() + filename;

            string path = Path.Combine(_env.WebRootPath, request.Folder, filename);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                request.ImageFile.CopyTo(stream);
            }

            UploadResponse response = new UploadResponse
            {
                FileName = filename,
            };


            return ApiResult<UploadResponse>.OK(response);
        }
    }
}
