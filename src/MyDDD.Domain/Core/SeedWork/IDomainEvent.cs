using MediatR;
using System;

namespace MyDDD.Domain.Core.SeedWork
{
  public interface IDomainEvent : INotification
    {
      DateTime OccurredOn { get; }
    }

}
