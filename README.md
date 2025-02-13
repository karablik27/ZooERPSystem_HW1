# Зоопарк ERP-система

Это приложение представляет собой систему управления зоопарком, которая включает в себя управление животными, добавление новых животных и контроль их здоровья. Все животные могут быть классифицированы на травоядных и хищников, и система поддерживает добавление вещей в инвентарь зоопарка.

## Как клонировать и запустить

1. Клонируйте репозиторий на свой локальный компьютер:

    ```bash
    git clone https://github.com/karablik27/ZooERPSystem_HW1.git
    ```

2. Откройте проект в **Visual Studio** или в другом C#-совместимом IDE.

3. Скомпилируйте и запустите проект через IDE или используйте команду:

    ```bash
    dotnet run
    ```

4. Следуйте инструкциям в консоли, чтобы добавлять животных, вещи и управлять зоопарком.

## Основные принципы SOLID, применяемые в проекте

### 1. **Принцип единственной ответственности (Single Responsibility Principle)**

Каждый класс в проекте выполняет одну задачу. Например:
- Класс `Herbo` отвечает только за данные травоядных животных.
- Класс `Predator` отвечает только за данные хищных животных.
- Класс `Zoo` управляет коллекциями животных и вещами.

### 2. **Принцип открытости/закрытости (Open/Closed Principle)**

Классы и методы открыты для расширения, но закрыты для изменений. Например:
- Классы животных (`Herbo` и `Predator`) могут быть расширены для добавления новых типов животных, не изменяя существующий код.
- Мы можем добавлять новые типы животных, создавая новые классы, такие как `Monkey` или `Rabbit`, без изменения базовых классов `Herbo` или `Predator`.

### 3. **Принцип подстановки Лисков (Liskov Substitution Principle)**

Объекты производных классов могут быть заменены объектами базовых классов без нарушения корректности программы. Например:
- Мы можем использовать любой объект, который наследуется от `Herbo` или `Predator` в коллекции зоопарка, и система будет работать корректно.

### 4. **Принцип разделения интерфейса (Interface Segregation Principle)**

Мы разделили интерфейсы и классы на несколько меньших и специфичных. Например:
- Интерфейсы, такие как `IInventory`, используются для представления вещей в зоопарке, а классы животных не зависят от интерфейсов, которые им не нужны.

### 5. **Принцип инверсии зависимостей (Dependency Inversion Principle)**

Мы инвертируем зависимости в проекте, например:
- Класс `Zoo` зависит от абстракции `IHealthChecker`, а не от конкретного класса, такого как `VeterinaryClinic`. Это позволяет нам подменить реализацию проверки здоровья животных, не меняя код класса зоопарка.

## Класс `Zoo` и ассоциация с классом ветеринарной клиники

Класс `Zoo` управляет животными и инвентарем. Он имеет ассоциацию с классом `VeterinaryClinic`, который проверяет здоровье новых животных перед их добавлением в коллекцию зоопарка. Класс `Zoo` использует интерфейс `IHealthChecker` для связи с классами, которые проверяют здоровье животных.

