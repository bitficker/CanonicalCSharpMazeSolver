namespace MazeSolver;

class Maze
{
    
    // static string[] Map = {
    //     "#######E##",
    //     "##      ##",
    //     "##S#######"
    // };
    
    static string[] Map = {
        "###   #E##",
        "##  #   ##",
        "##S#######"
    };
    
    private readonly string EscapeSymbol = "E";
    private readonly string WallSymbol = "#";
    
    private Point[] Directions = new[] { new Point() { X = 1, Y = 0 }, new Point() { X = -1, Y = 0 }, new Point() { X = 0, Y = 1 }, new Point() { X = 0, Y = -1 } };
    private List<Point> Seen = new List<Point>(Map.Length * Map[0].Length);
    private List<Point> _path = new List<Point>();
    public List<Point> GetPath() => _path.ToList(); // returns a deep copy (cannot mutate original data)

    public Maze()
    {
        if (Map.Length == 0 || Map[0].Length == 0)
            throw new Exception("Map must have a valid Path");
    }
    public bool FindPath(Point currPoint)
    {
        Console.WriteLine("point: "+ "X:" + currPoint.X + ", " + "Y:" + currPoint.Y);
        // Pre recursion - Base Cases
        
        // 1.
        if (IsOutOfBounds(currPoint))
            return false;
        
        // Extracting value from the Map matrix
        var currValuePoint = Map[currPoint.Y][currPoint.X].ToString();
        
        // 2.
        if (currValuePoint == WallSymbol)
            return false;
        
        // Seen
        var isSeen = Seen.Exists(p => p == currPoint);  
        if (isSeen)
            return false;
        
        _path.Add(currPoint); Seen.Add(currPoint);
        
        // 3. 
        if (currValuePoint == EscapeSymbol)
            return true;
        
        // Recursion itself
        foreach (var direction in Directions)
        {
            var escaped = FindPath(new Point() { X = currPoint.X + direction.X, Y = currPoint.Y + direction.Y });

            if (escaped)
                return true;
        }
        
        // Post recursion
        _path.RemoveAt(_path.Count -1);
        
        return false;
    }

    private static int GetXLength() => ( Map[0].Length - 1 );
    
    private bool IsOutOfBounds(Point point) => ((point.X < 0 || point.X > GetXLength()) || (point.Y < 0 || point.Y > Map.Length -1));
    public void PrintPath()
    {
        Console.WriteLine("-----------");
        Console.WriteLine("PrintPath\n");
        foreach (var p in _path)
        { 
            Console.WriteLine("point: "+ "X:" + p.X + ", " + "Y:" + p.Y);
        } 
        
        Console.WriteLine("-----------");
    }
}