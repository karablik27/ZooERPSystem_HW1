using System;

namespace AnimalsLibrary
{
    /// <summary>
    /// Абстрактный класс, представляющий травоядных животных.
    /// Наследуется от класса Animal.
    /// </summary>
    public abstract class Herbo : Animal
    {
        /// <summary>
        /// Уровень доброты животного (от 0 до 10).
        /// </summary>
        public int Kindness { get; }

        /// <summary>
        /// Определяет, можно ли животное держать в контактном зоопарке.
        /// Возвращает true, если уровень доброты больше 5.
        /// </summary>
        public bool CanBeInContactZoo => Kindness > 5;

        /// <summary>
        /// Инициализирует новый объект травоядного животного.
        /// </summary>
        /// <param name="food">Количество пищи, необходимое для животного.</param>
        /// <param name="number">Номер животного.</param>
        /// <param name="ishealthy">Состояние здоровья животного.</param>
        /// <param name="kindness">Уровень доброты животного (от 0 до 10).</param>
        /// <exception cref="ArgumentException">Выбрасывается, если уровень доброты не в пределах от 0 до 10.</exception>
        protected Herbo(int food, int number, bool ishealthy, int kindness)
            : base(food, number, ishealthy)
        {
            if (kindness < 0 || kindness > 10)
            {
                throw new ArgumentException("Уровень доброты должен быть в диапазоне от 0 до 10.");
            }

            Kindness = kindness;
        }

        /// <summary>
        /// Возвращает строковое представление объекта.
        /// </summary>
        /// <returns>Строковое представление животного с указанием уровня доброты.</returns>
        public override string ToString()
        {
            return base.ToString() + $" | Доброта: {Kindness}/10";
        }
    }
}
