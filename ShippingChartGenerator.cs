using System;
using System.Linq;

namespace ShippingChart
{
    static class MainClass
    {
        // Shuffle array with Fisher-Yates
        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        public static void Main(string[] args)
        {
            string[] characters = new string[] { "John  ", "Rose  ", "Dave  ", "Jade  ", "Aradia", "Tavros", "Sollux", "Karkat", "Nepeta", "Kanaya", "Terezi", "Vriska", "Equius", "Gamzee", "Eridan", "Feferi" };

            // Generate random ordering of card suits (minus clubs) and blank spaces
            // 1 = Heart
            // 2 = Diamond
            // 3 = Spade
            // 4 = Club
            // 0 = Blank
            // Always 23x Heart, Diamond, Spade; 15x Club; 36x Blank
            int[] array = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            while(array[array.Length - 1] == 0)
            {
                new Random().Shuffle(array);
            }

            // Create blank shipping chart
            int chartSize = 16;
            int[,] ships = new int[chartSize, chartSize];
            for (int row = 0; row < chartSize; row++)
            {
                for (int col = 0; col < chartSize; col++)
                {
                    ships[row, col] = 0;
                }
            }

            // Fill in chart with clubs first
            int[] clubs = new int[16];
            for (int i = 0; i < clubs.Length; i += 1)
            {
                clubs[i] = i;
            }
            new Random().Shuffle(clubs);

            for (int i = 0; i < 5; i++)
            {
                int[] x = { clubs[3 * i], clubs[3 * i + 1], clubs[3 * i + 2] };
                int a = x.Max();
                int c = x.Min();
                int b = x.Sum() - a - c;

                ships[a, b] = 4;
                ships[a, c] = 4;
                ships[b, c] = 4;
            }

            // Fill in chart with other suits and blanks, making sure not to overlap clubs
            int filled = 15;
            while(filled < 120)
            {
                for (int row = 0; row < chartSize; row++)
                {
                    for (int col = 0; col < row; col++)
                    {
                        if(ships[row, col] != 4)
                        {
                            ships[row, col] = array[filled - 15];
                            filled++;
                        }
                    }
                }
            }

            // Add chart to its own transpose
            int[,] shipsCopy = (int[,])ships.Clone();
            for (int row = 0; row < chartSize; row++)
            {
                for (int col = 0; col < chartSize; col++)
                {
                    ships[row, col] = ships[row, col] + shipsCopy[col, row];
                }
            }

            // Print numeric shipping chart
            Console.WriteLine("NUMERIC SHIPPING CHART");
            for (int row = 0; row < chartSize; row++)
            {
                for (int col = 0; col < chartSize; col++)
                {
                    Console.Write(String.Format("{0}  ", ships[row, col]));
                }
                Console.WriteLine();
            }

            // Convert numbers to card suits
            string[,] shippingChart = new string[chartSize, chartSize];
            for (int row = 0; row < chartSize; row++)
            {
                for (int col = 0; col < chartSize; col++)
                {
                    switch (ships[row, col])
                    {
                        case 1:
                            shippingChart[row, col] = "H";
                            break;
                        case 2:
                            shippingChart[row, col] = "D";
                            break;
                        case 3:
                            shippingChart[row, col] = "S";
                            break;
                        case 4:
                            shippingChart[row, col] = "C";
                            break;
                        case 0:
                            shippingChart[row, col] = " ";
                            break;

                    }
                }
            }

            // Print final shipping chart (no labels)
            Console.WriteLine();
            Console.WriteLine("SHIPPING CHART WITHOUT LABELS");
            for (int row = 0; row < chartSize; row++)
            {
                for (int col = 0; col < chartSize; col++)
                {
                    Console.Write(String.Format("{0}  ", shippingChart[row, col]));
                }
                Console.WriteLine();
            }

            // Print final shipping chart (labels)
            Console.WriteLine();
            Console.WriteLine("SHIPPING CHART WITH LABELS");
            Console.Write("       ");
            for (int i = 0; i < chartSize; i++)
            {
                Console.Write(String.Format("{0} ", characters[i]));
            }
            Console.WriteLine();

            for (int row = 0; row < chartSize; row++)
            {
                Console.Write(String.Format("{0} ", characters[row]));
                for (int col = 0; col < chartSize; col++)
                {
                    Console.Write(String.Format("  {0}    ", shippingChart[row, col]));
                }
                Console.WriteLine();
            }

            //Print unfolded shipping chart
            Console.WriteLine();
            Console.WriteLine("UNFOLDED SHIPPING CHART");
            for (int row = 0; row < chartSize; row++)
            {
                for (int col = 0; col < chartSize; col++)
                {
                    Console.Write(shippingChart[row, col]);
                }
            }
        }
    }
}
