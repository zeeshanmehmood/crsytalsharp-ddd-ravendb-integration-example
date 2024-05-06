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
    public class DeleteCurrencyCommandHandler : CommandHandler<DeleteCurrencyCommand, DeleteCurrencyResponse>
    {
        private readonly IRavenDbContext _dbContext;

        public DeleteCurrencyCommandHandler(IRavenDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<CommandExecutionResult<DeleteCurrencyResponse>> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken = default)
        {
            if (request == null) return await Fail("Invalid command.");

            Currency existingCurrency = _dbContext.Session.Query<Currency>().SingleOrDefault(x =>
                x.GlobalUId == request.GlobalUId
                && x.EntityStatus == EntityStatus.Active);

            if (existingCurrency == null)
            {
                return await Fail("Currency not found.");
            }

            existingCurrency.Delete();
            await _dbContext.SaveChanges(cancellationToken).ConfigureAwait(false);

            DeleteCurrencyResponse response = new() { GlobalUId = existingCurrency.GlobalUId };

            return await Ok(response);
        }
    }
}
