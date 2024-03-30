namespace AkkadianAcademy.Models.MainClass;

/// <summary>
/// Define a interface para entidades do sistema.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Obtém o identificador único da entidade.
    /// </summary>
    Guid Id { get; }

    /// <summary>
    /// Obtém ou define a data de criação da entidade.
    /// </summary>
    DateTime CriadoEm { get; set; }

    /// <summary>
    /// Obtém ou define a data de modificação da entidade.
    /// </summary>
    DateTime? ModificadoEm { get; set; }
}