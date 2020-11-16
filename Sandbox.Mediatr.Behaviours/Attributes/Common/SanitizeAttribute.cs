using System;

namespace Sandbox.MediatR.Behaviours.API.Attributes.Common
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class SanitizeAttribute : Attribute
    {
        public abstract object GetSanitizedValue(object input);
    }
}