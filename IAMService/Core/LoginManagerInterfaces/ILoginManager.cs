using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LoginManagerInterfaces
{
    public interface ILoginManager
    {
        Tokens CreateToken(UserResponseDTO userResponseDTO);
        bool Verification(User user, LoginDTO loginDTO);
    }
}
