using System;

namespace API.Domain
{
    public class EventPassedException : Exception
    {
        public EventPassedException() : base("The event has already passed")
        {
        }
    }
}