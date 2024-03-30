using AkkadianAcademy.Models.MainClass;

namespace icaros_rh.Entities
{
	/// <summary>
	/// Representa um usuário na Icaros RH.
	/// </summary>
	public class Usuario : Entity
	{
		/// <summary>
		/// Obtém ou define o nome do usuário.
		/// </summary>
		public string Nome { get; set; }

		/// <summary>
		/// Obtém ou define o endereço de e-mail do usuário.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Obtém ou define a senha criptografada do usuário.
		/// </summary>
		public string Senha { get; set; }

		/// <summary>
		/// Obtém ou define o código de recuperação de senha (opcional).
		/// </summary>
		public int? CodigoRecuperacao { get; set; }

		/// <summary>
		/// Obtém ou define se o usuário possui privilégios de administrador.
		/// </summary>
		public bool Adm { get; set; }

		/// <summary>
		/// Obtém ou define o caminho da imagem do usuário.
		/// </summary>
		public string Img { get; set; }

		/// <summary>
		/// Obtém ou define o desativado do usuário.
		/// </summary>
		public bool IsDesativado { get; set; }

		/// <summary>
		/// Define a senha do usuário utilizando um hash seguro.
		/// </summary>
		/// <param name="senha">A senha a ser definida.</param>
		public void DefinirSenha(string senha)
		{
			Senha = BCrypt.Net.BCrypt.HashPassword(senha);
		}

		/// <summary>
		/// Verifica se a senha fornecida corresponde à senha do usuário.
		/// </summary>
		/// <param name="senha">A senha a ser verificada.</param>
		/// <returns>True se a senha estiver correta, False caso contrário.</returns>
		public bool VerificarSenha(string senha)
		{
			return BCrypt.Net.BCrypt.Verify(senha, Senha);
		}
	}
}
