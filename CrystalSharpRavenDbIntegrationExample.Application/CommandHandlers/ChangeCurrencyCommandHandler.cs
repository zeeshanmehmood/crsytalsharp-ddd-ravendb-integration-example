using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Application;
using CrystalSharp.Application.Handlers;
using CrystalSharp.Domain;
using CrystalSharp.RavenDb.Database;
using CrystalSharpRavenDbIntegrationExample.Application.Commands;
using CrystalSharpRavenDbIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate;
using CrystalSharpRavenDbIntegrationExample.Application.Responses;

namespace CrystalSharpRavenDbIntegrationExample.Application.CommandHandlers
{
    public class ChangeCurrencyCommandHandler : CommandHandler<ChangeCurrencyCommand, CurrencyResponse>
    {
        private readonly IRavenDbContext _dbContext;

        public ChangeCurrencyCommandHandler(IRavenDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<CommandExecutionResult<CurrencyResponse>> Handle(ChangeCurrencyCommand request, CancellationToken cancellationToken = default)
        {
            if (request == null) return await Fail("Invalid command.");

            Currency existingCurrency = _dbContext.Session.Query<Currency>().SingleOrDefault(x =>
                x.GlobalUId == request.GlobalUId
                && x.EntityStatus == EntityStatus.Active);

            if (existingCurrency == null)
            {
                return await Fail("Currency not found.");
            }

            existingCurrency.ChangeName(request.Name);

            await _dbContext.SaveChanges(cancellationToken).ConfigureAwait(false);

            CurrencyResponse response = new() { GlobalUId = existingCurrency.GlobalUId, Name = existingCurrency.Name };

            return await Ok(response);
        }
    }
}
