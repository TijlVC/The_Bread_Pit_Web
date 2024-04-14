using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using The_Bread_Pit.Models;

public class Purge : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<Purge> _logger;

    public Purge(IServiceProvider serviceProvider, ILogger<Purge> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var now = DateTime.Now;
            var nextRunTime = new DateTime(now.Year, now.Month, now.Day, 14, 30, 0);

            if (now >= nextRunTime)
            {
                nextRunTime = nextRunTime.AddDays(1);
            }

            var delay = nextRunTime - now;

            _logger.LogInformation($"Purge scheduled to run at: {nextRunTime}. Delay: {delay.TotalMilliseconds} milliseconds.");

            await Task.Delay(delay, stoppingToken);

            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<TheBreadPitContext>();
                var bestellingen = context.Bestellingen;
                context.Bestellingen.RemoveRange(bestellingen);
                await context.SaveChangesAsync();
                _logger.LogInformation("All orders have been purged successfully.");
            }
        }
    }

}