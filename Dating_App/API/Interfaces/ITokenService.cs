using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace Dating_App.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}