using Serilog;

namespace ErpOrderProcessing.Utils
{
    public static class Logger
    {
        public static void Configure()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("logs/order-processing.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}