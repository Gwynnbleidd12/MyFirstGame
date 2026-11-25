namespace MyFirstGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Treasure Game!!");
            Console.WriteLine("There is a cave with 2 floor and 10 rooms each floor. Can u find the treasure room? ");
            Console.WriteLine("You can use arrow keys for move and you only have 3 attack chance. Use them wisely. For attacking a room press space key");
            int stn = 1;
            int str = 1;
            int hazine_stn = 9;
            int hazine_str = 2;

            int can = 3;
            bool[,] attacked_rooms = new bool[2, 10];

            while (can>0)
            {
                ConsoleKey tus = Console.ReadKey(true).Key;

                if (tus == ConsoleKey.RightArrow && stn < 10)
                {
                    stn++;
                    Console.WriteLine($"Satır: {str}, Sütun: {stn}");
                }
                else if (tus == ConsoleKey.LeftArrow && stn > 1)
                {
                    stn--;
                    Console.WriteLine($"Satır: {str}, Sütun: {stn}");
                }
                else if (tus == ConsoleKey.UpArrow && str > 1)
                {
                    str--;
                    Console.WriteLine($"Satır: {str}, Sütun: {stn}");
                }
                else if (tus == ConsoleKey.DownArrow && str < 2)
                {
                    str++;
                    Console.WriteLine($"Satır: {str}, Sütun: {stn}");
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
            }
        }
    }
}
