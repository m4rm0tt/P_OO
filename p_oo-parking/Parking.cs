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

                    bool found = false;
                    
                    switch(_key.Key)
                    { 
                        
                        case ConsoleKey.D1:
                            Console.Clear();
                            Console.WriteLine("Plaque : ");
                            
                            plate = Console.ReadLine();
                            isValid = Helpers.PlateValidation(plate);
                            
                            if(isValid)
                            {
                                found = false;
                                
                                foreach (Car car in _cars)
                                {
                                    if(car.Plate == plate)
                                    {
                                        found = true;
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
                                        break;
                                    }
                                }
                                
                                if (!found)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Aucun véhicule trouvé !");
                                }

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Plaque Invalide !");
                            }

                            Thread.Sleep(1000);
                            
                            break;
                        
                        case ConsoleKey.D2:
                            Console.Clear();
                            Console.WriteLine("Place : ");
                            
                            int parkingSpace = int.Parse(Console.ReadLine());
                            
                            found = false;
                                
                            foreach (Car car in _cars)
                            {
                                if(car.ParkingSpace.Number == parkingSpace)
                                {
                                    found = true;
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
                                    break;
                                }
                            }
                            
                            if (!found)
                            {
                                Console.Clear();
                                Console.WriteLine("Aucun véhicule trouvé !");
                            }
                            break;
                    }
                    
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
                                "\nAppuyer sur un touche pour choisir");

            _isShow = true;
        }
    }
}
