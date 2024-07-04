namespace SortingAlgorithms;

class Program
{
    static void Main(string[] args)
    {
        int[] array = new[] { 15, 15, 9, 11, 11, 26, 17, 34, 150, 150, 3, 7, 56, 60, 9, 12, 26, 150 };
        //Console.WriteLine(string.Join(" ", ExchangeSort(array)));
        //Console.WriteLine(string.Join(" ", BubbleSort(array)));
        Console.WriteLine(string.Join(" ", BubbleSortSingleLoop(array)));
    }
    
    /// <summary>
    /// Exchange sort It compares the first element with every element if any element seems out of order it swaps
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    private static int[] ExchangeSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] > array[j])
                {
                    //Swap(ref array[i], ref array[j]);
                    Swap(array, i, j);
                    // int tmp = array[i];
                    // array[i] = array[j];
                    // array[j] = tmp;
                    
                    //(array[i], array[j]) = (array[j], array[i]);
                }
            }
        }

        return array;
    }

    /// <summary>
    /// Bubble sort compares the first two elements, and if the first is greater than the second, it swaps them.
    /// It continues doing this for each pair of adjacent elements to the end of the data set.
    /// It then starts again with the first two elements, repeating until no swaps have occurred on the last pass.
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    private static int[] BubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    //Swap(ref array[j], ref array[j + 1]);
                    Swap(array, j, j + 1);
                    // int tmp = array[j];
                    // array[j] = array[j + 1];
                    // array[j + 1] = tmp;
                    
                    //(array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }

        return array;
    }

    private static int[] BubbleSortSingleLoop(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                Swap(array, i, i + 1);
                i = -1;
            }
        }

        return array;
    }

    private static void Swap(int[] array, int index1, int index2)
    {
        int tmp = array[index1];
        array[index1] = array[index2];
        array[index2] = tmp;
        //(array[index1], array[index2]) = (array[index2], array[index1]);
    }
    
    // private static void Swap(ref int x, ref int y)
    // {
    //     int temp = x;
    //     x = y;
    //     y = temp;
    // }
}