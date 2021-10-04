using MediatR;
using System;

namespace MyDDD.Domain.Core
{
  public interface IDomainEvent : INotification
  {
    DateTime OccurredOn { get; }
  }
}
