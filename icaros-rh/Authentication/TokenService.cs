using icaros_rh.Configuration;
using icaros_rh.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace icaros_rh.Authentication
{
	/// <summary>
	/// Serviço responsável por gerar tokens de autenticação JWT.
	/// </summary>
	public class TokenService
	{
		private readonly JwtConfig _jwtConfig;

		/// <summary>
		/// Construtor da classe TokenService.
		/// </summary>
		/// <param name="jwtConfig">Configurações JWT injetadas por meio de IOptions.</param>
		public TokenService(IOptions<JwtConfig> jwtConfig)
		{
			_jwtConfig = jwtConfig.Value;
		}

		/// <summary>
		/// Gera um token JWT para o usuário fornecido.
		/// </summary>
		/// <param name="user">Usuário para o qual o token será gerado.</param>
		/// <returns>Token JWT gerado.</returns>
		public string GenerateToken(Usuario user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(Settings.Secret);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
				new Claim(ClaimTypes.Name, user.Nome), // Adiciona o nome do usuário como uma reivindicação
                    new Claim("UserId", user.Id.ToString()), // Adiciona o ID do usuário como uma reivindicação personalizada
                    new Claim("Adm", user.Adm.ToString()) // Adiciona o status de administrador do usuário como uma reivindicação personalizada
				}),
				Expires = DateTime.UtcNow.AddHours(24),
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(key), // Utiliza a chave secreta para assinar o token
					SecurityAlgorithms.HmacSha256Signature // Utiliza o algoritmo HMAC SHA256 para assinar o token
				),
				Issuer = _jwtConfig.ValidIssuer, // Define o emissor do token a partir das configurações JWT
				Audience = _jwtConfig.ValidAudience // Define a audiência do token a partir das configurações JWT
			};

			var token = tokenHandler.CreateToken(tokenDescriptor); // Cria o token JWT
			return tokenHandler.WriteToken(token); // Escreve o token JWT como uma string
		}
	}
}
