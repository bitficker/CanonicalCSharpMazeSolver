using System.ComponentModel;

namespace MazeSolver;

public struct Point : IEquatable<Point>
{
    public int X;
    public int Y;

    public bool Equals(Point other)
    {
        InvalidOperationExceptionHelper.ThownIfNull(other);

        if (this.Y == other.X && this.Y == other.Y)
        {
            return true;
        }

        return false;
    }
    
    public static bool operator == (Point p1, Point p2)
    {
        // if (((object)person1) == null || ((object)person2) == null)
        //     return Object.Equals(person1, person2);
        
        InvalidOperationExceptionHelper.ThownIfNull((object)p1);
        InvalidOperationExceptionHelper.ThownIfNull((object)p2);

        return p1.Equals(p2);
    }
    
    public static bool operator != (Point p1, Point p2)
    {
        // if (((object)person1) == null || ((object)person2) == null)
        //     return ! Object.Equals(person1, person2);
        
        InvalidOperationExceptionHelper.ThownIfNull((object)p1);
        InvalidOperationExceptionHelper.ThownIfNull((object)p2);

        return ! ( p1.Equals(p2) );
    }
    
}