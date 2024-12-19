using System;
using System.Threading;

class Program
{
    static int counter = 0;

    static void IncrementCounter()
    {
        for (int i = 0; i < 1000; i++)
        {
            counter++; // Несинхронизированный доступ
        }
    }

    static void Main()
    {
        Thread thread1 = new Thread(IncrementCounter);
        Thread thread2 = new Thread(IncrementCounter);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine($"Результат: {counter}"); // Результат может быть меньше 2000 из-за гонки данных
    }
}
