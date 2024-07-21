using System.Security.Cryptography;

public class Program
{
    private static char[,] graph;
    private static bool[,] visited;
    private static IDictionary<char, int> areas;
    public static void Main(string[] args)
    {
        var rows = int.Parse(Console.ReadLine());
        var cols = int.Parse(Console.ReadLine());

        graph = new char[rows, cols];
        visited = new bool[rows, cols];
        areas = new Dictionary<char, int>();

        for (int r = 0; r < rows; r++)
        {
            var rowElements = Console.ReadLine();

            for (int c = 0; c < cols; c++)
            {
                graph[r, c] = rowElements[c];
            }
        }

        var areasCount = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c= 0; c < cols; c++)
            {
                if (visited[r, c])
                {
                    continue;
                }

                var nodeValue = graph[r, c];
                DFS(r, c, nodeValue);

                areasCount++;

                if (areas.ContainsKey(nodeValue))
                {
                    areas[nodeValue] += 1;
                }
                else
                {
                    areas[nodeValue] = 1;
                }
            }
        }

        Console.WriteLine($"Areas: {areasCount}");

        foreach (var kvp in areas.OrderBy(x => x.Key))
        {
            Console.WriteLine($"Letter '{kvp.Key}' -> {kvp.Value}");
        }
    }

    private static void DFS(int row, int col, char parentNode)
    {
        if (row < 0 || row >= graph.GetLength(0) || col < 0 || col >= graph.GetLength(1))
        {
            return;
        }

        if (visited[row, col])
        {
            return;
        }

        if (graph[row, col] != parentNode)
        {
            return;
        }

        visited[row, col] = true;

        DFS(row, col - 1, parentNode );
        DFS(row, col + 1, parentNode );
        DFS(row + 1, col, parentNode );
        DFS(row - 1, col, parentNode );

    }
}