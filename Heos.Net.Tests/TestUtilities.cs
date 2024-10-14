namespace Heos.Net.Tests
{
    public static class TestUtilities 
    {
        public static TaskCompletionSource<bool> ConnectHandler(HeosClient heos, string signal, string evt)
        {
            ArgumentNullException.ThrowIfNull(heos);
            var trigger = new TaskCompletionSource<bool>();

            Task Handler(string targetEvent, params object[] args)
            {
                if (targetEvent == evt)
                {
                    trigger.SetResult(true);
                }
                return Task.CompletedTask;
            }

            heos.Dispatcher.Connect(signal, Handler);
            return trigger;
        }
    }
}