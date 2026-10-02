using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
                        int freeSpace = 0;

                        while (_parkingSpaces[freeSpace].IsOccupied)
                        {
                            freeSpace++;

                            if (freeSpace >= _parkingSpaces.Count)
                            {
                                break;
                            }
                        }

                        if (freeSpace < _parkingSpaces.Count)
                        {
                            _parkingSpaces[freeSpace].SetOccupied(true);
                            _cars.Add(new Car(_parkingSpaces[freeSpace], plate));
                            Debug.WriteLine($"Véhicule ajouté à la place {freeSpace + 1}");

                            Console.WriteLine("Véhicule ajouter !");
                        }
                        else
                        {
                            Console.WriteLine("Parking complet !");
                        }
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
