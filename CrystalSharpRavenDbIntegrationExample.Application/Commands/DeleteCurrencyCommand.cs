using System;
using CrystalSharp.Application;
using CrystalSharpRavenDbIntegrationExample.Application.Responses;

namespace CrystalSharpRavenDbIntegrationExample.Application.Commands
{
    public class DeleteCurrencyCommand : ICommand<CommandExecutionResult<DeleteCurrencyResponse>>
    {
        public Guid GlobalUId { get; set; }
    }
}
