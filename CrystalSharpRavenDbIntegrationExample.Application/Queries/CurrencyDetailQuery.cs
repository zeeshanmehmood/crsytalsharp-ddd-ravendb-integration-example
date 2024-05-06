using System;
using CrystalSharp.Application;
using CrystalSharpRavenDbIntegrationExample.Application.ReadModels;

namespace CrystalSharpRavenDbIntegrationExample.Application.Queries
{
    public class CurrencyDetailQuery : IQuery<QueryExecutionResult<CurrencyReadModel>>
    {
        public Guid GlobalUId { get; set; }
    }
}
