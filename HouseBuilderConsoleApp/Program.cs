namespace HouseBuilderConsoleApp
{
    internal class Program
    {
        //internal HouseBuilder houseBuilder;
        HouseBuilder houseBuilder = new HouseBuilder();


        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        internal void Run()
        {
            //HouseBuilder houseBuilder = new HouseBuilder();

            Console.WriteLine("Welcome to Ellie's Housebuilder!");

            while (true)
            {
                Console.WriteLine("\n1. Build floor/Add floor \n2. Complete House, and print the information");
                Console.WriteLine("\n0. Exit program");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        houseBuilder.AddRoom();
                        break;
                    case "2":
                        Console.Clear();
                        CompleteHouse();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.. ");
                        break;
                }
            }
        }

        internal void CompleteHouse()
        {
            if (houseBuilder.IsHouseComplete())
            {
                Console.Clear();
                Console.WriteLine("\nThe house is done!");
                houseBuilder.PrintHouseInfo();
            }

        }
    }
}
