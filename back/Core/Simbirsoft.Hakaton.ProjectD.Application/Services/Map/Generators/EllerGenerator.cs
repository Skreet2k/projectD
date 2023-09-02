using Simbirsoft.Hakaton.ProjectD.Application.Services.Map.Models;

namespace Simbirsoft.Hakaton.ProjectD.Application.Services.Map.Generators;

static class EllerGenerator
{
    private static readonly Random Rand;

    static EllerGenerator()
    {
        Rand = new Random();
    }
    
    private static bool ShouldAddVWall()
    {
        return Rand.Next(10) > 4;
    }
    
    private static bool ShouldAddHWall()
    {
        return Rand.Next(10) > 4;
    }
    
    public static async Task<Maze> GenerateMaze(byte x, byte y)
    {
        Cell[] cells = new Cell[x * y];
        byte[] nums = new byte [x * y];

        byte counter = 1;
        byte[] scores = new byte[x * y];

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
                bool d = ShouldAddVWall();

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

            cells[(i * x) + (x - 1)].Right = true;

            for (byte j = 0; j < x & i < y - 1; j++)
            {
                var currentIndex = i * x + j;
                var currentScore = nums[currentIndex];
                if (scores[currentScore] > 1)
                {
                    bool d = ShouldAddHWall();

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

                cells[(i * x) + (x - 1)].Bottom = true;
            }
        }

        var maze = new Maze { X = x, Y = y, Cells = cells };
        
        return maze;
    }

    private static bool LowSpacesLeft(Cell[] cells, byte[] nums, byte score, int lineOffset, byte x)
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

        return occur > (borders + 1);
    }
}