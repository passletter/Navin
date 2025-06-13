using ErpOrderProcessing.Models;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ErpOrderProcessing.Services
{
    public class InvoiceService
    {
        private readonly BlockingCollection<Order> _input;

        public InvoiceService(BlockingCollection<Order> input)
        {
            _input = input;
        }

        public void Start(CancellationToken token)
        {
            Task.Factory.StartNew(() =>
            //do your processing here; whatever you like
            {
                foreach (var order in _input.GetConsumingEnumerable(token))
                {
                    Thread.Sleep(200);
                    Console.WriteLine($"[INVOICED] Order: {order.Id} - ${order.Amount}");
                }
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }
    }
}