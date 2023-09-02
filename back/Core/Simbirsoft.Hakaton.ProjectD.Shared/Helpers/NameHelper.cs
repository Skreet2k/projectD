namespace Simbirsoft.Hakaton.ProjectD.Shared.Helpers;

public static class NameHelper
{
    private static string[] Epithets = { "Срочный", "Важный", "Неотложный", "Нужный", "Обязательный" };
    private static string[] Jobs = { "Рефакторинг", "Фикс", "Анализ", "Баг", "Имплементейшен" };
    private static string[] Entities = { "Класса", "Сервиса", "Модуля", "Проекта", "Таблицы" };
    private static string[] Area = { "Связи", "Заказов", "Очереди", "Пользователей", "Статистики" };
    private static Random _rand = new();

    /// <summary>
    /// Гененирует случайное название.
    /// </summary>
    /// <returns>Название.</returns>
    public static string GenerateFeatureName()
    {
        var epNumber = _rand.Next(Epithets.Length);
        var jNum = _rand.Next(Jobs.Length);
        var enNum = _rand.Next(Entities.Length);
        var aNum = _rand.Next(Area.Length);

        return $"{Epithets[epNumber]} {Jobs[jNum]} {Entities[enNum]} {Area[aNum]}";
    }
}