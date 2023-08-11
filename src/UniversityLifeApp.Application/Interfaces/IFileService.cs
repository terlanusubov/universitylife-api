using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveImage(string rootPath, string folder, IFormFile file);
        Task<bool> DeleteImage(string rootPath, string folder, string fileName);
    }
}
