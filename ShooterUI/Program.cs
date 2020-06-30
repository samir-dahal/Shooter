using CatchItUI;
using ShooterUI.Models;
using System;
using System.Threading;

namespace ShooterUI
{
    class Program
    {
        public static bool Exit { get; set; } = false;
        public static bool Replay { get; set; } = false;
        static void Main(string[] args)
        {
            Particle.Create();
            while (true)
            {
                Console.Clear();
                Particle.Update();
                Shooter.Update();
                Bullet.Update();
                Thread.Sleep(50);
                if (Exit)
                {
                    break;
                }
            }
            Console.WriteLine($"Your Total Score = {Particle.Points}");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
