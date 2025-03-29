using System;

namespace apbd_cw2
{
    internal class Program
    {
        static Ship ship1 = new Ship("Statek1", 10, 5, 10);
        static Ship ship2 = new Ship("Statek2", 15, 5, 12);

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Dodaj kontener (Liquid/Gas/Refrigerated)");
                Console.WriteLine("2. Załaduj kontener");
                Console.WriteLine("3. Rozładuj kontener");
                Console.WriteLine("4. Usuń kontener ze statku");
                Console.WriteLine("5. Zamień kontenery na statku");
                Console.WriteLine("6. Przenieś kontener z jednego statku na drugi");
                Console.WriteLine("7. Wyświetl informacje o statkach");
                Console.WriteLine("0. Wyjście");
                Console.Write("Wybierz opcję: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddContainerMenu();
                        break;
                    case "2":
                        LoadContainerMenu();
                        break;
                    case "3":
                        UnloadContainerMenu();
                        break;
                    case "4":
                        RemoveContainerMenu();
                        break;
                    case "5":
                        SwapContainersMenu();
                        break;
                    case "6":
                        MoveContainerMenu();
                        break;
                    case "7":
                        PrintShipInfo();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja.\n");
                        break;
                }
            }
        }

        static void AddContainerMenu()
        {
            Console.WriteLine("Wybierz statek (1 lub 2): ");
            string shipChoice = Console.ReadLine();
            Ship ship = (shipChoice == "1") ? ship1 : ship2;

            Console.WriteLine("Wybierz typ kontenera: ");
            Console.WriteLine("1 - Liquid");
            Console.WriteLine("2 - Gas");
            Console.WriteLine("3 - Refrigerated");
            string typeChoice = Console.ReadLine();

            try
            {
                switch (typeChoice)
                {
                    case "1":
                        Console.Write("Czy niebezpieczny? (true/false): ");
                        bool hazardous = bool.Parse(Console.ReadLine());
                        Console.Write("MaxCapacity (kg): ");
                        double maxCapL = double.Parse(Console.ReadLine());
                        Console.Write("OwnWeight (kg): ");
                        double ownWeightL = double.Parse(Console.ReadLine());
                        Console.Write("Height (cm): ");
                        double heightL = double.Parse(Console.ReadLine());
                        Console.Write("Depth (cm): ");
                        double depthL = double.Parse(Console.ReadLine());
                        LiquidContainer liquid = new LiquidContainer(hazardous, maxCapL, ownWeightL, heightL, depthL);
                        ship.AddContainer(liquid);
                        Console.WriteLine($"Dodano kontener {liquid.SerialNumber}\n");
                        break;

                    case "2":
                        Console.Write("Ciśnienie (atm): ");
                        double pressure = double.Parse(Console.ReadLine());
                        Console.Write("MaxCapacity (kg): ");
                        double maxCapG = double.Parse(Console.ReadLine());
                        Console.Write("OwnWeight (kg): ");
                        double ownWeightG = double.Parse(Console.ReadLine());
                        Console.Write("Height (cm): ");
                        double heightG = double.Parse(Console.ReadLine());
                        Console.Write("Depth (cm): ");
                        double depthG = double.Parse(Console.ReadLine());
                        GasContainer gas = new GasContainer(pressure, maxCapG, ownWeightG, heightG, depthG);
                        ship.AddContainer(gas);
                        Console.WriteLine($"Dodano kontener {gas.SerialNumber}\n");
                        break;

                    case "3":
                        Console.Write("Rodzaj produktu: ");
                        string product = Console.ReadLine();
                        Console.Write("Temperatura (°C): ");
                        double temp = double.Parse(Console.ReadLine());
                        Console.Write("MaxCapacity (kg): ");
                        double maxCapR = double.Parse(Console.ReadLine());
                        Console.Write("OwnWeight (kg): ");
                        double ownWeightR = double.Parse(Console.ReadLine());
                        Console.Write("Height (cm): ");
                        double heightR = double.Parse(Console.ReadLine());
                        Console.Write("Depth (cm): ");
                        double depthR = double.Parse(Console.ReadLine());
                        RefrigeratedContainer refc = new RefrigeratedContainer(product, temp, maxCapR, ownWeightR, heightR, depthR);
                        ship.AddContainer(refc);
                        Console.WriteLine($"Dodano kontener {refc.SerialNumber}\n");
                        break;

                    default:
                        Console.WriteLine("Nieprawidłowy typ.\n");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}\n");
            }
        }

        static void LoadContainerMenu()
        {
            Console.WriteLine("Wybierz statek (1 lub 2): ");
            string shipChoice = Console.ReadLine();
            Ship ship = (shipChoice == "1") ? ship1 : ship2;

            Console.Write("Podaj numer kontenera: ");
            string serial = Console.ReadLine();
            Console.Write("Podaj masę do załadowania (kg): ");
            double massToLoad = double.Parse(Console.ReadLine());

            try
            {
                BaseContainer container = ship.GetContainerBySerial(serial);
                if (container == null)
                {
                    Console.WriteLine("Nie znaleziono kontenera.\n");
                }
                else
                {
                    container.Load(massToLoad);
                    Console.WriteLine($"Załadowano {massToLoad} kg do kontenera {container.SerialNumber}\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}\n");
            }
        }

        static void UnloadContainerMenu()
        {
            Console.WriteLine("Wybierz statek (1 lub 2): ");
            string shipChoice = Console.ReadLine();
            Ship ship = (shipChoice == "1") ? ship1 : ship2;

            Console.Write("Podaj numer kontenera: ");
            string serial = Console.ReadLine();
            BaseContainer container = ship.GetContainerBySerial(serial);
            if (container == null)
            {
                Console.WriteLine("Nie znaleziono kontenera.\n");
                return;
            }
            container.Unload();
            Console.WriteLine($"Rozładowano kontener {container.SerialNumber}\n");
        }

        static void RemoveContainerMenu()
        {
            Console.WriteLine("Wybierz statek (1 lub 2): ");
            string shipChoice = Console.ReadLine();
            Ship ship = (shipChoice == "1") ? ship1 : ship2;

            Console.Write("Podaj numer kontenera do usunięcia: ");
            string serial = Console.ReadLine();

            try
            {
                ship.RemoveContainer(serial);
                Console.WriteLine($"Usunięto kontener {serial}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}\n");
            }
        }

        static void SwapContainersMenu()
        {
            Console.WriteLine("Wybierz statek (1 lub 2): ");
            string shipChoice = Console.ReadLine();
            Ship ship = (shipChoice == "1") ? ship1 : ship2;

            Console.Write("Podaj numer pierwszego kontenera: ");
            string serialA = Console.ReadLine();
            Console.Write("Podaj numer drugiego kontenera: ");
            string serialB = Console.ReadLine();

            try
            {
                ship.SwapContainers(serialA, serialB);
                Console.WriteLine("Zamieniono kontenery.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}\n");
            }
        }

        static void MoveContainerMenu()
        {
            Console.WriteLine("Wybierz statek źródłowy (1 lub 2): ");
            string fromChoice = Console.ReadLine();
            Ship fromShip = (fromChoice == "1") ? ship1 : ship2;

            Console.WriteLine("Wybierz statek docelowy (1 lub 2): ");
            string toChoice = Console.ReadLine();
            Ship toShip = (toChoice == "1") ? ship1 : ship2;

            if (fromShip == toShip)
            {
                Console.WriteLine("Statek źródłowy i docelowy są takie same.\n");
                return;
            }

            Console.Write("Podaj numer kontenera: ");
            string serial = Console.ReadLine();

            try
            {
                fromShip.MoveContainerToAnotherShip(serial, toShip);
                Console.WriteLine($"Przeniesiono kontener {serial} ze statku {fromShip.Name} na {toShip.Name}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}\n");
            }
        }

        static void PrintShipInfo()
        {
            ship1.PrintInfo();
            ship2.PrintInfo();
        }
    }
}
