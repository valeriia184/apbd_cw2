using System;
using ContainersApp;

namespace apbd_cw2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ship ship1 = new Ship("Statek1", 10, 3, 10);
            LiquidContainer liquid1 = new LiquidContainer(true, 1000, 300, 200, 150);
            GasContainer gas1 = new GasContainer(5, 500, 200, 150, 100);
            RefrigeratedContainer ref1 = new RefrigeratedContainer("Bananas", 13.3, 1000, 400, 250, 150);

            try
            {
                liquid1.Load(400);
                gas1.Load(200);
                ref1.Load(300);
            }
            catch (OverfillException ex)
            {
                Console.WriteLine("Błąd przepełnienia: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Inny błąd: " + ex.Message);
            }

            try
            {
                ship1.AddContainer(liquid1);
                ship1.AddContainer(gas1);
                ship1.AddContainer(ref1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd przy dodawaniu kontenera na statek: " + ex.Message);
            }

            ship1.PrintInfo();
            gas1.Unload();
            Console.WriteLine($"Po rozładowaniu gazu (zostaje 5%): {gas1.CargoMass} kg");
            ship1.SwapContainers(liquid1.SerialNumber, gas1.SerialNumber);
            Console.WriteLine("Zamieniono miejscami kontenery liquid1 i gas1.\n");
            ship1.PrintInfo();
            Ship ship2 = new Ship("Statek2", 15, 5, 12);

            try
            {
                ship1.MoveContainerToAnotherShip(gas1.SerialNumber, ship2);
                Console.WriteLine("Przeniesiono kontener gazowy na drugi statek.\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Błąd przenoszenia: " + e.Message);
            }

            ship1.PrintInfo();
            ship2.PrintInfo();
            Console.WriteLine("Naciśnij klawisz, aby zakończyć...");
            Console.ReadKey();
        }
    }
}
