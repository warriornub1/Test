using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.CSharpBasic.MultiDimensionArray
{
    public class MultiDimensionArray
    {
        public MultiDimensionArray()
        {
            int[,] intArray = new int[5, 6];
            int[,] intArray1 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };

            for (int i = 0; i < intArray.GetLength(0); i++)
            {
                for(int j = 0; j < intArray.GetLength(1); j++)
                {
                    Console.WriteLine(i + " , " + j + intArray[i, j]);
                }
            }

            int[][] Array2 = new int[5][];
            Array2[0] = new int[3];
            Array2[1] = new int[6];
            Array2[2] = new int[10];
            for (int i = 0; i < Array2.Length; i++)
            {
                Array2[i] = new int[6];
            }
        }
    }
}
