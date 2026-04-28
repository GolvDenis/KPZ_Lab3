using ClassLibrary1.Task1;
using ClassLibrary1.Task2;
using ClassLibrary1.Task3;
using ClassLibrary1.Task4;
using ClassLibrary1.Task5;
using ClassLibrary1.Task5.Lab4.Task3;
using ClassLibrary1.Task5.Lab4.Task4;
using ClassLibrary1.Task6;
using System.Text;
using System.Threading;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("=== Завдання 1: Adapter ===");

        ILogger consoleLogger = new Logger();
        consoleLogger.Log("Програма запущена");
        consoleLogger.Warn("Це попередження");
        consoleLogger.Error("Це помилка");

        ILogger fileLogger = new FileLoggerAdapter("log.txt");
        fileLogger.Log("Лог у файл");
        fileLogger.Warn("Попередження у файл");
        fileLogger.Error("Помилка у файл");

        Console.WriteLine("Логи записано у файл log.txt");
        Console.WriteLine();

        Console.WriteLine("=== Завдання 2: Decorator ===");

        Hero warrior = new Warrior();
        warrior = new ClothingDecorator(warrior, "Steel Armor", 15);
        warrior = new WeaponDecorator(warrior, "Long Sword", 20);
        warrior = new ArtifactDecorator(warrior, "Ring of Strength", 10, 0);

        Hero mage = new Mage();
        mage = new ArtifactDecorator(mage, "Magic Ring", 5, 20);
        mage = new ArtifactDecorator(mage, "Amulet of Wisdom", 0, 30);
        mage = new ClothingDecorator(mage, "Robe", 3);

        Hero palladin = new Palladin();
        palladin = new ClothingDecorator(palladin, "Holy Armor", 20);
        palladin = new WeaponDecorator(palladin, "Blessed Sword", 15);
        palladin = new ArtifactDecorator(palladin, "Sacred Relic", 25, 10);

        Console.WriteLine(warrior.GetInfo());
        Console.WriteLine(mage.GetInfo());
        Console.WriteLine(palladin.GetInfo());
        Console.WriteLine();

        Console.WriteLine("=== Завдання 3: Bridge ===");

        Shape[] shapes =
        {
                new Circle(new VectorRenderer()),
                new Circle(new RasterRenderer()),
                new Square(new VectorRenderer()),
                new Square(new RasterRenderer()),
                new Triangle(new VectorRenderer()),
                new Triangle(new RasterRenderer())
            };

        foreach (var shape in shapes)
        {
            shape.Draw();
        }

        Console.WriteLine("=== Завдання 4: Proxy ===");

        File.WriteAllText("test.txt", "Привіт\nСвіт!");

        ISmartTextReader reader1 = new SmartTextReaderChecker(new SmartTextReader());
        var text1 = reader1.ReadFile("test.txt");

        Console.WriteLine("Результат SmartTextReaderChecker:");
        foreach (var line in text1)
        {
            Console.WriteLine(new string(line));
        }

        Console.WriteLine();

        ISmartTextReader reader2 = new SmartTextReaderLocker(
            new SmartTextReader(),
            @"secret|private"
        );

        var blocked = reader2.ReadFile("private_file.txt");

        Console.WriteLine();

        Console.WriteLine("=== Завдання 5: Composite ===");

        var page = new LightElementNode(HtmlTagFactory.GetTag("div"), ElementDisplay.Block, ElementClosing.Double, new[] { "container" });

        var title = new LightElementNode(HtmlTagFactory.GetTag("h1"), ElementDisplay.Block, ElementClosing.Double);
        title.AddChild(new LightTextNode("Моя LightHTML сторінка"));

        var list = new LightElementNode(HtmlTagFactory.GetTag("ul"), ElementDisplay.Block, ElementClosing.Double, new[] { "menu" });

        var li1 = new LightElementNode(HtmlTagFactory.GetTag("li"), ElementDisplay.Block, ElementClosing.Double);
        li1.AddChild(new LightTextNode("Головна"));

        var li2 = new LightElementNode(HtmlTagFactory.GetTag("li"), ElementDisplay.Block, ElementClosing.Double);
        li2.AddChild(new LightTextNode("Про нас"));

        var li3 = new LightElementNode(HtmlTagFactory.GetTag("li"), ElementDisplay.Block, ElementClosing.Double);
        li3.AddChild(new LightTextNode("Контакти"));

        list.AddChild(li1);
        list.AddChild(li2);
        list.AddChild(li3);

        page.AddChild(title);
        page.AddChild(list);

        Console.WriteLine("OuterHTML:");
        Console.WriteLine(page.OuterHTML());

        Console.WriteLine();
        Console.WriteLine("InnerHTML:");
        Console.WriteLine(page.InnerHTML());

        Console.WriteLine();
        Console.WriteLine($"Кількість дочірніх елементів: {page.ChildrenCount}");

        Console.WriteLine("=== Завдання 6: Flyweight ===");

        var html = BookToHtmlConverter.Convert("Task6.txt");

        Console.WriteLine("Попередній перегляд HTML:");
        Console.WriteLine(html.OuterHTML().Substring(0, 1000));

        Console.WriteLine();
        Console.WriteLine($"Загальна кількість вузлів: {MemoryHelper.CountNodes(html)}");
        Console.WriteLine($"Унікальні теги (Flyweight): {HtmlTagFactory.Count}");

        Console.WriteLine();
        Console.WriteLine("Готово.");

        Console.WriteLine();

        Console.WriteLine("=== Lab 4 Завдання 3 ===");

        var button = new LightElementNode(
            HtmlTagFactory.GetTag("button"),
            ElementDisplay.Inline,
            ElementClosing.Double,
            new[] { "btn" });

        button.AddChild(new LightTextNode("Натисни мене"));

        var clickListener = new ConsoleEventListener("ClickListener");
        var mouseListener = new ConsoleEventListener("MouseListener");

        button.AddEventListener("click", clickListener);
        button.AddEventListener("mouseover", mouseListener);

        Console.WriteLine(button.OuterHTML());
        Console.WriteLine();

        button.TriggerEvent("mouseover");
        button.TriggerEvent("click");

        Console.WriteLine();

        Console.WriteLine("=== Lab 4 Завдання 4 ===");

        var localImage = new LightImageNode("Lab4_Task4.jpg", "Локальна картинка");
        Console.WriteLine(localImage.OuterHTML());
        Console.WriteLine(localImage.LoadResult);

        Console.WriteLine();

        var webImage = new LightImageNode("https://picsum.photos/200", "З мережі");
        Console.WriteLine(webImage.OuterHTML());
        Console.WriteLine(webImage.LoadResult);
    }
}