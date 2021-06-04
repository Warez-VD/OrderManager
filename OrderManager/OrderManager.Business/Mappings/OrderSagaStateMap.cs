﻿using MassTransit.NHibernateIntegration;
using NHibernate.Cfg.MappingSchema;
using OrderManager.Business.Sagas;
using FluentNHibernate.Mapping;
using FluentNHibernate.Conventions;

namespace OrderManager.Business.Mappings
{
    public class OrderSagaStateMap : SagaClassMapping<OrderSagaState>
    {
        public OrderSagaStateMap()
        {
            Property(x => x.CurrentState, x => x.Length(64));
            Property(x => x.OrderNumber);
            Property(x => x.OrderDate);
            Property(x => x.UpdateDate);
            Property(x => x.CustomerName);
            Property(x => x.CustomerSurname);
            Property(x => x.ShippedDate);

            Property(x => x.Version); // If using Optimistic concurrency
            Bag(
                x => x.Items, 
                c =>
                {
                    c.Key(k => k.Column("CorrelationId"));
                }, 
                r => r.OneToMany());
        }
    }
}
