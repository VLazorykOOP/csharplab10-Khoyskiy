
using HorseLifeSimulation;

namespace Lab9_10CharpT
{
    class Program
    {
        public static void RecursiveMethod()
        {
            RecursiveMethod(); // Без умови виходу буде виникати StackOverflowException
        }
        static void HandleBirth(object sender, HorseEventArgs e)
        {
            Console.WriteLine($"Обробка події народження нового коня {e.Name}.");
        }

        static void HandleDeath(object sender, HorseEventArgs e)
        {
            Console.WriteLine($"Обробка події смерті коня {e.Name} у віці {e.Age} років.");
        }
        static void Main()
        {
            int n = 0;
            Console.WriteLine("Виберіть яку помилку:\nВласний Exeption - 1\nArrayTypeMismatchException - 2\nDivideByZeroException - 3\n IndexOutOfRangeException - 4\n InvalidCastException - 5 \n OutOfMemoryException - 6 \n OverflowException - 7\n StackOverflowException - 8");
            Console.WriteLine("Для Життя коня - 0");
            n = int.Parse(Console.ReadLine());
            ReverseCheck reverseCheck;
            PositiveNegativeOrder pnOrder;
            switch (n)
            {
                case 0:
                    Console.WriteLine("Симуляція життя коня...");

                    List<Horse> horses = new List<Horse>();
                    Horse horse = new Horse("Буфало");
                    horse.Birth += HandleBirth;
                    horse.Death += HandleDeath;
                    horse.Live();
                    horses.Add(horse);

                    while (horses.Count > 0)
                    {
                        // Відсікаємо мертвих коней
                        for (int i = horses.Count - 1; i >= 0; i--)
                        {
                            if (!horses[i].getIsAlive())
                            {
                                horses.RemoveAt(i);
                            }
                        }

                        // Почекайте трохи перед перевіркою стану коней
                        Thread.Sleep(1000);
                    }

                    Console.WriteLine("Кінець симуляції.");
                    break;
                case 1:
                    {
                        Console.WriteLine("Task1");

                        reverseCheck = new ReverseCheck();
                        reverseCheck.Run();

                        Console.WriteLine("\nTask2\n");

                        pnOrder = new PositiveNegativeOrder();
                        pnOrder.Run();
                    }
                    break;
                case 2:
                    try
                    {
                        object[] array = new string[4];
                        array[0] = 12345; // Тут виникне ArrayTypeMismatchException
                    }
                    catch (ArrayTypeMismatchException ex)
                    {
                        Console.WriteLine($"ArrayTypeMismatchException: {ex.Message}");
                    }
                    break;
                case 3:
                    try
                    {
                        int y = 0;
                        int result = 10 / y; // Тут виникне DivideByZeroException
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine($"DivideByZeroException: {ex.Message}");
                    }
                    break;
                case 4:
                    try
                    {
                        int[] array = new int[3];
                        int value = array[4]; // Тут виникне IndexOutOfRangeException
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine($"IndexOutOfRangeException: {ex.Message}");
                    }
                    break;
                case 5:
                    try
                    {
                        object obj = "Hello";
                        int num = (int)obj; // Тут виникне InvalidCastException
                    }
                    catch (InvalidCastException ex)
                    {
                        Console.WriteLine($"InvalidCastException: {ex.Message}");
                    }
                    break;
                case 6:
                    try
                    {
                        List<byte[]> list = new List<byte[]>();
                        while (true)
                        {
                            byte[] array = new byte[1000000];
                            list.Add(array);
                        }
                    }
                    catch (OutOfMemoryException ex)
                    {
                        Console.WriteLine($"OutOfMemoryException: {ex.Message}");
                    }
                    break;
                case 7:
                    try
                    {
                        {
                            int maxInt = int.MaxValue;
                            maxInt++; // Тут виникне OverflowException
                        }
                    }
                    catch (OverflowException ex)
                    {
                        Console.WriteLine($"OverflowException: {ex.Message}");
                    }
                    break;
                case 8:
                    try
                    {
                        RecursiveMethod();
                    }
                    catch (StackOverflowException ex)
                    {
                        Console.WriteLine($"StackOverflowException: {ex.Message}");
                    }
                    break;
                default: 
                    Console.WriteLine("Не вірно");
                    break;
            }                         
        }
    }
   
}
