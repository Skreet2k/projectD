using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;
using Skreet2k.Common.Models;

namespace Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Map;

public interface IMapGenerator
{
    /// <summary>
    /// Получить карту с путём по заданным параметрам.
    /// </summary>
    /// <param name="width">Ширина.</param>
    /// <param name="height">Длина,</param>
    /// <param name="startCoordinate">Кордината ачала пути по оси X.</param>
    /// <param name="finishCoordinate">Конец пути.</param>
    /// <param name="startX">Кордината начала пути по оси X.</param>
    /// <param name="startY">Кордината начала пути по оси Y.</param>
    /// <param name="finishX">Кордината конца пути по оси X.</param>
    /// <param name="finishY">Кордината конца пути по оси Y.</param>
    /// <param name="counter">Костыльный счётчик.</param>
    /// <returns>Карта с путём.</returns>
    Task<Result<MapDto>> GenerateMapAsync(byte width, byte height, byte startX, byte startY,
        byte finishX, byte finishY, int counter = 0);
}