﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Domain.Entities
{
    public class UserRole:BaseEntity
    {
        public string Name { get; set; }
        
        //User
        public ICollection<User> Users { get; set; }
    }
}
