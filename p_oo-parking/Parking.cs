using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_oo_parking
{
    internal class Parking
    {
        private List<Car> _cars;
        private ConsoleKeyInfo _key;
        private bool _isShow;

        public List<ParkingSpace> _parkingSpaces { get; private set; }

        static public int TicketPrice { get; private set; } = 5; // Par Heure

        public Parking()
        {
            _cars = new List<Car>();
            _parkingSpaces = new List<ParkingSpace>();

            _isShow = false;

            for (int i = 0; i < 10; i++)
            {
                _parkingSpaces.Add(new ParkingSpace(_parkingSpaces.Count));
            }
        }

        public void Menu(ConsoleKeyInfo? k)
        {
            _key = k ?? _key;

            if (!_isShow) ShowMenu();

            switch (_key.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine("Plaque:");
                    
                    string plate = Console.ReadLine();
                    bool isValid = Helpers.PlateValidation(plate);

                    if (isValid)
                    {
                        _cars.Add(new Car(_parkingSpaces[_cars.Count], plate));

                        Console.WriteLine("Véhicule ajouter !");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Plaque Invalide !");
                    }

                    Thread.Sleep(1000);

                    _key = default;
                    _isShow = false;
                    break;

                default:
                    break;
            }
        }

        private void ShowMenu()
        {
            Console.Clear();

            Console.WriteLine("1. Ajouter un Véhicule\n" +
                                "Appuyer sur un touche pour choisir");

            _isShow = true;
        }
    }
}
