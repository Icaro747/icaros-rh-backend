using AutoMapper;
using icaros_rh.Authentication;
using icaros_rh.Controllers.MainController;
using icaros_rh.Data;
using icaros_rh.DTOs.Authentication;
using icaros_rh.DTOs.Usuario;
using icaros_rh.Entities;
using Microsoft.AspNetCore.Mvc;

namespace icaros_rh.Controllers;


[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerIcarosRh
{
	private readonly TokenService _tokenService; // Injetar o serviço de geração de token

	/// <summary>
	/// Inicializa uma nova instância do controlador AuthenticationController.
	/// </summary>
	/// <param name="context">O contexto do banco de dados.</param>
	/// <param name="mapper">O mapeador AutoMapper.</param>
	/// <param name="logger">O logger.</param>
	public AuthenticationController(IcarosRhContext context, IMapper mapper, TokenService tokenService) : base(context, mapper)
	{
		_tokenService = tokenService;
	}

	[HttpPost("login")]
	public IActionResult Login([FromBody] LoginDTO login)
	{
		try
		{
			var user = _context.Usuario
				.FirstOrDefault(u => u.Email == login.Email);

			if (user == null)
				return NotFound("Dados inválidos, tente novamente.");

			if (user.VerificarSenha(login.Senha))
			{
				var token = _tokenService.GenerateToken(user); // Gerar token JWT usando o TokenService

				return Ok(new { Token = token, user.Nome, user.Adm, user.Img });
			}
			else
			{
				return NotFound("Dados inválidos, tente novamente.");
			}
		}
		catch (Exception ex)
		{
			return BadRequest(@$"Erro no login, tente novamente: ${ex.Message}");
		}
	}

	[HttpPost]
	public IActionResult AddUser([FromBody] NovoUsuarioDto novoUsuario)
	{
		try
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState); // Retorna os erros de validação

			// Verificar se o e-mail já existe na base de dados
			var existingUser = _context.Usuario.FirstOrDefault(x => x.Email == novoUsuario.Email);
			if (existingUser != null)
				return BadRequest("O e-mail já está em uso.");

			// Criando o Usuario
			Usuario newUser = _mapper.Map<Usuario>(novoUsuario);
			newUser.DefinirSenha(newUser.Senha); // Definindo a senha para o usuário

			_context.Usuario.Add(newUser);
			_context.SaveChanges(); // Salvando para obter o ID do usuário recém-criado

			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(@$"Erro: ${ex.Message}");
		}
	}
}
