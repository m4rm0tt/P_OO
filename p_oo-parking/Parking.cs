using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace p_oo_parking
{
    internal class Parking
    {
        private List<Car> _cars;
        private ConsoleKeyInfo _key;
        private bool _isShow;

        public List<ParkingSpace> ParkingSpaces { get; private set; }

        static public int TicketPrice { get; private set; } = 5; // Par Heure

        public Parking()
        {
            _cars = new List<Car>();
            ParkingSpaces = new List<ParkingSpace>();

            _isShow = false;

            for (int i = 0; i < 10; i++)
            {
                ParkingSpaces.Add(new ParkingSpace(ParkingSpaces.Count));
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

                        while (ParkingSpaces[freeSpace].IsOccupied)
                        {
                            freeSpace++;

                            if (freeSpace >= ParkingSpaces.Count)
                            {
                                break;
                            }
                        }

                        if (freeSpace < ParkingSpaces.Count)
                        {
                            ParkingSpaces[freeSpace].SetOccupied(true);
                            _cars.Add(new Car(ParkingSpaces[freeSpace], plate));
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
                
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("1. Plaque\n" +
                                      "2. Place\n" +
                                      "\nAppuyer sur un touche pour choisir");
                    
                    _key = Console.ReadKey();

                    Car car = SearchCar(_key);

                    if (car is not null)
                    {
                        Console.Clear();
                        Console.WriteLine("Sur ? O/N");
                        _key = Console.ReadKey();

                        if (_key.Key == ConsoleKey.O)
                        {
                            car.Ticket.Close();
                            car.ParkingSpace.SetOccupied(false);

                            _cars.Remove(car);

                            Console.Clear();
                            Console.WriteLine($"Véhicule {car.Plate} supprimé\n" +
                                              $"Temps : {car.Ticket.Total.TotalHours}h\n" +
                                              $"Montant : {car.Ticket.Amount}\n" +
                                              "\nAppuyer sur une touche pour continuer");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Annulé");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Aucun véhicule trouvé !");
                    }

                    _key = default;
                    _isShow = false;
                    
                    break;

                case ConsoleKey.D3:

                    ShowParkingState(ParkingSpaces);

                    Console.WriteLine("\nAppuyer sur une touche pour continuer");
                    Console.ReadKey();

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
                              "2. Sortir un Véhicule\n" +
                              "3. Afficher l'état du parking\n" +
                                "\nAppuyer sur un touche pour choisir");

            _isShow = true;
        }

        private void ShowParkingState(List<ParkingSpace> parkingSpaces)
        {
            int i = 0;

            foreach (ParkingSpace p in  parkingSpaces)
            {
                i++;
                string w;
                
                if (p.IsOccupied)
                {
                    w = "X";
                }
                else
                {
                    w = "L";
                }

                if (i % 5 == 0)
                {
                    Console.WriteLine($"| {p.Number} : {w} |");
                }
                else
                {
                    Console.Write($"| {p.Number} : {w} |");
                }
            }
        }

        private Car SearchCar(ConsoleKeyInfo? k)
        {
            _key = k ?? _key;

            bool found = false;

            switch (_key.Key)
            {

                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine("Plaque : ");

                    string plate = Console.ReadLine();
                    bool isValid = Helpers.PlateValidation(plate);

                    if (isValid)
                    {

                        foreach (Car car in _cars)
                        {
                            if (car.Plate == plate)
                            {
                                return car;
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Plaque Invalide !");
                    }

                    Thread.Sleep(1000);

                    return null;

                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("Place : ");

                    int parkingSpace = int.Parse(Console.ReadLine());

                    found = false;

                    foreach (Car car in _cars)
                    {
                        if (car.ParkingSpace.Number == parkingSpace)
                        {
                            return car;
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("Aucun véhicule trouvé !");
                    return null;

                default:
                    return null;
            }
        }
    }
}
