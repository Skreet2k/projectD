using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities.Simualation;
using Simbirsoft.Hakaton.ProjectD.Shared.Enums.Workers;

namespace Simbirsoft.Hakaton.ProjectD.Persistence.Configurations;

public class WorkerEntityConfiguration
{
    public static void Add()
    {
        BsonClassMap.RegisterClassMap<WorkerEntity>(cm =>
        {
            cm.AutoMap();
            cm.GetMemberMap(c => c.Type).SetSerializer(new EnumSerializer<WorkerType>(BsonType.String));
            cm.GetMemberMap(c => c.Level).SetSerializer(new EnumSerializer<WorkerLevel>(BsonType.String));
        });
    }
}