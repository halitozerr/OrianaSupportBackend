using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.QuartzTask.Jobs
{
    public class LoggerJob  : IJob
    {
        private readonly ILogger<LoggerJob> _logger;

        public LoggerJob(ILogger<LoggerJob> logger)
        {
            _logger = logger;
        }




        public System.Threading.Tasks.Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation($"Log Job: at {DateTime.Now} and Jobtype: {context.JobDetail.JobType}");
            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
