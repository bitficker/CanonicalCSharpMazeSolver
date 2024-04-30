 // See https://aka.ms/new-console-template for more information
 using MazeSolver;

var mazeSolver = new Maze();

var start = new Point() { X = 2, Y = 2 };

var hasEscaped = mazeSolver.FindPath(currPoint: start);
 
 Console.WriteLine("Has escaped?!" + hasEscaped);

 var path = mazeSolver.GetPath();
 foreach (var p in path) { Console.WriteLine("point: "+ "X:" + p.X + ", " + "Y:" + p.Y); }

 path = new List<Point>();

Console.WriteLine("Empty Path: (?) \n");
foreach (var p in path) { Console.WriteLine("point: "+ "X:" + p.X + ", " + "Y:" + p.Y); }
 
 mazeSolver.PrintPath();

 






