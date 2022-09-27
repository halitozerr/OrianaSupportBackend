using Core.Utilities.EmailService.EmailManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.EmailService
{
    public class EmailService : IMessageService

    {
       
        public Task NotifyPlayerForAttention(string participantId, string subject, string message, string scheduledMeetingId)
        {
            throw new NotImplementedException();
        }
    }
}
