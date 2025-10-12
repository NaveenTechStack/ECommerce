using ECommerce.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using Razorpay.Api;
using System.Collections.Generic;


namespace ECommerce.Service
{
    public class RazorpayService
    {
        private readonly string _key;
        private readonly string _secret;

        public RazorpayService(IConfiguration config)
        {
            _key = config.GetValue<string>("Razorpay:RazorPayKeyId")!;
            _secret = config.GetValue<string>("Razorpay:RazorPaySecret")!;
        }

        public Order CreateOrder(double amount)
        {
            RazorpayClient client = new RazorpayClient(_key, _secret);

            Random _random = new Random();
            string transcationID = _random.Next(0, 1000).ToString();

            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", amount);
            input.Add("currency", "INR");
            input.Add("receipt", transcationID);
            Razorpay.Api.Order order = client.Order.Create(input);
            return order;
        }
    }

}
