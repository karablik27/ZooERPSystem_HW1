using System;
using Interfaces;

namespace ThingsLibrary
{
    /// <summary>
    /// Класс, представляющий вещь в зоопарке.
    /// Реализует интерфейс <see cref="IInventory"/>.
    /// </summary>
    public class Thing : IInventory
    {
        /// <summary>
        /// Номер вещи.
        /// </summary>
        public int Number { get; }

        /// <summary>
        /// Инициализирует новый экземпляр вещи с указанным номером.
        /// </summary>
        /// <param name="number">Номер вещи. Не может быть меньше 0.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если номер меньше 0.</exception>
        protected Thing(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Колличество вещей не может быть меньше 0.");
            }

            Number = number;
        }

        /// <summary>
        /// Возвращает строковое представление вещи с указанием ее типа и номера.
        /// </summary>
        /// <returns>Строковое представление вещи.</returns>
        public override string ToString()
        {
            return $"{GetType().Name} #{Number}";
        }
    }
}
