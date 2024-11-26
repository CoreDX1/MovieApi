namespace Infrastructure.Data.Repositories;

public static class EntityExtensions
{
    /// <summary>
    /// Verificar si la entidad es nula
    /// </summary>

    public static bool IsNull<T>(this T entity)
        where T : class
    {
        return entity == null;
    }
}
