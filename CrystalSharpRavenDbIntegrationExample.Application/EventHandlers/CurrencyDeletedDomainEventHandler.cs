using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Domain.Infrastructure;
using CrystalSharpRavenDbIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate.Events;

namespace CrystalSharpRavenDbIntegrationExample.Application.EventHandlers
{
    public class CurrencyDeletedDomainEventHandler : ISynchronousDomainEventHandler<CurrencyDeletedDomainEvent>
    {
        public async Task Handle(CurrencyDeletedDomainEvent notification, CancellationToken cancellationToken = default)
        {
            //
        }
    }
}
