using System;
using AnimalsLibrary;
using AnimalsLibrary.HerboAnimals;
using AnimalsLibrary.PredatorAnimals;
using Places;
using ThingsLibrary;
using ThingsLibrary.SomeThings;

namespace ZooApp.Methods
{
    /// <summary>
    /// Класс, содержащий методы для получения типов животных и вещей, а также другие вспомогательные функции.
    /// </summary>
    public class Methods
    {
        /// <summary>
        /// Перечисление типов животных.
        /// </summary>
        public enum AnimalType
        {
            /// <summary>
            /// Обезьяна.
            /// </summary>
            Monkey,

            /// <summary>
            /// Кролик.
            /// </summary>
            Rabbit,

            /// <summary>
            /// Тигр.
            /// </summary>
            Tiger,

            /// <summary>
            /// Волк.
            /// </summary>
            Wolf
        }

        /// <summary>
        /// Перечисление типов вещей.
        /// </summary>
        public enum ThingType
        {
            /// <summary>
            /// Компьютер.
            /// </summary>
            Computer,

            /// <summary>
            /// Стол.
            /// </summary>
            Table
        }

        /// <summary>
        /// Запрашивает у пользователя тип животного и возвращает выбранный тип.
        /// </summary>
        /// <returns>Тип выбранного животного.</returns>
        /// <exception cref="InvalidOperationException">Выбрасывается, если пользователь выбирает номер, которого нет в списке.</exception>
        public static AnimalType GetAnimalType()
        {
            Console.Clear();
            Colors.PrintLine("Тип животного:", Colors.ConsoleColorType.Cyan);
            Console.WriteLine("1. Обезьяна");
            Console.WriteLine("2. Кролик");
            Console.WriteLine("3. Тигр");
            Console.WriteLine("4. Волк");

            return Input.GetIntInput("Выберите тип: ", 1, 4) switch
            {
                1 => AnimalType.Monkey,
                2 => AnimalType.Rabbit,
                3 => AnimalType.Tiger,
                4 => AnimalType.Wolf,
                _ => throw new InvalidOperationException("Животного под таким номером нет в списке, выберите другого.")
            };
        }

        /// <summary>
        /// Запрашивает у пользователя тип вещи и возвращает выбранный тип.
        /// </summary>
        /// <returns>Тип выбранной вещи.</returns>
        /// <exception cref="InvalidOperationException">Выбрасывается, если пользователь выбирает номер, которого нет в списке.</exception>
        public static ThingType GetThingType()
        {
            Console.Clear();
            Colors.PrintLine("Тип вещи:", Colors.ConsoleColorType.Cyan);
            Console.WriteLine("1. Компьютер");
            Console.WriteLine("2. Стол");

            return Input.GetIntInput("Выберите тип: ", 1, 2) switch
            {
                1 => ThingType.Computer,
                2 => ThingType.Table,
                _ => throw new InvalidOperationException("Вещи под таким номером нет в списке, выберите другую.")
            };
        }
    }
}
