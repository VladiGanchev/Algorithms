public class Program
{
    private static int k;
    private static string[] variations;
    public static string[] letters;
    public static string[] permutations;
    public static string[] combinations;
    public static bool[] used;
    public static HashSet<string> permutationsSecond;

    public static void Main(string[] args)
    {
        //Task 1
        //letters = new string[] { "A", "B", "C" };
        //permutations = new string[letters.Length];
        //used = new bool[letters.Length];

        //Permute(0);

        //Task2

        //letters = Console.ReadLine().Split();
        //PermuteSecond(0);

        //Task 3

        //letters = Console.ReadLine().Split();
        //k = int.Parse(Console.ReadLine());
        //variations = new string[k];
        //used = new bool[letters.Length];

        //Variations(0);

        //Task 4

        //letters = Console.ReadLine().Split();
        //k = int.Parse(Console.ReadLine());
        //variations = new string[k];
        //VariationsSecond(0);

        //Task 5 

        //letters = Console.ReadLine().Split();
        //k = int.Parse(Console.ReadLine());
        //combinations = new string[k];

        //GenCombinations(0, 0);

        //Task 6
        //letters = Console.ReadLine().Split();
        //k = int.Parse(Console.ReadLine());
        //combinations = new string[k];

        //GenCombinationsSecond(0, 0);


        //Task 7

        var n = int.Parse(Console.ReadLine());
        var k = int.Parse(Console.ReadLine());

        Console.WriteLine(GetBinom(n, k));

    }

    private static int GetBinom(int row, int col)
    {
        if (row <= 1 || col == 0 || col == row)
        {
            return 1;
        }

        return GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);
    }

    private static void GenCombinationsSecond(int idx, int elementsStartIdx)
    {
        if (idx >= combinations.Length)
        {
            Console.WriteLine(string.Join(" ", combinations));
            return;
        }

        for (int i = elementsStartIdx; i < letters.Length; i++)
        {
            combinations[idx] = letters[i];
            GenCombinationsSecond(idx + 1, i);
        }
    }
    private static void GenCombinations(int idx, int elementsStartIdx)
    {
        if (idx >= combinations.Length)
        {
            Console.WriteLine(string.Join(" ", combinations));
            return;
        }

        for (int i = elementsStartIdx; i < letters.Length; i++)
        {
            combinations[idx] = letters[i];
            GenCombinations(idx + 1, i + 1);
        }
    }

    private static void VariationsSecond(int idx)
    {
        if (idx >= variations.Length)
        {
            Console.WriteLine(string.Join("", variations));
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
                variations[idx] = letters[i];
                VariationsSecond(idx + 1);
        }
    }

    private static void Variations(int idx)
    {
        if (idx >= variations.Length)
        {
            Console.WriteLine(string.Join("", variations));
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            if (!used[i])
            {
                used[i] = true;
                variations[idx] = letters[i];
                Variations(idx + 1);
                used[i] = false;
            }
        }
    }

    private static void PermuteSecond(int idx)
    {
        if (idx >= letters.Length)
        {
            Console.WriteLine(String.Join("", letters));
            return;
        }

        PermuteSecond(idx + 1);

        var usedElements = new HashSet<string>() { letters[idx] };

        for (int i = idx + 1; i < letters.Length; i++)
        {
            if (!usedElements.Contains(letters[i]))
            {
                Swap(idx, i);
                PermuteSecond(idx + 1);
                Swap(idx, i);

                usedElements.Add(letters[i]);
            }

        }
    }

    private static void Swap(int first, int second)
    {
        var temp = letters[first];
        letters[first] = letters[second];
        letters[second] = temp;
    }

    private static void Permute(int idx)
    {
        if (idx >= letters.Length)
        {
            Console.WriteLine(String.Join("", permutations));
            return;
        }

        for (int i = 0; i < permutations.Length; i++)
        {
            if (!used[i])
            {
                permutations[idx] = letters[i];
                used[i] = true;
                Permute(idx + 1);
                used[i] = false;
            }
        }
    }
}