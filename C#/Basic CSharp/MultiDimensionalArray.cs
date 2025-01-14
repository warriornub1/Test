namespace Basic_CSharp
{
    public class MultiDimensionalArray
    {
        public MultiDimensionalArray()
        {
            int[][] intArray = new int[5][];
            intArray[0] = new int[3];
            intArray[1] = new int[6];
            intArray[2] = new int[10];

            for(int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(intArray[i] == null);
                intArray[i] = new int[6];
            }
            intArray[0][2] = 5;


            int[,] intArray1 = new int[5, 6];
            for(int i = 0; i < intArray1.GetLength(0); i++)
            {
                for(int j = 0; j < intArray1.GetLength(1); j++)
                {
                    Console.WriteLine(i + ", " + j + ": " + intArray1[i, j]);
                }
            }
        }
    }
}
