using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLifeApp.Domain.Entities;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IJWTService
    {
        public string GenerateJwtToken(User user);
        public string ValidateJwtToken(string token);
    }
}
