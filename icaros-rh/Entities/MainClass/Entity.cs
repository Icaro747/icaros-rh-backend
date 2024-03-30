namespace AkkadianAcademy.Models.MainClass;

/// <summary>
/// Representa uma entidade base comum para todas as classes principais do sistema.
/// </summary>
public abstract class Entity : IEntity
{
    /// <summary>
    /// Obtém ou define o identificador único da entidade.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Obtém ou define a data de criação da entidade.
    /// </summary>
    public DateTime CriadoEm { get; set; }

    /// <summary>
    /// Obtém ou define a data de modificação da entidade.
    /// </summary>
    public DateTime? ModificadoEm { get; set; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Entity"/>.
    /// </summary>
    public Entity()
    {
        Id = Guid.NewGuid();
        CriadoEm = DateTime.UtcNow;
    }

    /// <summary>
    /// Atualiza a data de modificação da entidade para o momento atual.
    /// </summary>
    public void AddUpdateDate()
    {
        ModificadoEm = DateTime.UtcNow;
    }
}