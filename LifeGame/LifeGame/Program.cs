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
            var randomized = allPlaceList.OrderBy(2item => rnd.Next());
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
            // neighborhood counting
            for (int i = 0; i < arraySize; i++) {
                for (int j = 0; j < arraySize; j++ ) {
                    int liveCount = 0;
                    //1st neighbor
                    int x1;
                    if (i == 0) {
                        x1 = arraySize - 1;
                    } else x1 = i - 1;
                    int y1;
                    if (j == 0) {
                        y1 = arraySize - 1;
                    } else y1 = j - 1;                    
                    int n1 = firstGeneration[x1, y1];
                    if (n1 == 1) {
                        liveCount ++;
                    }
                    
                    //2nd neighbor
                    int x2;
                    if (i == 0) {
                        x2 = arraySize - 1;
                    } else x2 = i - 1;
                    int y2;
                    y2 = j;                    
                    int n2 = firstGeneration[x2, y2];
                    if (n2 == 1) {
                        liveCount ++;
                    } 
                    
                    //3rd neighbor
                    int x3;
                    if (i == 0) {
                        x3 = arraySize - 1;
                    } else x3 = i - 1;
                    int y3;
                    if (j == arraySize - 1) {
                        y3 = arraySize - arraySize;
                    } else y3 = j + 1;                    
                    int n3 = firstGeneration[x3, y3];
                    if (n3 == 1) {
                        liveCount ++;
                    } 
                    
                    //4th neighbor
                    int x4;
                    x4 = i;
                    int y4;
                    if (j == 0) {
                        y4 = arraySize - 1;
                    } else y4 = j - 1;                    
                    int n4 = firstGeneration[x4, y4];
                    if (n4 == 1) {
                        liveCount ++;
                    } 
                    
                    //5th neighbor
                    int x5;
                    x5 = i;
                    int y5;
                    if (j == arraySize - 1) {
                        y5 = arraySize - arraySize;
                    } else y5 = j + 1;                     
                    int n5 = firstGeneration[x5, y5];
                    if (n5 == 1) {
                        liveCount ++;
                    } 
                    
                    //6th neighbor
                    int x6;
                    if (i == arraySize - 1) {
                        x6 = arraySize - arraySize;
                    } else x6 = i + 1;
                    int y6;
                    if (j == 0) {
                        y6 = arraySize - 1;
                    } else y6 = j - 1;                     
                    int n6 = firstGeneration[x6, y6];
                    if (n6 == 1) {
                        liveCount ++;
                    } 
                    
                    //7th neighbor
                    int x7;
                    if (i == arraySize - 1) {
                        x7 = arraySize - arraySize;
                    } else x7 = i + 1;
                    int y7;
                    y7 = j;                    
                    int n7 = firstGeneration[x7, y7];
                    if (n7 == 1) {
                        liveCount ++;
                    } 
                    
                    //8th neighbor
                    int x8;
                    if (i == arraySize - 1) {
                        x8 = arraySize - arraySize;
                    } else x8 = i + 1;
                    int y8;
                    if (j == arraySize - 1) {
                        y8 = arraySize - arraySize;
                    } else y8 = j + 1;                   
                    int n8 = firstGeneration[x8, y8];
                    if (n8 == 1) {
                        liveCount ++;
                    }
                    
                    //create second universe
                    if (liveCount > 1 && liveCount < 4) {
                        secondGeneration[i, j] = 1;
                    } else secondGeneration[i, j] = 0;

                }

            }
            // print second generation universe map
            Console.WriteLine("second generation universe map is: ");
            for (int i = 0; i < arraySize; i++) {
                for (int j = 0; j < arraySize; j++ ) {
                    Console.Write("{0}\t", secondGeneration[i,j]);
                }
                Console.WriteLine();
            }
     
        }
    }
}