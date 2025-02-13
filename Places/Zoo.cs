using System;
using AnimalsLibrary;
using Interfaces;
using ThingsLibrary;

namespace Places
{
    /// <summary>
    /// Класс, представляющий зоопарк, который управляет животными и вещами.
    /// </summary>
    public class Zoo
    {
        private readonly List<Animal> _animals = new();
        private readonly List<Thing> _things = new();
        private readonly HashSet<int> _animalNumbers = new();
        private readonly HashSet<int> _thingNumbers = new();
        private readonly IHealthChecker _healthChecker;

        /// <summary>
        /// Инициализирует новый экземпляр зоопарка с указанием проверщика здоровья животных.
        /// </summary>
        /// <param name="healthChecker">Проверщик здоровья для животных в зоопарке.</param>
        public Zoo(IHealthChecker healthChecker)
        {
            _healthChecker = healthChecker;
        }

        /// <summary>
        /// Добавляет животное в зоопарк, если оно здорово.
        /// </summary>
        /// <param name="animal">Животное, которое необходимо добавить в зоопарк.</param>
        /// <returns>Возвращает true, если животное успешно добавлено в зоопарк, иначе false.</returns>
        public bool AddAnimal(Animal animal)
        {
            if (_healthChecker.IsHealthy(animal))
            {
                _animals.Add(animal);
                _animalNumbers.Add(animal.Number);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Добавляет вещь в зоопарк.
        /// </summary>
        /// <param name="thing">Вещь, которую необходимо добавить в зоопарк.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если номер вещи уже используется другой вещью.</exception>
        public void AddThing(Thing thing)
        {
            if (_thingNumbers.Contains(thing.Number))
            {
                throw new ArgumentException($"Номер {thing.Number} уже используется вещью!");
            }

            _things.Add(thing);
            _thingNumbers.Add(thing.Number);
        }

        /// <summary>
        /// Рассчитывает общее количество пищи для всех животных в зоопарке.
        /// </summary>
        /// <returns>Общее количество пищи для всех животных.</returns>
        public int CalculateTotalFood() => _animals.Sum(a => a.Food);

        /// <summary>
        /// Возвращает коллекцию животных, которые могут находиться в контактном зоопарке.
        /// </summary>
        /// <returns>Коллекция животных, которые могут находиться в контактном зоопарке.</returns>
        public IEnumerable<Animal> GetContactAnimals() =>
            _animals.OfType<Herbo>().Where(h => h.CanBeInContactZoo);

        /// <summary>
        /// Возвращает все объекты, которые могут быть частью инвентаря (животные и вещи).
        /// </summary>
        /// <returns>Коллекция объектов инвентаря (животных и вещей).</returns>
        public IEnumerable<IInventory> GetAllInventory()
        {
            var result = new List<IInventory>();
            result.AddRange(_animals);
            result.AddRange(_things);
            return result;
        }

        /// <summary>
        /// Возвращает все животные в зоопарке.
        /// </summary>
        /// <returns>Коллекция всех животных в зоопарке.</returns>
        public IEnumerable<Animal> GetAllAnimals() => _animals;

        /// <summary>
        /// Возвращает все вещи в зоопарке.
        /// </summary>
        /// <returns>Коллекция всех вещей в зоопарке.</returns>
        public IEnumerable<Thing> GetAllThings() => _things;

        /// <summary>
        /// Проверяет, используется ли номер для животного.
        /// </summary>
        /// <param name="number">Номер животного.</param>
        /// <returns>Возвращает true, если номер уже используется для животного, иначе false.</returns>
        public bool IsAnimalNumberUsed(int number) => _animalNumbers.Contains(number);

        /// <summary>
        /// Проверяет, используется ли номер для вещи.
        /// </summary>
        /// <param name="number">Номер вещи.</param>
        /// <returns>Возвращает true, если номер уже используется для вещи, иначе false.</returns>
        public bool IsThingNumberUsed(int number) => _thingNumbers.Contains(number);
    }
}
