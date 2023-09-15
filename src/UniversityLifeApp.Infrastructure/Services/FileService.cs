using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLifeApp.Application.Interfaces;

namespace EEWF.Infrastructure.Services
{
    public class FileService : IFileService
    {
        public async Task<bool> DeleteImage(string rootPath, string folder, string fileName)
        {
            string path = Path.Combine(rootPath, folder, fileName);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return true;
            }
            return false;
        }

        public async Task<string> SaveImage(string rootPath, string folder, IFormFile file)
        {
            string filename = file.FileName;
            filename = filename.Length <= 64 ? filename : (filename.Substring(filename.Length - 64, 64));
            filename = Guid.NewGuid().ToString() + filename;

            string path = Path.Combine(rootPath, folder, filename);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return filename;
        }
    }
}
