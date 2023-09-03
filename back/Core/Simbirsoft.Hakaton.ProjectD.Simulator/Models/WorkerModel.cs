using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;
using Simbirsoft.Hakaton.ProjectD.Shared.Helpers;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Models;

/// <summary>
/// Модель башни/разработчика.
/// </summary>
public class WorkerModel
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Местоположение на карте.
    /// </summary>
    public CoordinateDto Coordinate { get; set; }

    /// <summary>
    /// Радиус поражения.
    /// </summary>
    public int Range { get; set; }

    /// <summary>
    /// ???.
    /// </summary>
    public int Power { get; set; }

    /// <summary>
    /// Текущая цель.
    /// </summary>
    public FeatureModel CurrentTarget { get; set; }

    /// <summary>
    /// Урон в тик.
    /// </summary>
    public int DamagePerTick { get; set; }

    /// <summary>
    /// Стоимость.
    /// </summary>
    public int Cost { get; set; }

    /// <summary>
    /// Здоровье Работника.
    /// </summary>
    public int HealthPoints { get; set; }

    /// <summary>
    /// Симуляция выстрела в тик.
    /// </summary>
    /// <param name="features">Коллекция фич.</param>
    public void Do(IEnumerable<FeatureModel> features)
    {
        DefineTarget(features);

        var damage = CalculateDamage();

        DealDamage(damage);
    }

    /// <summary>
    /// Определяем цель в текущем тике.
    /// </summary>
    /// <param name="features">Список всех Фич.</param>
    private void DefineTarget(IEnumerable<FeatureModel> features)
    {
        // Проверяем, имеется ли уже цель.
        if (CurrentTarget != null)
        {
            // Проверяем, находится ли текущая цель в радиусе поражения.
            if (IsInActionRadius(CurrentTarget))
            {
                // Если текущая цель находится в радиусе поражения, оставляем её.
                return;
            }

            // Если текущая цель вне радиуса поражения, обнуляем.
            CurrentTarget = null;
        }

        // Сортируем фичи по ХП, т.к. в приоритете будут фичи с минимальным ХП.
        var orderedFeatures = features.OrderBy(t => t.CurrentHealthPoints);

        // Проходим по фичам, от самой дохлой до самой здоровой.
        foreach (var feature in orderedFeatures)
        {
            // Проверяем, находится ли фича в радиусе поражения
            if (IsInActionRadius(feature))
            {
                // Если фича в радиусе поражения, берём в цель её.
                CurrentTarget = feature;

                return;
            }
        }
        // Если прошли по всем фичам и не нашли ни одной в радиусе поражения, цель отсутствует.
    }

    /// <summary>
    /// Определяем, входит ли Фича в радиус поражения Работника.
    /// </summary>
    /// <param name="feature"></param>
    /// <returns></returns>
    private bool IsInActionRadius(FeatureModel feature)
    {
        return GeometryHelper.IsInRange(Coordinate.X, Coordinate.Y, Range, feature.CurrentCoordinate.X,
            feature.CurrentCoordinate.Y);
    }

    /// <summary>
    /// Вычисляем наносимый урон.
    /// </summary>
    /// <returns></returns>
    private int CalculateDamage()
    {
        double resultDamage = DamagePerTick;

        // Тут, по идее, надо применить всякие модификаторы.

        return (int)Math.Round(resultDamage);
    }

    /// <summary>
    /// Нанесение урона цели.
    /// </summary>
    /// <param name="damage">Наносимый урон.</param>
    private void DealDamage(int damage)
    {
        CurrentTarget?.ReceiveDamage(damage);
    }
}