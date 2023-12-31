﻿using Simbirsoft.Hakaton.ProjectD.Persistence.Configurations;
using Simbirsoft.Hakaton.ProjectD.Simulator.Map.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Map.Generators;

internal class EllerGenerator
{
    private readonly Random Rand;
    private readonly GameConfiguration GameConfiguration;
    private readonly int _kVertical;
    private readonly int _kHorizontal;
    
    public EllerGenerator(int kVertical, int kHorizontal)
    {
        Rand = new Random();
        _kVertical = kVertical;
        _kHorizontal = kHorizontal;
    }

    private bool ShouldAddVWall()
    {
        return Rand.Next(10) > _kVertical;
    }

    private bool ShouldAddHWall()
    {
        return Rand.Next(10) > _kHorizontal;
    }

    public async Task<Maze> GenerateMaze(byte x, byte y)
    {
        var cells = new Cell[x * y];
        var nums = new byte [x * y];

        byte counter = 1;
        var scores = new byte[x * y];

        for (byte i = 0; i < y; i++)
        {
            if (i > 0)
            {
                for (byte j = 0; j < x; j++)
                {
                    var currentIndex = i * x + j;
                    var lastRowIndex = (i - 1) * y + j;

                    nums[currentIndex] = nums[lastRowIndex];

                    var lastRowCell = cells[lastRowIndex];
                    if (lastRowCell.Bottom)
                    {
                        nums[currentIndex] = 0;
                    }
                }
            }

            for (byte j = 0; j < x; j++)
            {
                var currentIndex = i * x + j;

                if (nums[currentIndex] == 0)
                {
                    nums[currentIndex] = counter;
                    scores[counter]++;

                    counter++;
                }

                cells[currentIndex] = new Cell(j, i);
            }

            for (byte j = 0; j < x - 1; j++)
            {
                var currentIndex = i * x + j;
                var d = ShouldAddVWall();

                if (d || nums[currentIndex] == nums[currentIndex + 1])
                {
                    cells[currentIndex].Right = true;
                }
                else
                {
                    scores[nums[currentIndex]]++;
                    scores[nums[currentIndex + 1]]--;
                    nums[currentIndex + 1] = nums[currentIndex];
                }
            }

            cells[i * x + (x - 1)].Right = true;

            for (byte j = 0; (j < x) & (i < y - 1); j++)
            {
                var currentIndex = i * x + j;
                var currentScore = nums[currentIndex];
                if (scores[currentScore] > 1)
                {
                    var d = ShouldAddHWall();

                    if (d && LowSpacesLeft(cells, nums, currentScore, i * x, x))
                    {
                        cells[currentIndex].Bottom = true;
                    }
                }
            }

            if (i == y - 1)
            {
                for (byte j = 0; j < x - 1; j++)
                {
                    var currentIndex = i * x + j;

                    cells[currentIndex].Bottom = true;

                    if (nums[currentIndex] != nums[currentIndex + 1])
                    {
                        cells[currentIndex].Right = false;
                        scores[nums[currentIndex]]++;
                        scores[nums[currentIndex + 1]]--;
                        nums[currentIndex + 1] = nums[currentIndex];
                    }
                }

                cells[i * x + (x - 1)].Bottom = true;
            }
        }

        var maze = new Maze { X = x, Y = y, Cells = cells };

        return maze;
    }

    private bool LowSpacesLeft(Cell[] cells, byte[] nums, byte score, int lineOffset, byte x)
    {
        byte occur = 0;
        byte borders = 0;

        for (byte j = 0; j < x; j++)
        {
            if (nums[lineOffset + j] == score)
            {
                occur++;

                if (cells[lineOffset + j].Bottom)
                {
                    borders++;
                }
            }
        }

        return occur > borders + 1;
    }
}