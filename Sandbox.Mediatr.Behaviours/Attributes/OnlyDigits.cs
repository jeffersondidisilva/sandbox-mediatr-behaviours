using System;
using System.Linq;
using Sandbox.MediatR.Behaviours.API.Attributes.Common;

namespace Sandbox.MediatR.Behaviours.API.Attributes
{
    public class OnlyDigits : SanitizeAttribute
    {
        public override object GetSanitizedValue(object input)
        {
            if (input == null)
                return null;

            if(!(input is string))
                throw new Exception($"You cannot use {nameof(OnlyDigits)} attribute in a non string property!");

            var value = (string) input;
            return new string(value.Where(char.IsDigit).ToArray());
        }
    }
}