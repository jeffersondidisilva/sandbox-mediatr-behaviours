using System.Collections.Generic;

namespace Sandbox.MediatR.Behaviours.API.Controllers.Common
{
    public static class Validations
    {
        public static bool HasErrors => Errors.Count > 0;
        public static IList<string> Errors { get; private set; } = new List<string>();

        public static void Create(List<string> errors)
        {
            Errors = errors;
        }
    }
}