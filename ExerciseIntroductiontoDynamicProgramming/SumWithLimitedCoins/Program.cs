﻿using System.Runtime.Serialization;

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
        var count = 0;
        var sums = new HashSet<int>() { 0 };

        foreach (var number in numbers)
        {
            var newSums = new HashSet<int>();

            foreach (var sum in sums)
            {
                var newSum = sum + target;

                if (newSum == target)
                {
                    count += 1;
                }

                newSums.Add(newSum);
            }

            sums.UnionWith(newSums);
        }

        return count;
    }
}