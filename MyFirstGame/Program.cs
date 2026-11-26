namespace MyFirstGame
{
    internal class Program
    {



        static void Main(string[] args)
        {
            Random xy = new Random();

            int stn = 1;
            int str = 1;
            int hazine_stn =  xy.Next(1,13);
            int hazine_str = xy.Next(1,8);

            int can = 3;
            bool[,] attacked_rooms = new bool[7, 12];
            string[,] map = new string[7, 12];

            for(int i = 0; i <  map.GetLength(0) ; i++)
            {
                for (int j = 0; j < map.GetLength(1) ; j++)
                {
                    map[i, j] = ".";
                }
            }


            void show_map()
            {
                Console.Clear();

                Console.WriteLine("Welcome to the Treasure Room!!");
                Console.WriteLine("There is a cave with 7 floor and 12 rooms each floor. Can u find the treasure room? ");
                Console.WriteLine("You can use arrow keys for move and you only have 3 attack chance. Use them wisely. For attacking a room press space key");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");

                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine($"\nRemaining chance: {can}");
            }

            map[0, 0] = "P";
            show_map();

            while (can>0)
            {
                ConsoleKey tus = Console.ReadKey(true).Key;

                if (tus == ConsoleKey.RightArrow && stn < 12)
                {
                    map[str - 1, stn - 1] = attacked_rooms[str-1,stn-1] ? "X" : ".";
                    stn++;
                    map[str - 1, stn - 1] = "P";
                    show_map() ;
                    
                }
                else if (tus == ConsoleKey.LeftArrow && stn > 1)
                {
                    map[str - 1, stn - 1] = attacked_rooms[str - 1, stn - 1] ? "X" : ".";
                    stn--;
                    map[str - 1, stn - 1] = "P";
                    show_map();
                }
                else if (tus == ConsoleKey.UpArrow && str > 1)
                {
                    map[str - 1, stn - 1] = attacked_rooms[str - 1, stn - 1] ? "X" : ".";
                    str--;
                    map[str - 1, stn - 1] = "P";
                    show_map();
                }
                else if (tus == ConsoleKey.DownArrow && str < 7)
                {
                    map[str - 1, stn - 1] = attacked_rooms[str - 1, stn - 1] ? "X" : ".";
                    str++;
                    map[str - 1, stn - 1] = "P";
                    show_map();
                }
                else if(tus == ConsoleKey.Spacebar)
                {
                    if (str == hazine_str && stn == hazine_stn)
                    {
                        Console.WriteLine("Congrulations!!! You found the treasure");
                        break;
                    }
                    else if (attacked_rooms[str - 1, stn - 1] == true)
                    {
                        Console.WriteLine("You can't attack again bro its priiiivate property");

                    }
                    else
                    {
                        attacked_rooms[str - 1, stn - 1] = true;
                        can--;
                        Console.WriteLine("Wrong room sorry bro");
                    }
                }
            }

            if (can == 0)
            {
                Console.WriteLine("Game Over, not lucky that time huh");
                Console.WriteLine($"The treasure was in floor: {hazine_str} on room: {hazine_stn} ");
            }
        }
    }
}
