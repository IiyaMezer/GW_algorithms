namespace Lesson2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] test_array = ArrayUtils.PrepareArray(6);
            ArrayUtils.PrintArray(test_array);

            DateTime start = DateTime.Now;
            Sort.HeapSort(test_array);
            DateTime end = DateTime.Now;
            ArrayUtils.PrintArray(test_array);
            Console.WriteLine($"Операция выполнена за {(end - start).TotalMilliseconds}");
        }
    }
}

public static class Sort
{/// <summary>
/// Сортировка кучей
/// </summary>
/// <param name="unsorted_array">неотсортированный массив</param>
    public static void HeapSort(int[] unsorted_array)
    {
        
        for (int i = unsorted_array.Length / 2 - 1; i >= 0; i--)
        {
            ArrayToHeap(unsorted_array, unsorted_array.Length, i);
        }

        for (int i = unsorted_array.Length - 1; i >= 0 ; i--)
        {
            (unsorted_array[0], unsorted_array[i]) = (unsorted_array[i], unsorted_array[0]);
            ArrayToHeap(unsorted_array, i, 0);
        }
    }
    /// <summary>
    /// Преобразование исходного массива в кучу
    /// </summary>
    /// <param name="initial_array">исходный массив</param>
    /// <param name="N">длина массива, получаем непосредвенно перед сортировкой</param>
    /// <param name="i">предварительно обьявленный корень кучи</param>
    private static void ArrayToHeap(int[] initial_array, int N, int i)
    {
        int root = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        if (left < N && initial_array[left] > initial_array[root])
            root = left;
        if (right < N && initial_array[right] > initial_array[root])
            root = right;
        if (root != i)
        {
            initial_array[i] += initial_array[root];
            initial_array[root] = initial_array[i] - initial_array[root];
            initial_array[i] -= initial_array[root];
            ArrayToHeap(initial_array, N, root);
        }
    }
}
public static class ArrayUtils
{
    private static Random random = new Random();

    /// <summary>
    /// генерация массива
    /// </summary>
    /// <param name="length">Размерность массива</param>
    /// <returns>готовый к работе массив</returns>
    public static int[] PrepareArray(int length)
    {
        int[] array = new int[length];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-99, 100);
        }
        return array;
    }

    /// <summary>
    /// Распечатать массив
    /// </summary>
    /// <param name="array">Массив</param>
    public static void PrintArray(int[] array)
    {
        foreach (var e in array)
        {
            Console.Write($"{e}\t");
        }
        Console.WriteLine();
    }
}