using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader obj);
        void UpdatePaymentStatus(int id, string orderStatus, string? paymentStatus = null);
        void UpdateRazorPaymentId(int id, string sessionId, string? paymentIntentId);
    }
}
