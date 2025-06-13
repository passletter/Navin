using ErpOrderProcessing.Models;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ErpOrderProcessing.Services
{
    public class OrderGenerator
    {
        private readonly BlockingCollection<Order> _orders;
        public OrderGenerator(BlockingCollection<Order> orders)
        {
            _orders = orders;
        }

        public void Start(CancellationToken token)
        {
            Task.Factory.StartNew(() =>
            //do your processing here; whatever you like
            {
                var sources = new[] { "Web", "POS", "API" };
                var rand = new Random();

                while (!token.IsCancellationRequested)
                {
                    var order = new Order
                    {
                        Source = sources[rand.Next(sources.Length)],
                        Amount = rand.Next(100, 1000)
                    };
                    _orders.Add(order);
                    Thread.Sleep(300);
                }
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }
    }
}