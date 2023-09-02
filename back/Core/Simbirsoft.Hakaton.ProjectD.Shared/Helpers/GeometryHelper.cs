namespace Simbirsoft.Hakaton.ProjectD.Shared.Helpers;

public static class GeometryHelper
{
    public static bool IsInRange(int sourceX, int sourceY, int range, int targetX, int targetY)
    {
        var targetRadius = Math.Sqrt(Math.Pow(targetX - sourceX, 2) + Math.Pow(targetY - sourceY,2));

        return range >= targetRadius;
    }
}