using ErpOrderProcessing.Services;
using ErpOrderProcessing.Models;
using ErpOrderProcessing.Utils;
using System.Collections.Concurrent;


class Program
{
    static void Main()
    {
        Logger.Configure();

        var cts = new CancellationTokenSource();
        var token = cts.Token;

        var orders = new BlockingCollection<Order>(boundedCapacity: 100);
        var validated = new BlockingCollection<Order>(100);
        var paid = new BlockingCollection<Order>(100);

        var generator = new OrderGenerator(orders);
        var payment = new PaymentService(validated, paid);
        var invoice = new InvoiceService(paid);

        Console.CancelKeyPress += (s, e) =>
        {
            Console.WriteLine("Shutting down...");
            cts.Cancel();
        };

        generator.Start(token);

        Task.Factory.StartNew(() =>
        {
            foreach (var order in orders.GetConsumingEnumerable(token))
            {
                Console.WriteLine($"[VALIDATING] Order: {order.Id} - ${order.Amount}");
                validated.Add(order);
            }
        }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);

        payment.Start(token);
        invoice.Start(token);

        Console.WriteLine("Press Ctrl+C to stop...");
        Thread.Sleep(TimeSpan.FromMinutes(5));

        cts.Cancel();

        orders.CompleteAdding();
        validated.CompleteAdding();
        paid.CompleteAdding();
    }
}