using System;
using System.Text;

namespace AlgorithmicTask2
{
    //2-CI USUL
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            l1:
                Console.Write("String of size N^2: ");
                string matrix = Console.ReadLine();

                if ((Math.Sqrt(matrix.Length) % 1) != 0)
                    goto l1;

                Console.Write("String that describes given word: ");
                string word = Console.ReadLine();

                int column = Convert.ToInt32(Math.Sqrt(matrix.Length));
                char[,] matrixArray = new char[column + 2, column + 2];

                int k = 0;
                for (int i = 1; i <= column; i++)
                {
                    for (int j = 1; j <= column; j++)
                    {
                        matrixArray[i, j] = matrix[k++];
                    }

                }

                string result = "";
                k = 0;

                for (int j = 1; j < column; j++)
                {
                    for (int f = 1; f < column; f++)
                    {
                        if (word[k] == matrixArray[j, f])
                        {
                            result = $"[{j - 1},{f - 1}] ";
                            int a = j;
                            int b = f;
                            for (int l = 1; l < word.Length; l++)
                            {
                                if (matrixArray[a, b + 1] == word[l])
                                    b++;
                                else if (matrixArray[a - 1, b] == word[l])
                                    a--;
                                else if (matrixArray[a + 1, b] == word[l])
                                    a++;
                                else if (matrixArray[a, b - 1] == word[l])
                                    b--;
                                else
                                {
                                    result = string.Empty;
                                    break;
                                }
                                result += $"[{a - 1},{b - 1}] ";

                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(result))
                    Console.WriteLine(result);

            }
            catch (Exception)
            {
                Console.Write("Please, try again!");
            }
        }
    }
}
