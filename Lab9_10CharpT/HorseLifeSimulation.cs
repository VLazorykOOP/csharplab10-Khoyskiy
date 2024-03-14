using System;

namespace HorseLifeSimulation
{
    public delegate void HorseEventHandler(object sender, HorseEventArgs e);

    public class Horse
    {
        static void HandleBirth(object sender, HorseEventArgs e)
        {
            Console.WriteLine($"Обробка події народження нового коня {e.Name}.");
        }

        static void HandleDeath(object sender, HorseEventArgs e)
        {
            Console.WriteLine($"Обробка події смерті коня {e.Name} у віці {e.Age} років.");
        }
        public event HorseEventHandler Birth;
        public event HorseEventHandler Death;

        private string name;
        private int age;
        private bool isAlive;

        private Random rnd = new Random();

        public Horse(string name)
        {
            this.name = name;
            age = 0;
            isAlive = true;
        }
        public bool getIsAlive()
        {
            return isAlive;
        }
        protected virtual void OnBirth(HorseEventArgs e)
        {
            Console.WriteLine($"У коня {e.Name} народився новий потомок!");
            Birth?.Invoke(this, e);
        }

        protected virtual void OnDeath(HorseEventArgs e)
        {
            Console.WriteLine($"Кінь {e.Name} помер у віці {e.Age} років...");
            Death?.Invoke(this, e);
        }

        public void Live()
        {
            Thread thread = new Thread(() =>
            {
                while (isAlive)
                {
                    age++;
                    Console.WriteLine($"Кінь {name} віком {age} років.");

                    // Моделюємо випадкові події
                    if (rnd.NextDouble() < 0.1 && age >= 8 )
                    {
                        HorseEventArgs birthArgs = new HorseEventArgs($"{name}_Child", 0);
                        OnBirth(birthArgs);
                        Horse child = new Horse(birthArgs.Name);
                        child.Birth += HandleBirth;
                        child.Death += HandleDeath;
                        child.Live();
                    }

                    if (rnd.NextDouble() < 0.01 * (age-5))
                    {
                        isAlive = false;
                        HorseEventArgs deathArgs = new HorseEventArgs(name, age);
                        OnDeath(deathArgs);
                    }

                    // Моделюємо хворобу
                    if (rnd.NextDouble() < 0.05)
                    {
                        Console.WriteLine($"Кінь {name} захворів.");
                        if (rnd.NextDouble() < 0.4)
                        {
                            Console.WriteLine($"Кінь {name} помер від хвороби...");
                            isAlive = false;
                            HorseEventArgs deathArgs = new HorseEventArgs(name, age);
                            OnDeath(deathArgs);
                        }
                    }

                    Thread.Sleep(1000); // Затримка для виведення результатів
                }
            });

            thread.Start();
        }
    }
}
