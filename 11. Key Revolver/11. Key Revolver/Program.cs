using System;
using System.Collections.Generic;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPriceEach = int.Parse(Console.ReadLine());
            int sizeBarrel = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>();
            string[] bulletsRead = Console.ReadLine().Split(" ");
            string[] locksRead = Console.ReadLine().Split(" ");
            Queue<int> locks = new Queue<int>();
            int valueIntelligence = int.Parse(Console.ReadLine());
            int bulletPrice = 0;
            int bulletsShot = 0;
            foreach (var item in locksRead)
            {
                locks.Enqueue(int.Parse(item));
            }
            foreach (var item in bulletsRead)
            {
                bullets.Push(int.Parse(item));
            }
            for (int i = 0; i < bulletsRead.Length; i++)
            {
                int bulletSize = bullets.Pop();
                bulletsShot++;
                bulletPrice += bulletPriceEach;
                int lockSize = locks.Peek();
                if (bulletSize <= lockSize)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else if (bulletSize > lockSize)
                {
                    Console.WriteLine("Ping!");
                }
                if (locks.Count == 0 || bullets.Count == 0 || bulletsShot % sizeBarrel == 0)
                {
                    int moneyEarned = valueIntelligence - bulletPrice;
                    if (bulletsShot % sizeBarrel == 0 && bullets.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                    }
                    if (locks.Count == 0)
                    {
                        Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
                        break;
                    }
                    else if (bullets.Count == 0)
                    {
                        Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                        break;
                    }
                }
            }
        }
    }
}
