using System;
using System.Collections.Generic;

namespace VehicleConsole
{
    class Program
    {
        static void LogicForCar()
        {
            Console.Write("Car logic");
        }
        static void LogicForTruck()
        {
            Console.Write("Truck logic");
        }
        static void LogicForTain()
        {
            Console.Write("Train logic");
        }
        static void Main(string[] args)
        {
            var logicMapper = new Dictionary<string, Action>();

            logicMapper.Add("car", LogicForCar);
            logicMapper.Add("truck", LogicForTruck);
            logicMapper.Add("train", LogicForTain);

            foreach (var logic in logicMapper)
                logic.Value.Invoke();

            Console.Read();
        }
    }
}
