using AutoMapper;
using icaros_rh.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace icaros_rh.Controllers.MainController
{
	/// <summary>
	/// Controlador base para a Icaros RH.
	/// </summary>
	public class ControllerIcarosRh : ControllerBase
	{
		/// <summary>
		/// O contexto do banco de dados para a Icaros RH.
		/// </summary>
		protected readonly IcarosRhContext _context;


		/// <summary>
		/// O mapeador AutoMapper para a Icaros RH.
		/// </summary>
		protected readonly IMapper _mapper;

		/// <summary>
		/// Inicializa uma nova instância do controlador base.
		/// </summary>
		/// <param name="context">O contexto do banco de dados.</param>
		/// <param name="mapper">O mapeador AutoMapper.</param>
		public ControllerIcarosRh(IcarosRhContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		/// <summary>
		/// Valida se o usuário é um administrador.
		/// </summary>
		/// <returns>True se o usuário for um administrador, False caso contrário.</returns>
		protected bool ValidaAdm()
		{
			try
			{
				if (User.FindFirstValue("Adm") == "True")
				{
					Guid userId;
					if (!Guid.TryParse(User.FindFirstValue("UserId"), out userId))
					{
						return false;
					}
					else
					{
						var use = _context.Usuario.Find(userId);
						if (use == null) return false;
						return use.Adm;
					}
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
