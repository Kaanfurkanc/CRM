using Core.DTOs;
using Core.Entities;
using Core.GenericRepository;
using Core.LoginManagerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata.Ecma335;

namespace Service.LoginManager
{
    public class LoginManager : ILoginManager
    {
        private readonly JwtSettings _jwtSettings;
        public LoginManager(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public Tokens CreateToken(UserResponseDTO userResponseDTO)
        {
            if (_jwtSettings.Key == null) throw new Exception("The Key property in Jwt settings  can not be null !");

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var claimArray = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userResponseDTO.Username),
                new Claim(ClaimTypes.Role, userResponseDTO.Role),
                new Claim(ClaimTypes.Email, userResponseDTO.Email!),
                new Claim(ClaimTypes.Name, userResponseDTO.Name!),
            };

            var token = new JwtSecurityToken(_jwtSettings.Issuer,
                _jwtSettings.Audience,
                claimArray,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials
                );

            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }

        public bool Verification(User user, LoginDTO loginDTO)
        {
            if (user.Password.Equals(loginDTO.Password))
                return true;
            return false;
        }
    }
}
