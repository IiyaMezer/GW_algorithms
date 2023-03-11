namespace Leeson4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new RBTree();
            string input;
            while (true)
            {
                Console.Write("Введите значение узла дерева: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    tree.add(result);
                    Console.WriteLine("done");
                }
                else
                {
                    if (input.Equals("exit"))
                    {
                        return;
                    }
                }
            }
        }
    }
}