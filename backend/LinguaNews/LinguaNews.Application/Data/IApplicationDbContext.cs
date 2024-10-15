using LinguaNews.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LinguaNews.Application.Data;

public interface IApplicationDbContext
{
    DbSet<News> News { get; }
    DbSet<Category> Categories { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}