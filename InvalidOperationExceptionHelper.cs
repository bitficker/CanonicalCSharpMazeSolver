namespace MazeSolver;

public static class InvalidOperationExceptionHelper
{

    public static object? ThownIfNull(object obj)
    {
        if (obj is null)
            throw new InvalidOperationException("Object must be a valid type");

        return obj;
    }
    
}