using System;
using Mod7.Car;

namespace Mod7
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new HybridCar();
            car.Move();
        }
    }
}
