using System;
using System.Threading;

static class StaRunner
{
    public static void Start(Action action)
    {
        Exception exception = null;
        var thread = new Thread(() =>
        {
            try
            {

                action();
            }
            catch (Exception inner)
            {
                exception = inner;
            }
        });
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        thread.Join();
        if (exception != null)
        {
            throw exception;
        }
    }
}