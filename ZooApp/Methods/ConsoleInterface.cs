using System;
using AnimalsLibrary;
using AnimalsLibrary.HerboAnimals;
using AnimalsLibrary.PredatorAnimals;
using ThingsLibrary.SomeThings;
using Interfaces;
using Places;
using ThingsLibrary;
using static ZooApp.Methods.Methods;

namespace ZooApp.Methods
{
	public class ConsoleInterface
	{
        private readonly Zoo _zoo;


        /// <summary>
        /// Инициализирует новый экземпляр интерфейса консоли с заданным зоопарком.
        /// </summary>
        /// <param name="zoo">Зоопарк, с которым будет взаимодействовать интерфейс.</param>
        public ConsoleInterface(Zoo zoo)
        {
            _zoo = zoo;
        }

        /// <summary>
        /// Запускает консольное меню и обрабатывает выбор пользователя.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                ShowMenu();

                var choice = Input.GetIntInput("> Выберите действие: ", 1, 9); // Измените верхний предел на 8

                switch (choice)
                {
                    case 1:
                        AddAnimal(_zoo);
                        break;
                    case 2:
                        AddThingMenu();
                        break;
                    case 3:
                        ShowFoodReport();
                        break;
                    case 4:
                        ShowContactZoo();
                        break;
                    case 5:
                        ShowInventory();
                        break;
                    case 6:
                        ShowAllAnimals();
                        break;
                    case 7:
                        ShowAllThings();
                        break;
                    case 8:
                        ShowNorms();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                }
            }
        }


        /// <summary>
        /// Добавляет новое животное в зоопарк после ввода пользователем необходимых данных.
        /// </summary>
        /// <param name="zoo">Зоопарк, в который будет добавлено животное.</param>
        private static void AddAnimal(Zoo zoo)
        {
            try
            {
                Console.Clear();
                var type = GetAnimalType();
                var food = Input.GetIntInput("Количество еды (кг/день): ", 0, 100);
                var number = Input.GetUniqueNumber("Инвентарный номер: ", zoo, Input.NumberType.Animal, 1, 9999);
                var healthy = Input.GetYesNo("Животное здорово? (y/n): ");

                Animal animal = type switch
                {
                    AnimalType.Monkey => new Monkey(food, number, healthy,
                        Input.GetIntInput("Уровень доброты (0-10): ", 0, 10)),
                    AnimalType.Rabbit => new Rabbit(food, number, healthy,
                        Input.GetIntInput("Уровень доброты (0-10): ", 0, 10)),
                    AnimalType.Tiger => new Tiger(food, number, healthy),
                    AnimalType.Wolf => new Wolf(food, number, healthy),
                    _ => throw new InvalidOperationException("Ошибка получения животного.")
                };

                var result = zoo.AddAnimal(animal);

                if (result)
                {
                    Colors.PrintLine("Животное добавлено!", Colors.ConsoleColorType.Green);
                }
                else
                {
                    Colors.PrintLine("Отказ: животное нездорово", Colors.ConsoleColorType.Red);
                }
            }
            catch (Exception ex)
            {
                Colors.PrintLine($"Ошибка: {ex.Message}", Colors.ConsoleColorType.Red);
            }
        }

        /// <summary>
        /// Меню для добавления новой вещи в зоопарк.
        /// </summary>
        private void AddThingMenu()
        {
            try
            {
                Console.Clear();
                Colors.PrintLine("\nДобавление вещи:", Colors.ConsoleColorType.Cyan);
                var type = GetThingType();
                var number = Input.GetUniqueNumber("Инвентарный номер: ", _zoo, Input.NumberType.Thing, 1, 9999);

                Thing thing = type switch
                {
                    ThingType.Computer => new Computer(number),
                    ThingType.Table => new Table(number),
                    _ => throw new InvalidOperationException()
                };

                _zoo.AddThing(thing);
                Colors.PrintLine("Вещь успешно добавлена!", Colors.ConsoleColorType.Green);
                Thread.Sleep(1500);
            }
            catch (Exception ex)
            {
                Colors.PrintLine($"Ошибка: {ex.Message}", Colors.ConsoleColorType.Red);
                Thread.Sleep(2000);
            }
        }

        private void ShowAllAnimals()
        {
            Console.Clear();
            Colors.PrintLine("\nСписок всех животных:", Colors.ConsoleColorType.Magenta);
            foreach (var animal in _zoo.GetAllAnimals())
            {
                Colors.PrintLine(animal.ToString(), Colors.ConsoleColorType.White);
            }
            Console.ReadKey();
        }

        private void ShowAllThings()
        {
            Console.Clear();
            Colors.PrintLine("\nСписок всех вещей:", Colors.ConsoleColorType.Cyan);
            foreach (var thing in _zoo.GetAllThings())
            {
                Colors.PrintLine(thing.ToString(), Colors.ConsoleColorType.White);
            }
            Console.ReadKey();
        }

        private void ShowNorms()
        {
            var animalFoodStandards = new Dictionary<string, int>
            {
                { "Обезьяна", 2 },
                { "Кролик", 1 },
                { "Тигр", 8 },
                { "Волк", 4 }
            };

            Console.Clear();
            Colors.PrintLine("\nНормы питания животных (кг/день):", Colors.ConsoleColorType.Cyan);

            foreach (var (animal, food) in animalFoodStandards)
            {
                Colors.PrintLine($"- {animal}: {food}", Colors.ConsoleColorType.White);
            }

            Console.ReadKey();
        }

        private void ShowFoodReport()
        {
            Console.Clear();
            int totalFood = _zoo.CalculateTotalFood();
            Colors.PrintLine($"\nОбщий расход кормов: {totalFood} кг/день", Colors.ConsoleColorType.Yellow);
            Console.ReadKey();
        }

        private void ShowContactZoo()
        {
            Console.Clear();
            var contactAnimals = _zoo.GetContactAnimals();
            Colors.PrintLine("\nЖивотные для контактного зоопарка:", Colors.ConsoleColorType.Magenta);
            foreach (var animal in contactAnimals)
            {
                Colors.PrintLine($"{animal.GetType().Name} #{animal.Number}", Colors.ConsoleColorType.White);
            }
            Console.ReadKey();
        }

        private void ShowInventory()
        {
            Console.Clear();
            var inventory = _zoo.GetAllInventory();
            Colors.PrintLine("\nИнвентаризация:", Colors.ConsoleColorType.Cyan);
            foreach (var item in inventory)
            {
                Colors.PrintLine($"{item.GetType().Name} #{item.Number}", Colors.ConsoleColorType.White);
            }
            Console.ReadKey();
        }

        private void ShowMenu()
        {
            Console.Clear();
            Colors.PrintLine("=== Меню управления зоопарком ===", Colors.ConsoleColorType.Blue);
            Colors.PrintLine("1. Добавить животное", Colors.ConsoleColorType.White);
            Colors.PrintLine("2. Добавить вещь", Colors.ConsoleColorType.White);
            Colors.PrintLine("3. Показать отчет по кормам", Colors.ConsoleColorType.White);
            Colors.PrintLine("4. Список для контактного зоопарка", Colors.ConsoleColorType.White);
            Colors.PrintLine("5. Полная инвентаризация", Colors.ConsoleColorType.White);
            Colors.PrintLine("6. Вывести всех животных", Colors.ConsoleColorType.White);
            Colors.PrintLine("7. Вывести все вещи", Colors.ConsoleColorType.White);
            Colors.PrintLine("8. Показать нормы питания", Colors.ConsoleColorType.White);
            Colors.PrintLine("9. Выход", Colors.ConsoleColorType.White);
        }
    }
}

