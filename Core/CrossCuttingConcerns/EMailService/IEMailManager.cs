using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.EMailService
{
    public interface IEMailManager
    {
        void SendEMail(EMailConfig eMailConfig, EMailContent eMailContent);
    }
}
