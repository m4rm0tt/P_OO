namespace p_oo_parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parking parking = new Parking();

            while (true)
            {
                ConsoleKeyInfo? key = Helpers.ReadInput();

                parking.Menu(key);
            }

            //string testPlate = "AB-12345";
            //bool validity = Helpers.PlateValidation(testPlate);
            //Console.WriteLine(validity); Mettre dans test.
        }
    }
}
