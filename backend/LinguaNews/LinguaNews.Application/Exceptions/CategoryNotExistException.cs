namespace LinguaNews.Application.Exceptions;

public class CategoryNotExistException : Exception
{
    public CategoryNotExistException(int id) : base($"Category with id {id} does not exist")
    {
    }
}