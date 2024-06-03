﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.User
{
    public class UserDtoForUpdate : UserDto
    {
        public HashSet<string> UserRoles { get; set; } = new HashSet<string>();
    }
}
