﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IJwtProvider
    {
        public string GenerateToken(BranchAccount account);
    }
}
