using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Application;
using CrystalSharp.Application.Handlers;
using CrystalSharp.RavenDb.Database;
using CrystalSharpRavenDbIntegrationExample.Application.Commands;
using CrystalSharpRavenDbIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate;
using CrystalSharpRavenDbIntegrationExample.Application.Responses;

namespace CrystalSharpRavenDbIntegrationExample.Application.CommandHandlers
{
    public class CreateCurrencyCommandHandler : CommandHandler<CreateCurrencyCommand, CurrencyResponse>
    {
        private readonly IRavenDbContext _dbContext;

        public CreateCurrencyCommandHandler(IRavenDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<CommandExecutionResult<CurrencyResponse>> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken = default)
        {
            if (request == null) return await Fail("Invalid command.");

            Currency currency = Currency.Create(request.Name);

            _dbContext.Session.Store(currency);
            await _dbContext.SaveChanges(cancellationToken).ConfigureAwait(false);

            CurrencyResponse response = new() { GlobalUId = currency.GlobalUId, Name = currency.Name };

            return await Ok(response);
        }
    }
}
