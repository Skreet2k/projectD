using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities;

namespace Simbirsoft.Hakaton.ProjectD.Persistence.Configurations;

/// <summary>
/// Конфигурация моделей.
/// </summary>
public static class TestEntityConfiguration
{
    public static void Add()
    {
        BsonClassMap.RegisterClassMap<BaseEntity>(cm =>
        {
            cm.AutoMap();
            cm.SetIdMember(cm.GetMemberMap(c => c.Id));
            cm.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId))
                .SetIdGenerator(StringObjectIdGenerator.Instance);
        });

        BsonClassMap.RegisterClassMap<TestEntity>(cm => { cm.AutoMap(); });
    }
}