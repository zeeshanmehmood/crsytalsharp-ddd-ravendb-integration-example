using System;
using Newtonsoft.Json;
using CrystalSharp.Domain.Infrastructure;

namespace CrystalSharpRavenDbIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate.Events
{
    public class CurrencyNameChangedDomainEvent : DomainEvent
    {
        public string Name { get; set; }

        public CurrencyNameChangedDomainEvent(Guid streamId, string name)
        {
            StreamId = streamId;
            Name = name;
        }

        [JsonConstructor]
        public CurrencyNameChangedDomainEvent(Guid streamId,
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
