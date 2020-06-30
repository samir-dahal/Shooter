using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ShooterUI.Models
{
    public class Bullet
    {
        public static List<Bullet> _bullets { get; private set; } = new List<Bullet>();
        public int _x { get; private set; }
        public int _y { get; private set; }
        public static void Create()
        {
            _bullets.Add(new Bullet
            {
                _x = Shooter.X+1,
                _y = Shooter.Y-1
            });
        }
        private static void Draw()
        {
            Console.CursorVisible = false;
            _bullets.ForEach((bullet) =>
            {
                Console.SetCursorPosition(bullet._x, bullet._y);
                Console.Write("^");
            });
        }
        private static void Move()
        {
            List<Bullet> bulletOutOfContext = new List<Bullet>();
            foreach (var bullet in _bullets)
            {
                if (bullet._y <= 1)
                {
                    bulletOutOfContext.Add(bullet);
                    continue;
                }
                bullet._y--;
            }
            bulletOutOfContext.ForEach((bullet) => _bullets.Remove(bullet));
        }
        public static void Fire()
        {
            Draw();
            Move();
        }
        public static void Update()
        {
            Fire();
        }
    }
}
