namespace LinguaNews.Application.Exceptions;

public class EntityNotFoundException<T> : Exception
{
    public EntityNotFoundException(object id, T entity) 
        : base($"{typeof(T).Name} with ID {id} was not found.")
    {
    }
}