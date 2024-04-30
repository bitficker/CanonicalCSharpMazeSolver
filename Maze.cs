namespace MazeSolver;

class Maze
{
    // E = End
    // S = Start
    static string[] Map = {
        "#######E##",
        "##      ##",
        "##S####E##"
    };

    private Point[] Directions = new[] { new Point() { X = 1, Y = 0 }, new Point() { X = -1, Y = 0 }, new Point() { X = 0, Y = 1 }, new Point() { X = 0, Y = -1 } };
    
    private Point Start;
    
    private readonly string EscapeSymbol = "E";
    private readonly string WallSymbol = "#";

    private List<Point> Path = new List<Point>();

    private List<Point> Seen = new List<Point>(Map.Length * Map[0].Length);
    public bool FindPath(Point currPoint)
    {
        // Pre recursion
        
        // Base Cases
        
        // 1.
        if (IsOutOfBounds(currPoint))
            return false;
        
        // Extracting value type from the Map matrix
        var currValuePoint = Map[currPoint.Y][currPoint.X].ToString();
        
        // 2.
        // Wall
        if (currValuePoint == WallSymbol)
            return false;
        
        // Seen
        
        // Utilizar IComparer para comparar pontos
        var isSeen = Seen.Exists(p => p.X == currPoint.X && p.Y == currPoint.Y); 
        if (isSeen)
            return false;
        
        Path.Add(currPoint); Seen.Add(currPoint);
        
        // 3. 
        // Escape
        if (currValuePoint == EscapeSymbol)
            return true;
        
        // Recursion
        foreach (var direction in Directions)
        {
            var escaped = FindPath(new Point() { X = currPoint.X + direction.X, Y = currPoint.Y + direction.Y });

            if (escaped)
                return true;
        }
        
        Path.RemoveAt(Path.Count -1);
        
        return false;
        // Post recursion
    }

    private bool IsOutOfBounds(Point point)
    {
        return ((point.X < 0 || point.X >= Map[point.X].Length) || (point.Y < 0 || point.Y >= Map.Length));
    }
    
    
}