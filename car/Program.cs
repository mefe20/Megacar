using System;

class Car
{
    public string Марка { get; private set; }
    public string Модель { get; private set; }
    public string Номер { get; private set; }
    public string Цвет { get; private set; }

    private bool заведена = false;
    private int скорость = 0;
    private int передача = 0;

    public Car(string марка, string модель, string номер, string цвет)
    {
        Марка = марка;
        Модель = модель;
        Номер = номер;
        Цвет = цвет;
    }

    public void Завести()
    {
        if (передача == 0 || передача == 1)
        {
            заведена = true;
            Console.WriteLine($"{Марка} {Модель} завелась.");
        }
        else
        {
            Console.WriteLine("Невозможно завести машину на этой передаче.");
        }
    }

    public void Заглушить()
    {
        заведена = false;
        скорость = 0;
        Console.WriteLine($"{Марка} {Модель} остановилась.");
    }

    public void Газ()
    {
        if (!заведена || передача == 0)
        {
            Console.WriteLine("Невозможно увеличить скорость.");
            return;
        }

        if ((передача == 1 && скорость < 30) ||
            (передача == 2 && скорость < 50) ||
            (передача == 3 && скорость < 70) ||
            (передача == 4 && скорость < 90) ||
            (передача == 5 && скорость < 120))
        {
            скорость += 10;
            Console.WriteLine($"Скорость: {скорость} км/ч");
        }
        else
        {
            Console.WriteLine("Максимальная скорость для текущей передачи достигнута.");
        }
    }

    public void Тормоз()
    {
        if (скорость > 0)
        {
            скорость -= 10;
            Console.WriteLine($"Скорость: {скорость} км/ч");
        }
        else
        {
            Console.WriteLine("Машина уже стоит на месте.");
        }
    }

    public void ПереключитьПередачу(int новаяПередача)
    {
        if (новаяПередача < 0 || новаяПередача > 5)
        {
            Console.WriteLine("Недопустимая передача.");
            return;
        }

        if ((новаяПередача == 1 && скорость <= 30) ||
            (новаяПередача == 2 && скорость >= 20 && скорость <= 50) ||
            (новаяПередача == 3 && скорость >= 40 && скорость <= 70) ||
            (новаяПередача == 4 && скорость >= 60 && скорость <= 90) ||
            (новаяПередача == 5 && скорость >= 80) ||
            (новаяПередача == 0))
        {
            передача = новаяПередача;
            Console.WriteLine($"Передача переключена на {передача}");
        }
        else
        {
            Console.WriteLine("Невозможно переключить на данную передачу при текущей скорости.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car[] машины = {
            new Car("ВАЗ", "2043", "Аs3221", "РОЗОВЫЙ"),
            new Car("Mercedes", "666", "AS2323", "РОЗОВЕНЬКИЙ"),
        };

        Console.WriteLine("Выберите машину:");
        for (int i = 0; i < машины.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {машины[i].Марка} {машины[i].Модель}");
        }

        int выбор = Convert.ToInt32(Console.ReadLine()) - 1;
        Car выбраннаяМашина = машины[выбор];

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Завести машину");
            Console.WriteLine("2. Заглушить машину");
            Console.WriteLine("3. Газануть");
            Console.WriteLine("4. Притормозить");
            Console.WriteLine("5. Переключить передачу");
            Console.WriteLine("6. Выйти");

            int действие = Convert.ToInt32(Console.ReadLine());

            switch (действие)
            {
                case 1:
                    выбраннаяМашина.Завести();
                    break;
                case 2:
                    выбраннаяМашина.Заглушить();
                    break;
                case 3:
                    выбраннаяМашина.Газ();
                    break;
                case 4:
                    выбраннаяМашина.Тормоз();
                    break;
                case 5:
                    Console.WriteLine("Выберите передачу (0-5):");
                    int передача = Convert.ToInt32(Console.ReadLine());
                    выбраннаяМашина.ПереключитьПередачу(передача);
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Неверный выбор, от 0 до 5.");
                    break;
            }
        }
    }
}
