using AutoMapper;
using icaros_rh.DTOs.Usuario;
using icaros_rh.Entities;

namespace icaros_rh.Mapping.Profiles
{
	public class UsuarioProfiles : Profile
	{
		public UsuarioProfiles()
		{
			CreateMap<NovoUsuarioDto, Usuario>();
		}
	}
}
