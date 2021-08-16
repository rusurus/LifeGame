using System;

namespace LifeGame
{
    class Program
    {
        static void Main() {
            
            //create array
            Console.WriteLine("Hello! Enter universe size. From 1 to 255:");
            byte arraySize = Convert.ToByte(Console.ReadLine());
            byte[,] firstGeneration = new byte[arraySize,arraySize];
            
            //calculating cells count
            int cellsCount = Convert.ToInt32(Math.Pow(arraySize, 2));
            
            Console.WriteLine("Universe was created. Size is {0}x{1}. Cells count is {2}", arraySize, arraySize, cellsCount);
            
            //calculating live cells
            Console.WriteLine("Now, enter life cells rate. From 1 to 99 ");
            byte lifeRate = Convert.ToByte(Console.ReadLine());
            int lifeCellsCount = cellsCount * lifeRate / 100;
            Console.WriteLine("Life cells count is " + lifeCellsCount);
            
            

        }
    }
}