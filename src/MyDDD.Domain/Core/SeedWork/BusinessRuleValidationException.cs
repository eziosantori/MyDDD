using System;

namespace MyDDD.Domain.Core.SeedWork
{
  public class BusinessRuleValidationException : ApplicationException
  {
    public IBusinessRule BrokenRule { get; }

    public string Details { get; }

    public BusinessRuleValidationException(IBusinessRule brokenRule) : base(brokenRule.Message)
    {
      BrokenRule = brokenRule;
      this.Details = brokenRule.Message;
    }

    public override string ToString()
    {
      return $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
    }
  }
}
