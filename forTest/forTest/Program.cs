using System;
using System.Threading.Channels;

namespace forTest
{
    class Program
    {
        static void Main()
        {
            int arraySize = 4;
            int liveCount = 0;
            int [,] secondGeneration = new int [4, 4] {{0, 1, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}};
            for (int i = 0; i < arraySize; i++) {
                for (int j = 0; j < arraySize; j++ ) {
                   
                    //1st neighbor
                    int x1;
                    if (i == 0) {
                        x1 = arraySize - 1;
                    } else x1 = i - 1;
                    int y1;
                    if (j == 0) {
                        y1 = arraySize - 1;
                    } else y1 = j - 1;                    
                    int n1 = secondGeneration[x1, y1];
                    if (n1 == 1) {
                        liveCount ++;
                    }
                    Console.WriteLine("1st neighbor {0}", n1);
                    
                    //2nd neighbor
                    int x2;
                    if (i == 0) {
                        x2 = arraySize - 1;
                    } else x2 = i - 1;
                    int y2;
                    y2 = j;                    
                    int n2 = secondGeneration[x2, y2];
                    if (n2 == 1) {
                        liveCount ++;
                    } 
                    Console.WriteLine("2nd neighbor {0}", n2);
                    
                    //3rd neighbor
                    int x3;
                    if (i == 0) {
                        x3 = arraySize - 1;
                    } else x3 = i - 1;
                    int y3;
                    if (j == arraySize - 1) {
                        y3 = arraySize - arraySize;
                    } else y3 = j + 1;                    
                    int n3 = secondGeneration[x3, y3];
                    if (n3 == 1) {
                        liveCount ++;
                    } 
                    Console.WriteLine("3rd neighbor {0}", n3);
                    
                    //4th neighbor
                    int x4;
                    x4 = i;
                    int y4;
                    if (j == 0) {
                        y4 = arraySize - 1;
                    } else y4 = j - 1;                    
                    int n4 = secondGeneration[x4, y4];
                    if (n4 == 1) {
                        liveCount ++;
                    } 
                    Console.WriteLine("4th neighbor {0}", n4);
                    
                    //5th neighbor
                    int x5;
                    x5 = i;
                    int y5;
                    if (j == arraySize - 1) {
                        y5 = arraySize - arraySize;
                    } else y5 = j + 1;                     
                    int n5 = secondGeneration[x5, y5];
                    if (n5 == 1) {
                        liveCount ++;
                    } 
                    Console.WriteLine("5th neighbor {0}", n5);
                    
                    //6th neighbor
                    int x6;
                    if (i == arraySize - 1) {
                        x6 = arraySize - arraySize;
                    } else x6 = j + 1;
                    int y6;
                    if (j == 0) {
                        y6 = arraySize - 1;
                    } else y6 = j - 1;                     
                    int n6 = secondGeneration[x6, y6];
                    if (n6 == 1) {
                        liveCount ++;
                    } 
                    Console.WriteLine("6th neighbor {0}", n6);
                    
                    //7th neighbor
                    int x7;
                    if (i == arraySize - 1) {
                        x7 = arraySize - arraySize;
                    } else x7 = j + 1;
                    int y7;
                    y7 = j;                    
                    int n7 = secondGeneration[x7, y7];
                    if (n7 == 1) {
                        liveCount ++;
                    } 
                    Console.WriteLine("7th neighbor {0}", n7);
                    
                    //8th neighbor
                    int x8;
                    if (i == arraySize - 1) {
                        x8 = arraySize - arraySize;
                    } else x8 = i + 1;
                    int y8;
                    if (j == arraySize - 1) {
                        y8 = arraySize - arraySize;
                    } else y8 = j + 1;                   
                    int n8 = secondGeneration[x8, y8];
                    if (n8 == 1) {
                        liveCount ++;
                    } 
                    Console.WriteLine("8th neighbor {0}", n8);
                    
                    // if (liveCount > 1 && liveCount < 4) {
                    //     secondGeneration[i, j] = 1;
                    // } else secondGeneration[i, j] = 0;

                }

            }
            Console.WriteLine("В левом верхнем углу {0}", liveCount);
        }
    }
}