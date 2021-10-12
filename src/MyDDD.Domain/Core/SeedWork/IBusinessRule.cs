

namespace MyDDD.Domain.Core.SeedWork
{
  public interface IBusinessRule
  {
    bool IsBroken();

    string Message { get; }
  }
}
