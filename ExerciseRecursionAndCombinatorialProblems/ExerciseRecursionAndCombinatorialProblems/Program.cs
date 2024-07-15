public class Program
{
    public static void Main(string[] args)
    {
        var arr = Console.ReadLine().Split(" ");

        ReverseArr( 0, arr);
    }

    private static void ReverseArr(int idx, string[] arr)
    {
        if (idx >= arr.Length / 2)
        {
            Console.WriteLine(String.Join(" ", arr));
            return;
        }

        Swap(idx, arr.Length - idx - 1, arr);
        ReverseArr(idx + 1, arr);
    }

    private static void Swap(int idx, int v, string[] arr)
    {
        var temp = arr[idx];
        arr[idx] = arr[v];
        arr[v] = temp;
    }
}
