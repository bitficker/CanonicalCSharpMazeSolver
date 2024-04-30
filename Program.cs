 // See https://aka.ms/new-console-template for more information
 using MazeSolver;

 var start = new Point() { X = 1, Y = 2 };
var mazeSolver = new Maze();

var hasEscaped = mazeSolver.FindPath(currPoint: start);
 
 Console.WriteLine("Has escaped?!" + hasEscaped);

 







