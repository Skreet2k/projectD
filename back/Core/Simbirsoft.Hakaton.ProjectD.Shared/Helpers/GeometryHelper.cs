namespace Simbirsoft.Hakaton.ProjectD.Shared.Helpers;

public static class GeometryHelper
{
    /// <summary>
    /// Входит ли целевая точка в радиус исходной окружности.
    /// </summary>
    /// <param name="sourceX">Центр окружности X.</param>
    /// <param name="sourceY">Центр окружности по Y.</param>
    /// <param name="range">Радиус окружности.</param>
    /// <param name="targetX">Координата целевой точки по X.</param>
    /// <param name="targetY">Координата целевой точки по Y.</param>
    /// <returns>Точка входит в радиус окружности.</returns>
    public static bool IsInRange(int sourceX, int sourceY, int range, int targetX, int targetY)
    {
        var targetRadius = Math.Sqrt(Math.Pow(targetX - sourceX, 2) + Math.Pow(targetY - sourceY, 2));

        return range >= targetRadius;
    }
}