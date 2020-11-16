using MediatR;
using Sandbox.MediatR.Behaviours.API.Attributes;

namespace Sandbox.MediatR.Behaviours.API.Sms
{
    public class SmsCommand : IRequest
    {
        [OnlyDigits]
        public string Phone { get; set; }
    }
}
