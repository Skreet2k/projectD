﻿using Simbirsoft.Hakaton.ProjectD.Domain.Entities.Map;
using Simbirsoft.Hakaton.ProjectD.Simulator.Map.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Map.Pathfinders;

internal static class CommonPathfinder
{
    public static async Task<List<CoordinateEntity>> FindPath(Maze maze, byte startX, byte startY, byte destX,
        byte destY)
    {
        var path = new List<CoordinateEntity>();

        var reachable = new List<Tuple<byte, byte>>();
        var explored = new List<Tuple<byte, byte>>();

        PathPiece lastVisited = null;
        reachable.Add(new Tuple<byte, byte>(startX, startY));
        do
        {
            PathPiece newVisited;

            var nextToVisit = reachable.Last();
            if (lastVisited != null && lastVisited.X == nextToVisit.Item1 && lastVisited.Y == nextToVisit.Item2)
            {
                newVisited = lastVisited;
            }
            else
            {
                newVisited = new PathPiece(nextToVisit.Item1, nextToVisit.Item2);
                newVisited.Previous = lastVisited;
            }

            if (!explored.Contains(nextToVisit))
                explored.Add(nextToVisit);

            reachable.Remove(nextToVisit);

            var newReachable = GetReachables(maze, nextToVisit)
                .Where(x => !explored.Contains(x));

            if (newReachable.Count() == 0)
            {
                var prevNode = newVisited.Previous;
                reachable.Add(new Tuple<byte, byte>(prevNode.X, prevNode.Y));
                lastVisited = newVisited.Previous;
                //reachable.Add(new Tuple<int, int> (lastVisited.X, lastVisited.Y));
                continue;
            }

            newReachable = newReachable.Where(x => !reachable.Contains(x));

            reachable.AddRange(newReachable);

            lastVisited = newVisited;
        } while (reachable.Count != 0 && !reachable.Any(x => x.Item1 == destX && x.Item2 == destY));

        path.Add(new CoordinateEntity(destX, destY));
        var finalVisited = lastVisited;
        while (finalVisited != null)
        {
            path.Add(new CoordinateEntity(finalVisited.X, finalVisited.Y));
            finalVisited = finalVisited.Previous;
        }

        path.Reverse();

        return path;
    }

    private static List<Tuple<byte, byte>> GetReachables(Maze maze, Tuple<byte, byte> piece)
    {
        var pathPieces = new List<Tuple<byte, byte>>();

        var (x, y) = piece;

        var srcIndex = maze.X * y + x;
        var srcCell = maze.Cells[srcIndex];

        if (x > 0)
        {
            var cell = maze.Cells[srcIndex - 1];
            if (!cell.Right)
            {
                pathPieces.Add(new Tuple<byte, byte>((byte)(x - 1), y));
            }
        }

        if (y > 0)
        {
            var cell = maze.Cells[srcIndex - maze.X];
            if (!cell.Bottom)
            {
                pathPieces.Add(new Tuple<byte, byte>(x, (byte)(y - 1)));
            }
        }

        if (x < maze.X - 1)
        {
            var cell = srcCell;
            if (!cell.Right)
            {
                pathPieces.Add(new Tuple<byte, byte>((byte)(x + 1), y));
            }
        }

        if (y < maze.Y - 1)
        {
            var cell = srcCell;
            if (!cell.Bottom)
            {
                pathPieces.Add(new Tuple<byte, byte>(x, (byte)(y + 1)));
            }
        }

        return pathPieces;
    }
}