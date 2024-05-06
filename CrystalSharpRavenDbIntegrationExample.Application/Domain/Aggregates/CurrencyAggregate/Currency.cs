using System;
using CrystalSharp.Domain;
using CrystalSharpRavenDbIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate.Events;

namespace CrystalSharpRavenDbIntegrationExample.Application.Domain.Aggregates.CurrencyAggregate
{
    public class Currency : AggregateRoot<string>
    {
        public string Name { get; private set; }

        private static void ValidateCurrency(Currency currency)
        {
            if (string.IsNullOrEmpty(currency.Name))
            {
                currency.ThrowDomainException("Currency name is required.");
            }
        }

        public static Currency Create(string name)
        {
            Currency currency = new() { Name = name };

            ValidateCurrency(currency);

            currency.Raise(new CurrencyCreatedDomainEvent(currency.GlobalUId, currency.Name));

            return currency;
        }

        public void ChangeName(string name)
        {
            Name = name;

            Raise(new CurrencyNameChangedDomainEvent(GlobalUId, Name));
        }

        public override void Delete()
        {
            base.Delete();
            Raise(new CurrencyDeletedDomainEvent(GlobalUId, Name));
        }

        private void Apply(CurrencyCreatedDomainEvent @event)
        {
            Name = @event.Name;
        }

        private void Apply(CurrencyNameChangedDomainEvent @event)
        {
            Name = @event.Name;
        }

        private void Apply(CurrencyDeletedDomainEvent @event)
        {
            Name = @event.Name;
        }
    }
}
