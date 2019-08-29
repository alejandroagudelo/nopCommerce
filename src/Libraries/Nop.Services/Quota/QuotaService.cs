using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Domain.Orders;
using Nop.Core.Events;
using Nop.Services.Events;

namespace Nop.Services.Quota
{
    public class QuotaServices : IQuotaServices,
        //orders
        IConsumer<EntityInsertedEvent<Order>>,
        IConsumer<EntityChangeStatusEvent<Order>>
    {
        #region Methods

        #region Orders

        public void HandleEvent(EntityInsertedEvent<Order> eventMessage)
        {
            var usedQuota = eventMessage.Entity.Customer.UsedQuota;
            if (usedQuota.HasValue)
                eventMessage.Entity.Customer.UsedQuota += eventMessage.Entity.OrderTotal;
        }

        public void HandleEvent(EntityChangeStatusEvent<Order> eventMessage)
        {
            var usedQuota = eventMessage.Entity.Customer.UsedQuota;
            if (usedQuota.HasValue && eventMessage.Entity.OrderStatus == OrderStatus.Cancelled)
                eventMessage.Entity.Customer.UsedQuota -= eventMessage.Entity.OrderTotal;
        }

        #endregion

        #endregion
    }
}
