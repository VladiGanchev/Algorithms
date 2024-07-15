public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        PrintCombs(0, arr);
    }

    private static void PrintCombs(int idx, int[] arr)
    {
        if (idx >= arr.Length)
        {
            Console.WriteLine(String.Join(" ", arr));
            return;
        }

        for (int i = 1; i <= arr.Length; i++)
        {
            arr[idx] = i;
            PrintCombs(idx + 1, arr);
        }
    }
}
