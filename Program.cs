 // See https://aka.ms/new-console-template for more information

 using System.Runtime.CompilerServices;

 Console.WriteLine("Training some Recursion");

 class MazeSolver
{
    // E = End
    // S = Start
    static string[] Maze = {
        "#######E##",
        "##      ##",
        "##S####E##"
    };

    private Point[] Directions = new[] { new Point() { X = 1, Y = 0 }, new Point() { X = -1, Y = 0 }, new Point() { X = 0, Y = 1 }, new Point() { X = 0, Y = -1 } };
    
    private Point Start;

    // private readonly string StartSymbol = "S";
    private readonly string EscapeSymbol = "E";
    private readonly string WallSymbol = "#";

    private List<Point> Path = new List<Point>();

    private List<Point> Seen = new List<Point>(Maze.Length * Maze[0].Length);
    public bool FindPath(Point currPoint)
    {
        // Pre recursion
        
        // Base Cases
        
        // 1.
        if (IsOutOfBounds(currPoint))
            return false;
        
        // Extracting value type from the Maze matrix
        var currValuePoint = Maze[currPoint.Y][currPoint.X].ToString();
        
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
        return ((point.X < 0 || point.X >= Maze[point.X].Length) || (point.Y < 0 || point.Y >= Maze.Length));
    }
    
    
}
struct Point
{
    public int X;
    public int Y;
}
 
var start = new Point() { X = 1, Y = 2 };
var mazeSolver = new MazeSolver();


var hasEscaped = mazeSolver.FindPath(currPoint: start);
 
 Console.WriteLine("Has escaped?!" + hasEscaped);

 







