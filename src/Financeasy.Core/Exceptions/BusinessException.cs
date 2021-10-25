using System;

namespace Financeasy.Core
{
    public sealed class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
}