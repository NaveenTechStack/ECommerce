using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {

        private readonly ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            _db = _dbContext;
        }
        
        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
        }

        public void UpdatePaymentStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderFromDB = _db.OrderHeaders.FirstOrDefault(x=>x.Id == id);
            if (orderFromDB !=null)
            {
                orderFromDB.OrderStatus = orderStatus;
                if(!string.IsNullOrEmpty(paymentStatus))
                {
                    orderFromDB.PaymentStatus = paymentStatus;
                }
                
            }
        }

        public void UpdateRazorPaymentId(int id, string sessionId, string? paymentIntentId)
        {
            var orderFromDB = _db.OrderHeaders.FirstOrDefault(x => x.Id == id);
            if (orderFromDB != null)
            {
                if (!string.IsNullOrEmpty(sessionId))
                {
                    orderFromDB.SessionId = sessionId;
                }
                if (!string.IsNullOrEmpty(paymentIntentId))
                {
                    orderFromDB.PaymentIntentId = paymentIntentId;
                    orderFromDB.PaymentDate = DateTime.Now;
                }
            }
        }
    }
}
