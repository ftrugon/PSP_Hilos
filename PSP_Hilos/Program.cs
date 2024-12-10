// See https://aka.ms/new-console-template for more information


class ThreadTest
{
    static void Main()
    {
        Thread t = new Thread (new ThreadStart (Go));
        Thread t2 = new Thread (new ThreadStart (Go));
        Thread t3 = new Thread (new ThreadStart (Go));
        t.Start(); // Run Go() on the new thread.
        t2.Start(); // Run Go() on the new thread.
        t3.Start(); // Run Go() on the new thread.
        //Go(); // Simultaneously run Go() in the main thread.
        
    }
    static void Go()
    {
        Console.WriteLine ("hello!");
    }
}