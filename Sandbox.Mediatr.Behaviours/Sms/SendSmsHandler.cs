using System.Diagnostics;
using MediatR;

namespace Sandbox.MediatR.Behaviours.API.Sms
{
    public class SendSmsHandler : RequestHandler<SmsCommand>
    {
        protected override void Handle(SmsCommand notification)
        {
            Debug.WriteLine($"Sending sms to {notification.Phone}...");
        }
    }
}
