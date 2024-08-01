using System.Runtime.Serialization;

public class Program
{
    public static void Main(string[] args)
    {
        var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var target = int.Parse(Console.ReadLine());

        Console.WriteLine(CountSums(numbers, target));
    }

    private static int CountSums(int[] numbers, int target)
    {
        var sums = new int[target + 1];
        sums[0] = 1;

        foreach (var number in numbers)
        {
            for (int sum = 0; sum < target; sum++)
            {
                sums[sum] += sums[sum - number];
            }
        }

        return sums[target];
    }
}