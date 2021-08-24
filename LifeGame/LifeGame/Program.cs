using System;
using System.Linq;
using System.Collections.Generic;

namespace LifeGame
{
    class Program
    {
        static void Main() {
            
            //create array
            Console.WriteLine("Hello! Enter universe size. From 1 to 255:");
            byte arraySize = Convert.ToByte(Console.ReadLine());
            byte[,] firstGeneration = new byte[arraySize,arraySize];
            byte[,] secondGeneration = new byte[arraySize,arraySize];
            
            //calculating cells count
            int cellsCount = Convert.ToInt32(Math.Pow(arraySize, 2));
            
            Console.WriteLine("Universe was created. Size is {0}x{1}. Cells count is {2}", arraySize, arraySize, cellsCount);
            
            //calculating live cells
            Console.WriteLine("Now, enter life cells rate. From 1 to 99 ");
            byte lifeRate = Convert.ToByte(Console.ReadLine());
            int lifeCellsCount = cellsCount * lifeRate / 100;
            Console.WriteLine("Life cells count is " + lifeCellsCount);
            
            //generate place for live sells
                // create all cells list
            /* Тут нужно пояснение на русском. Простой рандом для размещения живых клеток не подошёл,
            потомучто он мог выдать повторяющиеся числа, а значит количество живых клеток уменьшилось.
            Чтобы гарантировать нужное количество живых клеток, я создал List со списком всех клеток.
            Потом я рандомизировал список и брал из него первые Н элементов подходящих мне.
            Уверен, что есть более лёгкие способы, но мне они оказались не под силу.
             */ 
            List<int> allPlaceList = new List<int>();
            for (int i = 0; i < firstGeneration.Length; i++) {
                allPlaceList.Add(i);
            }
                //randomize all cells list
            List<int> aliveRandomPlaceList = new List<int>();
            var rnd = new Random();
            var randomized = allPlaceList.OrderBy(item => rnd.Next());
            foreach(var value in randomized){
                aliveRandomPlaceList.Add(value);
            }
                //place alive cells in universe
            for (int i = 0; i < lifeCellsCount; i++) {
                int xCoordinat = aliveRandomPlaceList[i] / arraySize;
                int yCoordinat = aliveRandomPlaceList[i] % arraySize;
                firstGeneration[xCoordinat, yCoordinat] = 1;
            }

            // print firs generation universe map
             Console.WriteLine("First generation universe map is: ");
             for (int i = 0; i < arraySize; i++) {
                 for (int j = 0; j < arraySize; j++ ) {
                     Console.Write("{0}\t", firstGeneration[i,j]);
                 }
                 Console.WriteLine();
             }

             for (int i = 0; i < arraySize; i++) {
                 for (int j = 0; j < arraySize; j++ ) {
                     // counting neighborhood summ
                     int neighborhoodSum = 0;
                     
                     neighborhoodSum = neighborhoodSum + firstGeneration[x, y];
                     secondGeneration[i, j] = 1;
                 }
                 Console.WriteLine();
             }
     
                 
                 


        }
    }
}