namespace Simbirsoft.Hakaton.ProjectD.Domain.Entities.Map;

public class MapEntity : BaseEntity
{
    public byte Width { get; set; }

    public byte Height { get; set; }

    public List<CoordinateEntity> Path { get; set; } = new();
}