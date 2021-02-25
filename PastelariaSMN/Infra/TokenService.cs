using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PastelariaSMN.Models;

namespace PastelariaSMN.Infra
{
    public static class TokenService
    {
        public static string GenerateToken(UsuarioLogin usuario)
        {
            string role;
            if (usuario.EGestor == true)
            {
                role = "gestor";
                usuario.EGestor = true;
            }
            else
            {
                role = "subordinado";
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("IdUsuario", usuario.IdUsuario.ToString()),
                    new Claim("EGestor", usuario.EGestor.ToString()),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}