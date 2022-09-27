using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.QuartzTask.JobFactory
{
    public class MyScheduler : IHostedService
    {
        public IScheduler Scheduler { get; set; }
        private readonly IJobFactory _jobFactory;
        private readonly ISchedulerFactory _schedulerFactory;
        private StdSchedulerFactory _factory = new StdSchedulerFactory();
    
        



        public MyScheduler(IScheduler scheduler,IJobFactory jobFactory,ISchedulerFactory schedulerFactory)
        {
            
            _jobFactory = jobFactory;
            _schedulerFactory = schedulerFactory;
        }

        public async System.Threading.Tasks.Task StartAsync(CancellationToken cancellationToken)
        {
            Scheduler = await _schedulerFactory.GetScheduler();
            Scheduler.JobFactory = _jobFactory;
            await Scheduler.Start(cancellationToken);
            await System.Threading.Tasks.Task.CompletedTask;
        }


        public async System.Threading.Tasks.Task StopAsync(CancellationToken cancellationToken)
        {
            await Scheduler.Shutdown();
        }
    }
}
