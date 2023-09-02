using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;
using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Tests;

public class TowerTests
{
    private MapModel Map;

    public TowerTests()
    {
        List<FeatureModel> features = new()
        {
            new()
            {
                Id = "1",
                Name = "Важный рефакторинг сервиса связи",
                CurrentHealthPoints = 10,
                CurrentCoordinate = new()
                {
                    X = 1, Y = 4
                }
            },
            new()
            {
                Id = "2",
                Name = "Срочный фикс модели заказа",
                CurrentHealthPoints = 10,
                CurrentCoordinate = new()
                {
                    X = 4, Y = 1
                }
            },
            new()
            {
                Id = "3",
                Name = "Обязательный баг таблицы срочности",
                CurrentHealthPoints = 5,
                CurrentCoordinate = new()
                {
                    X = 5, Y = 4
                }
            }
        };

        var towers = new WorkerModel[]
        {
            new()
            {
                Id = "1",
                Range = 2,
                DamagePerTick = 1,
                Coordinate = new()
                {
                    X = 0, Y = 5
                }
            },
            new()
            {
                Id = "2",
                Range = 2,
                DamagePerTick = 1,
                Coordinate = new()
                {
                    X = 2, Y = 1
                }
            },
            new()
            {
                Id = "3",
                Range = 2,
                DamagePerTick = 1,
                Coordinate = new()
                {
                    X = 4, Y = 3
                }
            },
            new()
            {
                Id = "4",
                Range = 2,
                DamagePerTick = 1,
                Coordinate = new()
                {
                    X = 7, Y = 0
                }
            }
        };

        Map = new MapModel
        {
            Features = features,
            Workers = towers,
            Path = Array.Empty<CoordinateDto>()
        };
    }

    [Fact]
    public void Features_AreDamaged()
    {
        foreach (var worker in Map.Workers)
        {
            worker.Fire(Map.Features);
        }

        var task1 = Map.Features.FirstOrDefault(x => x.Id.Equals("1"));
        var task2 = Map.Features.FirstOrDefault(x => x.Id.Equals("2"));
        var task3 = Map.Features.FirstOrDefault(x => x.Id.Equals("3"));
        
        Assert.Equal(9, task1.CurrentHealthPoints);
        Assert.Equal(9, task2.CurrentHealthPoints);
        Assert.Equal(4, task3.CurrentHealthPoints);
    }
}