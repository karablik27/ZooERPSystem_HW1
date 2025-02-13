using Places;
using ZooApp.Methods;
using Microsoft.Extensions.DependencyInjection;

namespace ZooApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Создание контейнера зависимостей, который будет управлять жизненным циклом объектов.
                var services = new ServiceCollection()

                // Регистрация интерфейса IHealthChecker с реализацией VeterinaryClinic как singleton (одиночный экземпляр).
                .AddSingleton<IHealthChecker, VeterinaryClinic>()

                // Регистрация класса Zoo как singleton.
                .AddSingleton<Zoo>()

                // Регистрация класса ConsoleInterface как singleton.
                .AddSingleton<ConsoleInterface>()

                // Создание и конфигурация поставщика сервисов (контейнера).
                .BuildServiceProvider();

                // Получение нужного сервиса (в данном случае ConsoleInterface) из контейнера зависимостей.
                var consoleInterface = services.GetRequiredService<ConsoleInterface>();

                // Запуск интерфейса консоли (взаимодействие с пользователем).
                consoleInterface.Run();

                // Ожидание нажатия клавиши для завершения программы.
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                // В случае ошибки выводим сообщение об исключении красным цветом.
                Colors.PrintLine(ex.Message, Colors.ConsoleColorType.Red);
            }
        }
    }
}
