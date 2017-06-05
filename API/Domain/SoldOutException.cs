using System;

namespace API.Domain
{
    public class SoldOutException : Exception
    {
        public SoldOutException():base($"Insufficient quantity available to fulfill order.") {}
    }
}