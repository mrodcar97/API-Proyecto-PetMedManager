using Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IJwtService
    {
        string GenerateToken(Person person);
    }

    public class JwtService : IJwtService
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _secretKey;

        public JwtService(string issuer, string audience, string secretKey)
        {
            _issuer = issuer;
            _audience = audience;
            _secretKey = secretKey;
        }

        public string GenerateToken(Person person) { 
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, person.NationalId),
                new Claim(ClaimTypes.Role, person.Rol),
                new Claim(ClaimTypes.SerialNumber, person.ClinicId.ToString()),
                // Puedes agregar más claims según sea necesario
            };

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Tiempo de expiración del token
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}