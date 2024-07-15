public class Program
{

    public static int size;
    public static List<Area> areas;

    public class Area
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public int Size { get; set; }
    }
    public static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        areas = new List<Area>();

        string[,] matrix = new string[a, b];

        for (int i = 0; i < a; i++)
        {
            var row = Console.ReadLine();

            for (int j = 0; j < b; j++)
            {
                matrix[i, j] = row[j].ToString();
            }
        }

        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                size = 0;
                FindAreas(i, j,matrix);
                if (size > 0)
                {
                    areas.Add(new Area { Row = i, Col = j, Size = size});
                }
                
            }
        }

        var sorted = areas.OrderByDescending(a => a.Size)
            .ThenBy(a => a.Row)
            .ThenBy(a => a.Col)
            .ToList();

        Console.WriteLine($"Total areas found: {areas.Count}");

        for (int i = 0; i < sorted.Count; i++)
        {
            var area = sorted[i];
            Console.WriteLine($"Area #{i + 1} at ({area.Row}, {area.Col}), size: {area.Size}");
        }
    }

    private static void FindAreas(int row, int col, string[,] matrix)
    {
        if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1) || matrix[row, col] == "*" || matrix[row, col] == "v")
        {
            return;
        }

        matrix[row, col] = "v";
        size += 1;

        FindAreas(row + 1, col,matrix);
        FindAreas(row - 1, col,matrix);
        FindAreas(row, col + 1,matrix);
        FindAreas(row, col - 1,matrix);



    }
}
