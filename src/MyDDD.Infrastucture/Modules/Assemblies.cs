using MyDDD.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyDDD.Infrastucture.Modules
{
  internal static class Assemblies
  {
    public static readonly Assembly Application = typeof(CommandBase).Assembly;
  }
}
