using System;
using Interfaces;
namespace AnimalsLibrary
{
    /// <summary>
    /// Абстрактный класс, представляющий животное.
    /// Реализует интерфейс IAlive и хранит основные характеристики животного.
    /// </summary>
    public abstract class Animal : IAlive, IInventory
    {

        /* Полей нет, т.к. при использовании автосвойств компилятор автоматически
         Создаёт скрытые поля в памяти, в которых хранятся значения.
         Это позволяет сохранить неизменяемость объекта после его создания.
         Такой подход удобен для внедрения зависимостей (Dependency Injection),
         так как объект можно передавать в контейнер DI без риска изменения его состояний.
        */


        /// <summary>
        /// Свойства животного (колличество съединой еды в кг, порядковый и здоровбе (болен/не болен)).
        /// </summary>
        public int Food { get; }
        public int Number { get; }
        public bool IsHealthy { get; }


        /// <summary>
        /// Конструктор для создания экземпляра животного.
        /// </summary>
        /// <param name="name">Имя животного (не может быть null или пустым).</param>
        /// <param name="food">Количество потребляемой еды в сутки (не может быть отрицательным).</param>
        /// <param name="happiness">Уровень счастья (должен быть в диапазоне от 0 до 10).</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если <paramref name="name"/> пустое или null, 
        /// <paramref name="food"/> отрицательное, 
        /// <paramref name="happiness"/> вне диапазона 0-10.
        /// </exception>
        protected Animal(int food,int number, bool ishealthy)
        {

            if (food < 0)
            {
                throw new ArgumentException("Количество еды не может быть отрицательным.");
            }

            if (number < 0)
            {
                throw new ArgumentException("Порядковый номер животного не может быть отрицательным.");
            }

            Food = food;
            Number = number;
            IsHealthy = ishealthy;
        }

        public override string ToString()
        {
            return $"{GetType().Name} #{Number} | Еда: {Food} кг/день | Здоров: {(IsHealthy ? "Да" : "Нет")}";
        }
    }

}

