using CatchItUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShooterUI.Models
{
    public static class Shooter
    {
        public static int X { get; private set; }
        public static int Y { get; private set; } = Window.Height;
        public static void Draw()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(X, Y);
            Console.Write(@"_|_");
        }
        public static void Update()
        {
            Draw();
            if(Console.KeyAvailable == false)
            {
                return;
            }
            MoveFire(Console.ReadKey());
        }
        private static void MoveFire(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (X <= 0)
                    {
                        Console.Beep();
                        return;
                    }
                    X--;
                    break;
                case ConsoleKey.RightArrow:
                    if (X >= Window.Width)
                    {
                        Console.Beep();
                        return;
                    }
                    X++;
                    break;
                case ConsoleKey.Spacebar:
                    Bullet.Create();
                    Bullet.Fire();
                    break;
                case ConsoleKey.Escape:
                    Program.Exit = true;
                    break;
                default:
                    Console.Beep();
                    break;
            }
        }
    }
}
