namespace RecursionAndBacktracking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Task 1
            //int[] arr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            //Console.WriteLine(RecursiveArraySum(arr, 0));


            //Task 2
            //int n = int.Parse(Console.ReadLine());
            //RecursiveDrawing(n);


            //Task 3
            //int n = int.Parse(Console.ReadLine());
            //int[] arr = new int[n];
            //Generating01Vectors(arr, 0);


            //Task 4
            //int n = int.Parse(Console.ReadLine());
            //Console.WriteLine(Factoriel(n));


            //Task 5
            //int rows = int.Parse(Console.ReadLine());
            //int cols = int.Parse(Console.ReadLine());

            //char[,] arr = new char[rows, cols];

            //for (int i = 0; i < rows; i++)
            //{
            //    var elements = Console.ReadLine();

            //    for (int j = 0; j < cols; j++)
            //    {
            //        arr[i, j] = elements[j];
            //    }
            //}

            //FindPaths(arr, 0, 0,new List<string>(), string.Empty);


            //Task 6


            //Task 7
            //int n = int.Parse(Console.ReadLine());
            //Console.WriteLine(Fibonacci(n));

        }

        private static int Fibonacci(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        private static void FindPaths(char[,] arr, int row, int col, List<string> directions, string direction)
        {
            if (row < 0 || row >= arr.GetLength(0) || col < 0 || col >= arr.GetLength(1))
            {
                return;
            }

            if (arr[row, col] == '*' || arr[row, col] == 'v')
            {
                return;
            }

            directions.Add(direction);

            if (arr[row, col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            arr[row, col] = 'v';

            FindPaths(arr, row, col + 1, directions, "R");
            FindPaths(arr, row + 1, col, directions, "D");
            FindPaths(arr, row, col - 1, directions, "L");
            FindPaths(arr, row - 1, col, directions, "U");

            arr[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }

        private static int Factoriel(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Factoriel(n - 1);
        }

        private static void Generating01Vectors(int[] arr, int idx)
        {
            if (idx >= arr.Length)
            {
                Console.WriteLine(string.Join("", arr));
                return;
            }


            for (int i = 0; i < 2; i++)
            {
                arr[idx] = i;
                Generating01Vectors(arr, idx + 1);
            }
        }

        private static void RecursiveDrawing(int n)
        {
            if (n == 0)
            {
                return;
            }

            Console.WriteLine(new string('#', n));

            RecursiveDrawing(n - 1);

            Console.WriteLine(new string('*', n));


        }

        private static int RecursiveArraySum(int[] arr, int idx)
        {
            if (idx == arr.Length)
            {
                return 0;
            }

            return arr[idx] + RecursiveArraySum(arr, idx + 1);

        }
    }
}
