﻿using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;
using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Tests;

public class TowerTests
{
    private readonly SimulationModel Map;

    public TowerTests()
    {
        List<FeatureModel> features = new()
        {
            new FeatureModel
            {
                Id = "1",
                Name = "Важный рефакторинг сервиса связи",
                CurrentHealthPoints = 10,
                CurrentCoordinate = new CoordinateDto
                {
                    X = 1, Y = 4
                }
            },
            new FeatureModel
            {
                Id = "2",
                Name = "Срочный фикс модели заказа",
                CurrentHealthPoints = 10,
                CurrentCoordinate = new CoordinateDto
                {
                    X = 4, Y = 1
                }
            },
            new FeatureModel
            {
                Id = "3",
                Name = "Обязательный баг таблицы срочности",
                CurrentHealthPoints = 5,
                CurrentCoordinate = new CoordinateDto
                {
                    X = 5, Y = 4
                }
            }
        };

        var towers = new List<WorkerModel>
        {
            new()
            {
                Id = "1",
                Range = 2,
                DamagePerTick = 1,
                Coordinate = new CoordinateDto
                {
                    X = 0, Y = 5
                }
            },
            new()
            {
                Id = "2",
                Range = 2,
                DamagePerTick = 1,
                Coordinate = new CoordinateDto
                {
                    X = 2, Y = 1
                }
            },
            new()
            {
                Id = "3",
                Range = 2,
                DamagePerTick = 1,
                Coordinate = new CoordinateDto
                {
                    X = 4, Y = 3
                }
            },
            new()
            {
                Id = "4",
                Range = 2,
                DamagePerTick = 1,
                Coordinate = new CoordinateDto
                {
                    X = 7, Y = 0
                }
            }
        };

        Map = new SimulationModel
        {
            Features = features,
            Workers = towers,
            Path = new List<CoordinateDto>(Array.Empty<CoordinateDto>())
        };
    }

    [Fact]
    public void Features_AreDamaged()
    {
        foreach (var worker in Map.Workers)
        {
            worker.Do(Map.Features);
        }

        var task1 = Map.Features.FirstOrDefault(x => x.Id.Equals("1"));
        var task2 = Map.Features.FirstOrDefault(x => x.Id.Equals("2"));
        var task3 = Map.Features.FirstOrDefault(x => x.Id.Equals("3"));

        Assert.Equal(9, task1.CurrentHealthPoints);
        Assert.Equal(9, task2.CurrentHealthPoints);
        Assert.Equal(4, task3.CurrentHealthPoints);
    }
}