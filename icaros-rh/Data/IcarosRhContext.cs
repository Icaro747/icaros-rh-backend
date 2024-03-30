using icaros_rh.Configuration;
using icaros_rh.Entities;
using Microsoft.EntityFrameworkCore;

namespace icaros_rh.Data;

/// <summary>
/// Representa o contexto do banco de dados para a aplicação Icaros RH.
/// </summary>
public class IcarosRhContext : DbContext
{
	/// <summary>
	/// Inicializa uma nova instância do contexto IcarosRh.
	/// </summary>
	/// <param name="opts">As opções de configuração do contexto.</param>
	public IcarosRhContext(DbContextOptions<IcarosRhContext> opts) : base(opts)
	{

	}

	/// <summary>
	/// Configuração do modelo de entidades durante a criação do contexto.
	/// </summary>
	/// <param name="modelBuilder">O construtor do modelo.</param>
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// Aplica as configurações para as entidades.
		modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
	}

	// Conjuntos de entidades DbSet

	public DbSet<Usuario> Usuario { get; set; }
}
