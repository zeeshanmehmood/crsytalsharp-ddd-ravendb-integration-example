using System;
using Newtonsoft.Json;
using CrystalSharp.Domain.Infrastructure;

namespace CrystalSharpRavenDbIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate.Events
{
    public class CurrencyDeletedDomainEvent : DomainEvent
    {
        public string Name { get; set; }

        public CurrencyDeletedDomainEvent(Guid streamId, string name)
        {
            StreamId = streamId;
            Name = name;
        }

        [JsonConstructor]
        public CurrencyDeletedDomainEvent(Guid streamId,
            string name,
            int entityStatus,
            DateTime createdOn,
            DateTime? modifiedOn,
            long version)
        {
            StreamId = streamId;
            Name = name;
            EntityStatus = entityStatus;
            CreatedOn = createdOn;
            ModifiedOn = modifiedOn;
            Version = version;
        }
    }
}
