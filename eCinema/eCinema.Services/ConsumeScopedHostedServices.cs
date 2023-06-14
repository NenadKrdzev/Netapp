//using eCinema.Services.Interface;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace eCinema.Services
//{
//    public class ConsumeScopedHostedServices : IHostedService
//    {
//        private readonly IServiceProvider _serviceProvider;

//        public ConsumeScopedHostedServices(IServiceProvider serviceProvider)
//        {
//            _serviceProvider = serviceProvider;
//        }
//        public async Task StartAsync(CancellationToken cancellationToken)
//        {
//            await DoWork();
//        }

//        public Task StopAsync(CancellationToken cancellationToken)
//        {
//            return Task.CompletedTask;
//        }
//        private async Task DoWork()
//        {
//            using(var scope = _serviceProvider.CreateScope())
//            {
//                var scopedProcessingService = scope.ServiceProvider.GetRequiredService<IBackgroundEmailSender>();
//                await scopedProcessingService.DoWork();
//            }
//        }
//    }
//}
