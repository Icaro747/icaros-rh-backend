using icaros_rh.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace icaros_rh.Configuration
{
	public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedNever();
			builder.Property(x => x.Nome).HasMaxLength(150).IsRequired();
			builder.Property(x => x.Email).HasMaxLength(150).IsRequired();
			builder.Property(x => x.Senha).IsRequired();
			builder.Property(x => x.CodigoRecuperacao).IsRequired(false);
			builder.Property(x => x.Adm).HasDefaultValue(false).IsRequired();
			builder.Property(x => x.IsDesativado).HasDefaultValue(false).IsRequired();
			builder.Property(x => x.Img).IsRequired(false);
			builder.Property(x => x.CriadoEm).IsRequired();
			builder.Property(x => x.ModificadoEm);
		}
	}
}
