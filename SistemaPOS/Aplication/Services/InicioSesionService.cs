using Microsoft.IdentityModel.Tokens;
using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemaPOS.Aplication.Services
{
    public class InicioSesionService
    {
        private readonly InicioSesionRepository _inicioSesionRepository;
        private readonly IConfiguration _config;

        public InicioSesionService(
            InicioSesionRepository inicioSesionRepository,
            IConfiguration config)
        {
            _inicioSesionRepository = inicioSesionRepository;
            _config = config;
        }

        public async Task<UsuarioSesionDto> Ingresar(string usuario, string password)
        {
            var resultado = await _inicioSesionRepository.Ingresar(usuario, password);
            if(resultado != 0)
            {
                string token = GenerateToken(resultado);
                return new UsuarioSesionDto { token= token };
            }
            throw new Exception("No se encontro el usuario");
        }

        private string GenerateToken(int id)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("JwtToken:SecretKey"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
