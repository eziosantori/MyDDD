using MyDDD.Domain.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDDD.Domain.Core
{
  public interface IDomainEventCollector
  {

    /// <summary>
    /// Domain events occurred.
    /// </summary>
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    /// <summary>
    /// Add domain event.
    /// </summary>
    /// <param name="domainEvent"></param>
    void AddDomainEvent(IDomainEvent domainEvent);

    /// <summary>
    /// Clear domain events.
    /// </summary>
    void ClearDomainEvents();
  }
}
