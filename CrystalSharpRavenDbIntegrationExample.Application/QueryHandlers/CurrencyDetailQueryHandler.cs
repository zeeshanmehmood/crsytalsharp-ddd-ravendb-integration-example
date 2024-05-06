using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Application;
using CrystalSharp.Application.Handlers;
using CrystalSharp.Domain;
using CrystalSharp.RavenDb.Database;
using CrystalSharpRavenDbIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate;
using CrystalSharpRavenDbIntegrationExample.Application.Queries;
using CrystalSharpRavenDbIntegrationExample.Application.ReadModels;

namespace CrystalSharpRavenDbIntegrationExample.Application.QueryHandlers
{
    public class CurrencyDetailQueryHandler : QueryHandler<CurrencyDetailQuery, CurrencyReadModel>
    {
        private readonly IRavenDbContext _dbContext;

        public CurrencyDetailQueryHandler(IRavenDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<QueryExecutionResult<CurrencyReadModel>> Handle(CurrencyDetailQuery request, CancellationToken cancellationToken = default)
        {
            if (request == null) return await Fail("Invalid query.");

            Currency currency = _dbContext.Session.Query<Currency>().SingleOrDefault(x =>
                x.GlobalUId == request.GlobalUId
                && x.EntityStatus == EntityStatus.Active);

            if (currency == null)
            {
                return await Fail("Currency not found.");
            }

            CurrencyReadModel readModel = new() { GlobalUId = currency.GlobalUId, Name = currency.Name };

            return await Ok(readModel);
        }
    }
}
