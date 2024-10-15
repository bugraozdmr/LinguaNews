using LinguaNews.Domain.Abstractions;
using LinguaNews.Domain.Models;

namespace LinguaNews.Domain.Events;

public record NewsUpdatedEvent(News News) : IDomainEvent;