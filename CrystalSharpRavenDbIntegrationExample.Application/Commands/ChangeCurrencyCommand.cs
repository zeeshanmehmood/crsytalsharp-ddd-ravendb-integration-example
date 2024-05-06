using System;
using CrystalSharp.Application;
using CrystalSharpRavenDbIntegrationExample.Application.Responses;

namespace CrystalSharpRavenDbIntegrationExample.Application.Commands
{
    public class ChangeCurrencyCommand : ICommand<CommandExecutionResult<CurrencyResponse>>
    {
        public Guid GlobalUId { get; set; }
        public string Name { get; set; }
    }
}
