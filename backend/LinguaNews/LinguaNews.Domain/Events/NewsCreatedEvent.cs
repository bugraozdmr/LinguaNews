using LinguaNews.Domain.Abstractions;
using LinguaNews.Domain.Models;

namespace LinguaNews.Domain.Events;

public record NewsCreatedEvent(News News) : IDomainEvent;