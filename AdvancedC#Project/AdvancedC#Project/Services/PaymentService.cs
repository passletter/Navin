using ErpOrderProcessing.Models;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ErpOrderProcessing.Services
{
    public class PaymentService
    {
        private readonly BlockingCollection<Order> _input;
        private readonly BlockingCollection<Order> _output;

        public PaymentService(BlockingCollection<Order> input, BlockingCollection<Order> output)
        {
            _input = input;
            _output = output;
        }

        public void Start(CancellationToken token)
        {
            Task.Factory.StartNew(() =>
            {
                //do your processing of payments here
                foreach (var order in _input.GetConsumingEnumerable(token))
                {
                    Thread.Sleep(500);
                    Console.WriteLine($"[PAID] Order: {order.Id} - ${order.Amount}");
                    _output.Add(order);
                }
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }
    }
}