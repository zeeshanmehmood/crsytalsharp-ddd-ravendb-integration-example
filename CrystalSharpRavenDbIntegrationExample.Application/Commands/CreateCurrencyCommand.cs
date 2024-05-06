using CrystalSharp.Application;
using CrystalSharpRavenDbIntegrationExample.Application.Responses;

namespace CrystalSharpRavenDbIntegrationExample.Application.Commands
{
    public class CreateCurrencyCommand : ICommand<CommandExecutionResult<CurrencyResponse>>
    {
        public string Name { get; set; }
    }
}
