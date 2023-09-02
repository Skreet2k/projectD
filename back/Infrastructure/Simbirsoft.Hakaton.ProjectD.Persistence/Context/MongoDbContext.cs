using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities;
using Simbirsoft.Hakaton.ProjectD.Persistence.Configurations;

// ReSharper disable AssignNullToNotNullAttribute

namespace Simbirsoft.Hakaton.ProjectD.Persistence.Context;

/// <summary>
/// Контекст БД.
/// </summary>
public class MongoDbContext
{
    // collections
    private readonly Dictionary<string, string> _collectionNames = new()
    {
        { typeof(TestEntity).FullName, "testEntity" }
    };

    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDbConfig> options)
    {
        //Переключение именования столбцов с Pascal на camel.
        var conventionPack = new ConventionPack
        {
            new CamelCaseElementNameConvention(),
            new EnumRepresentationConvention(BsonType.String)
        };

        ConventionRegistry.Register("camelCase", conventionPack, t => true);

        if (BsonSerializer.LookupSerializer<DateTimeOffsetSerializer>() == null)
        {
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.Document));
        }

        ModelConfiguration.Configure();

        var client = new MongoClient(options.Value.ConnectionString);
        _database = client.GetDatabase(options.Value.Name);
    }

    /// <summary>
    /// Получить коллекцию.
    /// </summary>
    public IMongoCollection<T> GetCollection<T>() where T : BaseEntity
    {
        var typeName = typeof(T).FullName;
        var collectionName = _collectionNames.FirstOrDefault(x => x.Key == typeName).Value;

        if (collectionName == null)
        {
            throw new NotSupportedException($"Entity with type '{typeName}' not supported");
        }

        return _database.GetCollection<T>(collectionName);
    }
}