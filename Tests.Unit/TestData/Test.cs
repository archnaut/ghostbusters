
namespace Tests.Unit.TestData
{
    public class Test
    {
        public EventControllerBuilder EventController()
        {
            return new EventControllerBuilder();
        }

        public static EventBuilder Event()
        {
            return new EventBuilder();
        }
    }
}