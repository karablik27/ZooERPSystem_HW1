using System;
using Places;

namespace ZooApp.Methods
{
    /// <summary>
    /// Класс, предоставляющий методы для получения ввода от пользователя.
    /// </summary>
    public class Input
    {
        /// <summary>
        /// Перечисление типов номеров, которые могут быть использованы для животных или вещей.
        /// </summary>
        public enum NumberType
        {
            /// <summary>
            /// Тип для животных.
            /// </summary>
            Animal,

            /// <summary>
            /// Тип для вещей.
            /// </summary>
            Thing
        }

        /// <summary>
        /// Получает целое число от пользователя в заданном диапазоне.
        /// </summary>
        /// <param name="str">Строка, которая будет отображена перед запросом ввода.</param>
        /// <param name="min">Минимальное значение для ввода.</param>
        /// <param name="max">Максимальное значение для ввода.</param>
        /// <returns>Целое число, введенное пользователем, в пределах от <paramref name="min"/> до <paramref name="max"/>.</returns>
        public static int GetIntInput(string str, int min, int max)
        {
            while (true)
            {
                Colors.Print(str, Colors.ConsoleColorType.Cyan);
                if (int.TryParse(Console.ReadLine(), out int result) && result >= min && result <= max)
                {
                    return result;
                }

                Colors.PrintLine($"Ошибка: введите число от {min} до {max}", Colors.ConsoleColorType.Red);
            }
        }

        /// <summary>
        /// Получает уникальный номер от пользователя, проверяя, не занят ли этот номер в зоопарке.
        /// </summary>
        /// <param name="prompt">Строка, которая будет отображена перед запросом ввода.</param>
        /// <param name="zoo">Зоопарк, в котором проверяется уникальность номера.</param>
        /// <param name="type">Тип номера (для животного или вещи).</param>
        /// <param name="min">Минимальное значение для номера.</param>
        /// <param name="max">Максимальное значение для номера.</param>
        /// <returns>Уникальный номер, введенный пользователем.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если тип номера неизвестен.</exception>
        public static int GetUniqueNumber(string prompt, Zoo zoo, NumberType type, int min, int max)
        {
            while (true)
            {
                int number = GetIntInput(prompt, min, max);

                bool isUsed = type switch
                {
                    NumberType.Animal => zoo.IsAnimalNumberUsed(number),
                    NumberType.Thing => zoo.IsThingNumberUsed(number),
                    _ => throw new ArgumentException("Неизвестный тип")
                };

                if (!isUsed) return number;

                string entity = type == NumberType.Animal ? "животным" : "вещью";
                Colors.PrintLine($"Номер {number} уже занят {entity}!", Colors.ConsoleColorType.Red);
            }
        }

        /// <summary>
        /// Получает от пользователя ответ в формате 'y' (да) или 'n' (нет).
        /// </summary>
        /// <param name="prompt">Строка, которая будет отображена перед запросом ввода.</param>
        /// <returns>Возвращает true, если пользователь ввел 'y', иначе false.</returns>
        public static bool GetYesNo(string prompt)
        {
            while (true)
            {
                Colors.Print(prompt, Colors.ConsoleColorType.Cyan);
                string input = Console.ReadLine()?.Trim().ToLower();

                if (input == "y" || input == "n")
                {
                    return input == "y";
                }

                Colors.PrintLine("Ошибка: введите только 'y' или 'n'!", Colors.ConsoleColorType.Red);
            }
        }
    }
}
