using System;

namespace AnimalsLibrary
{
    /// <summary>
    /// Абстрактный класс, представляющий хищных животных.
    /// Наследуется от класса Animal.
    /// </summary>
    public abstract class Predator : Animal
    {
        /// <summary>
        /// Инициализирует новый объект хищного животного.
        /// </summary>
        /// <param name="food">Количество пищи, необходимое для животного.</param>
        /// <param name="number">Номер животного.</param>
        /// <param name="ishealthy">Состояние здоровья животного.</param>
        protected Predator(int food, int number, bool ishealthy)
            : base(food, number, ishealthy) { }
    }
}
