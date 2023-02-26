namespace Lesson3
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<int> testList = new List<int>();

            int num = 12;

            Random random = new Random();

            for (int i = 0; i < num; i++)
            {
                testList.Add(i);
            }

            ListPrint(testList);
            ListReverse(testList);
            ListPrint(testList);

        }

        private static void ListPrint(List<int> list)
        {
            foreach (var num in list)
            {
                Console.Write($"{num}"+" ");
            }
            Console.WriteLine();
        }

        private static void ListReverse(List<int> list)
        {
            for (int i = 0; i < list.Count/2; i++)
            {
                (list[i], list[list.Count - i - 1]) = (list[list.Count - i - 1], list[i]);
            }
        }
    }
}
