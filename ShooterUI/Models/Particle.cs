using ShooterUI;
using ShooterUI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CatchItUI
{
    public class Particle
    {
        private int _x { get; set; }
        private int _y { get; set; }
        private ConsoleColor _color { get; set; }
        private static List<Particle> _particles { get; set; } = new List<Particle>();
        public static int Points { get; set; }
        public static void Create(int count = 5)
        {
            for (int i = 0; i < count; i++)
            {
                _particles.Add(new Particle
                {
                    _x = RandomNumber.GetRange(2, Window.Width - 2),
                    _y = RandomNumber.Get(Window.Height / 2),
                    _color = RandomColor.Get()
                }); ;
            }
        }
        private static void Draw()
        {
            List<Particle> collidedParticles = new List<Particle>();
            foreach (var particle in _particles)
            {
                foreach (var bullet in Bullet._bullets)
                {
                    if (bullet._x == particle._x && bullet._y == particle._y)
                    {
                        Points++;
                        collidedParticles.Add(particle);
                        continue;
                    }
                }
                Console.CursorVisible = false;
                Console.SetCursorPosition(particle._x, particle._y);
                //particle color
                Console.ForegroundColor = particle._color;
                Console.Write('O');
            }
            collidedParticles.ForEach((collidedParticle) => _particles.Remove(collidedParticle));
        }
        public static void Update()
        {
            Draw();
            if (_particles.Count == 0)
            {
                Create();
            }
        }
    }
}
