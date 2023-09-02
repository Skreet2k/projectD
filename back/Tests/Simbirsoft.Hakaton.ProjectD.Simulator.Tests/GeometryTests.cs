using Simbirsoft.Hakaton.ProjectD.Shared.Helpers;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Tests;

public class GeometryTests
{
    [Theory]
    [InlineData(0, 0, 2, 1, 1)]
    [InlineData(1, 1, 2, 2, 2)]
    [InlineData(2, 2, 2, 1, 1)]
    public void Target_IsInRangeRange(int sourceX, int sourceY, int range, int targetX, int targetY)
    {
        var isInRange = GeometryHelper.IsInRange(sourceX, sourceY, range, targetX, targetY);

        Assert.True(isInRange);
    }

    [Theory]
    [InlineData(0, 0, 2, 2, 2)]
    [InlineData(1, 1, 2, 3, 3)]
    [InlineData(-1, -1, 2, 3, 3)]
    [InlineData(3, 3, 2, 0, 0)]
    public void Target_OutOfRange(int sourceX, int sourceY, int range, int targetX, int targetY)
    {
        var isInRange = GeometryHelper.IsInRange(sourceX, sourceY, range, targetX, targetY);

        Assert.False(isInRange);
    }
}