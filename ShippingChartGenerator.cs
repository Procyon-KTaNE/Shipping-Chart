using System;
using System.Linq;
using System.Collections.Generic;

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

        public static string Convert(int num)
        {
            switch (num)
            {
                case 1:
                    return "H";
                case 2:
                    return "D";
                case 3:
                    return "S";
                case 4:
                    return "C";
                case 0:
                    return " ";
                default:
                    return "error";
            }
        }

        public static void Main(string[] args)
        {
            int rngSeed = 1; // Edit as necessary

            Boolean moduleExists = false;
            int attempts = 1;

            do
            {
                int erifefRelationshipIndex = new Random().Next(4);

                string[] names = new string[] { "John  ", "Rose  ", "Dave  ", "Jade  ", "Aradia", "Tavros", "Sollux", "Karkat", "Nepeta", "Kanaya", "Terezi", "Vriska", "Equius", "Gamzee", "Eridan", "Feferi" };
                // Generate random ordering of card suits (minus clubs) and blank spaces
                // 1 = Heart
                // 2 = Diamond
                // 3 = Spade
                // 4 = Club
                // 0 = Blank
                
                int hdsCount = 23; // There are 69 relationship pairs lol
                int cCount = 15;
                int blanks = 120 - 3 * hdsCount - cCount;
                List<int> numericalSuitsNoCList = new List<int>();
                for (int i = 1; i <= 3; i++)
                {
                    for (int j = 0; j < hdsCount; j++)
                    {
                        numericalSuitsNoCList.Add(i);
                    }
                }
                for (int i = 0; i < blanks; i++)
                {
                    numericalSuitsNoCList.Add(0);
                }
                int[] numericalSuitsNoC = numericalSuitsNoCList.ToArray();


                // Make matrix of all charts for rng seed
                int chartSize = 16;
                int suits = 4;
                int[,,] allCharts = new int[suits, chartSize, chartSize];

                // Let's make this fucking thing
                string[,,] allChartsLetters = new string[suits, chartSize, chartSize];
                if(rngSeed == 1)
                {
                    string[] baseCase = new string[1024] { " ", "D", "H", "H", " ", "S", "C", " ", "H", "C", " ", "S", "H", "D", " ", "S", "D", " ", "H", "S", "C", "H", " ", "S", "D", "H", "D", " ", " ", "C", "S", " ", "H", "H", " ", "S", "D", "D", " ", "S", "C", " ", "H", "D", "D", "D", "C", " ", "H", "S", "S", " ", "H", " ", "H", "D", "S", "S", " ", "C", "C", " ", " ", "D", " ", "C", "D", "H", " ", "D", "H", "S", " ", " ", "H", "S", "S", "C", "S", "H", "S", "H", "D", " ", "D", " ", "D", " ", "D", " ", "C", "S", " ", "H", " ", "C", "C", " ", " ", "H", "H", "D", " ", "H", " ", "C", "D", " ", "S", " ", "S", "D", " ", "S", "S", "D", "S", " ", "H", " ", " ", "D", "H", " ", "S", "D", " ", "H", "H", "D", "C", "S", " ", "D", " ", " ", " ", " ", "D", "H", "D", "S", "C", " ", "C", "H", " ", "S", " ", " ", "C", "D", " ", " ", "D", "D", "H", "S", "D", "S", " ", "D", "H", " ", "H", "C", "D", "H", "D", "D", " ", "H", " ", "S", "H", "C", "S", " ", "D", "C", "S", "S", " ", " ", "H", "D", "H", " ", "C", " ", "S", "H", "H", " ", "D", "C", "S", " ", "S", "S", "D", "H", " ", "C", " ", " ", " ", " ", "D", "C", "D", " ", "C", "H", " ", "D", "S", "S", "S", " ", " ", " ", " ", " ", " ", "S", "C", " ", "S", " ", "S", " ", "C", "D", "H", "S", " ", " ", " ", "H", "S", " ", " ", "D", "H", "C", "D", "H", " ", "S", "C", "H", " ", " ", "H", " ", " ", "D", "D", "H", "H", " ", " ", "H", "S", "C", " ", "S", "H", "S", " ", "C", "D", " ", "H", " ", "S", "C", "C", "S", "D", "H", "H", "H", " ", "S", "S", "D", "D", "H", " ", "S", "D", " ", "D", "S", "D", " ", "H", " ", "C", " ", "C", " ", "H", " ", "S", " ", " ", "H", " ", "D", "S", " ", " ", "C", " ", "C", "H", "H", "H", "S", "D", " ", " ", "D", "H", "D", "C", "D", "C", "S", "S", " ", "S", "H", " ", "C", " ", "H", "D", " ", "C", " ", "D", " ", " ", "S", "S", "H", " ", " ", " ", "C", "D", " ", "H", "C", " ", "H", " ", "H", "D", " ", "D", " ", "S", "D", "H", "S", "S", "D", "D", " ", "H", " ", " ", "D", "H", "S", " ", "D", "D", " ", "S", "D", "D", "S", "C", "D", " ", " ", " ", "D", "C", "H", "D", " ", "S", "H", "C", "H", " ", " ", "D", " ", "H", "D", "D", " ", "S", "D", " ", "S", "D", "C", " ", "H", "H", " ", "C", " ", "D", "H", "C", "S", " ", "H", " ", "S", "H", "H", "S", "H", " ", "C", "S", "S", " ", "S", "H", "D", "H", " ", " ", "C", "S", " ", "H", " ", "C", " ", "S", "S", "D", " ", "D", " ", " ", " ", " ", " ", "C", " ", "S", "S", " ", "C", " ", "H", " ", "D", " ", "S", "S", "C", " ", " ", " ", "S", " ", "S", "C", "H", "S", " ", "S", "D", "S", "D", "H", "S", "C", " ", " ", "D", "C", "D", " ", "H", "H", " ", "D", " ", "H", "C", "H", " ", " ", "S", "D", " ", " ", "D", "H", "H", " ", "H", " ", "S", " ", "D", "D", "S", "H", "S", " ", " ", "D", " ", "H", "D", "C", " ", " ", "C", "D", "H", " ", "D", " ", " ", "S", "S", "H", "H", " ", "S", "D", "D", "D", "S", "C", " ", "H", " ", " ", " ", "S", "C", "H", "D", "S", " ", "H", "C", " ", "D", "S", " ", " ", "D", " ", " ", "C", "H", " ", "C", "D", "H", " ", "D", "H", "C", " ", " ", "S", "S", "S", " ", "S", "H", "H", " ", "D", "C", "D", " ", " ", " ", "D", " ", "D", "S", "S", "H", "C", " ", " ", " ", "D", " ", "H", " ", " ", "H", "S", "H", "D", "C", "D", "C", "S", "D", "S", "C", "S", "D", "C", " ", "H", " ", " ", "D", "H", " ", " ", "D", "H", "H", " ", "D", "C", "S", " ", "D", "S", " ", " ", " ", "H", "H", "D", "S", "H", "C", "D", "H", " ", " ", " ", " ", "H", "D", " ", " ", "C", "D", "C", "S", "D", "D", "D", " ", "H", " ", "S", "D", "D", "H", "H", "C", " ", "H", "C", "S", "H", " ", "S", "D", " ", "D", "S", "S", "C", " ", "H", "D", "H", " ", " ", "C", "S", "S", "H", " ", " ", " ", "S", "S", "D", " ", "D", "C", "C", " ", " ", "H", " ", " ", "S", " ", " ", " ", " ", "H", "C", "D", "S", "S", "S", "C", "H", " ", " ", " ", " ", "S", "S", "C", "S", "C", "S", "H", "H", "D", "H", "S", " ", " ", " ", "S", " ", "S", "C", "H", "H", " ", "D", "H", "C", "D", " ", "S", " ", " ", "S", " ", " ", "D", "C", "H", "S", "C", "D", "D", " ", "H", "S", "S", "H", " ", " ", " ", "D", " ", "H", "C", " ", " ", "S", " ", "D", "H", " ", "H", " ", "C", "S", " ", "C", "H", " ", "S", "D", "C", "D", "S", "D", " ", "H", " ", "S", "S", "H", " ", "H", "C", "S", " ", "S", " ", " ", "D", "S", "D", " ", " ", "D", "C", "H", "H", "S", " ", "D", "S", " ", "D", "H", "H", "C", "C", "H", "S", "S", "S", "S", "H", "C", " ", "C", " ", "D", " ", "D", "S", "D", " ", "D", "S", "H", "H", "D", " ", "D", "S", "D", " ", "H", "D", " ", "H", " ", "D", "D", "C", "C", " ", "S", "D", "D", " ", "S", "D", "H", "S", "H", " ", "H", "D", "H", " ", " ", "D", "C", "C", " ", "D", "D", "S", "C", "D", " ", "H", " ", "C", " ", "H", "D", " ", "H", "S", "H", "H", " ", "D", "C", " ", "D", "D", "C", " ", " ", "D", " ", "S", "D", " ", "S", " ", "H", " ", "H", "D", "D", "H", " ", " ", " ", "H", " ", "S", "H", "S", "S", "H", " ", " ", "S", "S", "C", " ", "H", "D", "H", " ", "C", " ", "S", " ", "H", " ", "S", "D", "S", "H", "C", " ", "D", " ", " ", "C", " ", " ", " ", " ", " ", "C", "S", "C", "S", "H", " ", "D", " ", "S", "S", " ", " ", " ", " ", " ", " ", "S", "H", "H", "S", "D", "S", "C", "H", "D", "H", "S", " ", " ", " ", "C", " ", " ", " ", "H", "H", " ", "D", "C", "S", " ", "S", " ", " ", " ", "C", " " };
                    for(int chart = 0; chart < suits; chart++)
                    {
                        for(int row = 0; row < chartSize; row++)
                        {
                            for(int col = 0; col < chartSize; col++)
                            {
                                allChartsLetters[chart, row, col] = baseCase[256 * chart + 16 * row + col];
                            }
                        }
                    }
                }
                else
                {
                    for (int index = 0; index < suits; index++)
                    {
                        int chart = index + 1;

                        do
                        {
                            new Random().Shuffle(numericalSuitsNoC);
                        } while (numericalSuitsNoC[numericalSuitsNoC.Length - 1] != chart && chart < 4);
                            
                        // Create blank shipping charts
                        for (int row = 0; row < chartSize; row++)
                        {
                            for (int col = 0; col < chartSize; col++)
                            {
                                allCharts[index, row, col] = 0;
                           }
                        }
                            
                        // Fill in the charts with clubs first
                        int[] clubs = new int[16];
                        for (int i = 0; i < clubs.Length; i += 1)
                        {
                            clubs[i] = i;
                        }
                        do
                        {
                            new Random().Shuffle(clubs);
                        } while ((chart < 4 && Array.IndexOf(clubs, 14) / 3 == Array.IndexOf(clubs, 15) / 3) || (chart == 4 && Array.IndexOf(clubs, 14) / 3 != Array.IndexOf(clubs, 15) / 3));
                            
                        for (int i = 0; i < 5; i++)
                        {
                            int[] x = { clubs[3 * i], clubs[3 * i + 1], clubs[3 * i + 2] };
                            int a = x.Max();
                            int c = x.Min();
                            int b = x.Sum() - a - c;
                                
                            allCharts[index, a, b] = 4;
                            allCharts[index, a, c] = 4;
                            allCharts[index, b, c] = 4;
                        }
                            
                        // Fill in chart with other suits and blanks, making sure not to overlap clubs
                        int filled = 15;
                        while (filled < 120)
                        {
                            for (int row = 0; row < chartSize; row++)
                            {
                                for (int col = 0; col < row; col++)
                                {
                                    if (allCharts[index, row, col] != 4)
                                    {
                                        allCharts[index, row, col] = numericalSuitsNoC[filled - 15];
                                       filled++;
                                    }
                                }
                            }
                        }
                            
                        // Add chart to its own transpose
                        int[,,] allChartsClone = (int[,,])allCharts.Clone();
                        for (int row = 0; row < chartSize; row++)
                        {
                            for (int col = 0; col < chartSize; col++)
                            {
                                allCharts[index, row, col] = allCharts[index, row, col] + allChartsClone[index, col, row];
                            }
                        }
                            
                        // Convert numbers to card suits
                            
                        for (int row = 0; row < chartSize; row++)
                        {
                            for (int col = 0; col < chartSize; col++)
                            {
                                allChartsLetters[index, row, col] = Convert(allCharts[index, row, col]);
                            }
                        }
                    }
                }

                // Create four sets of four characters
                int[] characters = new int[16];
                for (int i = 0; i < characters.Length; i += 1)
                {
                    characters[i] = i;
                }

                // Splitting Eridan and Feferi
                do
                {
                    new Random().Shuffle(characters);
                } while (Array.IndexOf(characters, 14) / 4 == Array.IndexOf(characters, 15) / 4);

                // Picking correct chart
                string[,] correctChartLetters = new string[16, 16];
                for (int row = 0; row < chartSize; row++)
                {
                    for (int col = 0; col < chartSize; col++)
                    {
                        correctChartLetters[row, col] = allChartsLetters[erifefRelationshipIndex, row, col];
                    }
                }

                // Get all possible sets of five suits that can appear on the module
                List<string> moduleSuitsStringList = new List<string>();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 12; j < 16; j++)
                    {
                        for (int m = 4; m < 8; m++)
                        {
                            for (int n = 8; n < 12; n++)
                            {
                                if (correctChartLetters[characters[i], characters[j]].Equals(correctChartLetters[characters[m], characters[n]])
                                    && !correctChartLetters[characters[i], characters[m]].Equals(" ")
                                    && !correctChartLetters[characters[i], characters[n]].Equals(" ")
                                    && !correctChartLetters[characters[i], characters[j]].Equals(" ")
                                    && !correctChartLetters[characters[m], characters[j]].Equals(" ")
                                    && !correctChartLetters[characters[n], characters[j]].Equals(" "))
                                {
                                    string[] moduleSuits = new string[5];
                                    moduleSuits[0] = correctChartLetters[characters[i], characters[m]];
                                    moduleSuits[1] = correctChartLetters[characters[i], characters[n]];
                                    moduleSuits[2] = correctChartLetters[characters[i], characters[j]];
                                    moduleSuits[3] = correctChartLetters[characters[m], characters[j]];
                                    moduleSuits[4] = correctChartLetters[characters[n], characters[j]];
                                    string moduleSuitsString = string.Join("", moduleSuits);
                                    moduleSuitsStringList.Add(moduleSuitsString);
                                }
                            }
                        }
                    }
                }

                // Remove invalid suits configurations
                for (int i = moduleSuitsStringList.Count - 1; i >= 0 ; i--)
                {
                    if(!(moduleSuitsStringList[i])[Array.IndexOf(characters, 14) / 4 + Array.IndexOf(characters, 15) / 4 - 1].ToString().Equals(Convert(erifefRelationshipIndex + 1)))
                    {
                        moduleSuitsStringList.RemoveAt(i);
                    }
                }
                string[] allModuleSuits = moduleSuitsStringList.ToArray();

                if (allModuleSuits.Length > 0)
                {
                    moduleExists = true;
                }
                else
                {
                    attempts++;
                    continue;
                }

                string[] uniqueElements = moduleSuitsStringList.Where(el => moduleSuitsStringList.Count(el2 => el2 == el) == 1).ToArray();
                if (uniqueElements.Length > 0)
                {
                    moduleExists = true;
                }
                else
                {
                    attempts++;
                    continue;
                }

                // Pick which case to use and print the information that will appear on the module
                int suitsOnModuleIndex = new Random().Next(uniqueElements.Length);
                string suitsOnModule = uniqueElements[suitsOnModuleIndex];

                string[] charactersOnModule = new string[4];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 12; j < 16; j++)
                    {
                        for (int m = 4; m < 8; m++)
                        {
                            for (int n = 8; n < 12; n++)
                            {
                                if (correctChartLetters[characters[i], characters[j]].Equals(correctChartLetters[characters[m], characters[n]])
                                    && !correctChartLetters[characters[i], characters[m]].Equals(" ")
                                    && !correctChartLetters[characters[i], characters[n]].Equals(" ")
                                    && !correctChartLetters[characters[i], characters[j]].Equals(" ")
                                    && !correctChartLetters[characters[m], characters[j]].Equals(" ")
                                    && !correctChartLetters[characters[n], characters[j]].Equals(" "))
                                {
                                    string[] moduleSuits = new string[5];
                                    moduleSuits[0] = correctChartLetters[characters[i], characters[m]];
                                    moduleSuits[1] = correctChartLetters[characters[i], characters[n]];
                                    moduleSuits[2] = correctChartLetters[characters[i], characters[j]];
                                    moduleSuits[3] = correctChartLetters[characters[m], characters[j]];
                                    moduleSuits[4] = correctChartLetters[characters[n], characters[j]];
                                    string moduleSuitsString = string.Join("", moduleSuits);

                                    if (moduleSuitsString == suitsOnModule)
                                    {
                                        charactersOnModule[0] = names[characters[i]];
                                        charactersOnModule[1] = names[characters[m]];
                                        charactersOnModule[2] = names[characters[n]];
                                        charactersOnModule[3] = names[characters[j]];
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                // LOGGING

                // Initial module information
                Console.WriteLine("MODULE INTIIAL STATE\n");

                //  4x4 table of characters
                for (int i = 0; i < 4; i++)
                {
                    Console.Write(String.Format("{0}  |  {1}\n", names[characters[i]], names[characters[4 + i]]));
                }
                Console.WriteLine("--------+--------");
                for (int i = 0; i < 4; i++)
                {
                    Console.Write(String.Format("{0}  |  {1}\n", names[characters[8 + i]], names[characters[12 + i]]));
                }

                Console.WriteLine(String.Format("\nSuits: {0}\n", suitsOnModule));
                Console.WriteLine(String.Format("Relationship between Eridan and Feferi on module is: {0}\n", suitsOnModule[Array.IndexOf(characters, 14) / 4 + Array.IndexOf(characters, 15) / 4 - 1]));

                //  Correct shipping chart
                Console.Write("       ");
                for (int i = 0; i < chartSize; i++)
                {
                    Console.Write(String.Format("{0} ", names[i]));
                }
                Console.WriteLine();

                for (int row = 0; row < chartSize; row++)
                {
                    Console.Write(String.Format("{0} ", names[row]));
                    for (int col = 0; col < chartSize; col++)
                    {
                        Console.Write(String.Format("  {0}    ", correctChartLetters[row, col]));
                    }
                    Console.WriteLine();
                }

                // Solution
                Console.Write("\nSOLUTION:\n");
                Console.WriteLine(String.Join("\n", charactersOnModule));

                Console.WriteLine("\nFound {0} possible module(s) on attempt #{1}", uniqueElements.Length, attempts);
            } while (!moduleExists);
        }
    }
}
