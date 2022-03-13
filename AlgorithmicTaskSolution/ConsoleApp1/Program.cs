using System;
using System.Text;

namespace AlgorithmicTask1
{
    //1-CI USUL
    class Program
    {
        static string result = "";
        static int index = 1;
        static int count = 0;
        static void Main(string[] args)
        {
            Console.Write("String of size N^2: ");
            string matrix = Console.ReadLine();

            if ((Math.Sqrt(matrix.Length) % 1) != 0)
                Console.WriteLine("Try again!");

            Console.Write("String that describes given word: ");
            string word = Console.ReadLine();

            int length = Convert.ToInt32(Math.Sqrt(matrix.Length));
            char[,] matrixArray = new char[length, length];

            for (int i = 0, k = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    matrixArray[i, j] = matrix[k++];
                }
            }

            for (int i = 0, k=0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (word[k] == matrixArray[i, j])
                    {
                        GetIndexForLetter(matrixArray, word, j, i);
                        if (count+1 == word.Length)
                        {
                            result = $"[{i},{j}] " + result;
                            break;

                        }
                        else
                        {
                            result = string.Empty;
                            continue;
                        }

                    }
                }

                if (count + 1 == word.Length)
                    break;
            }

            Console.WriteLine(result);
        }


        static bool GetIndexForLetter(char[,] matrix, String word, int x, int y)
        {
            char oldChar = matrix[y, x];

            if (index >= word.Length)
                return true;

            int top = y - 1 < 0 ? y : y - 1;
            int bottom = y + 1 >= Math.Sqrt(matrix.Length) ? y : y + 1;
            int right = x + 1 >= Math.Sqrt(matrix.Length) ? x : x + 1;
            int left = x - 1 < 0 ? x : x - 1;

            if (matrix[top, x] == word[index])
            {
                char q = word[index];
                index++;
                matrix[y, x] = ' ';
                bool check = GetIndexForLetter(matrix, word, x, top);
                if (check)
                {
                    string temp = $"[{top},{x}] ";

                    result = temp + result;
                    count++;
                    matrix[y, x] = q;
                    return true;
                }
                else
                {
                    matrix[y, x] = oldChar;
                    index--;
                }
            }
            if (matrix[bottom, x] == word[index])
            {
                char q = word[index];
                index++;
                matrix[y, x] = ' ';
                bool check = GetIndexForLetter(matrix, word, x, bottom);
                if (check)
                {
                    string temp = $"[{bottom},{x}] ";

                    result = temp + result;
                    count++;
                    matrix[y, x] = q;
                    return true;
                }
                else
                {
                    matrix[y, x] = oldChar;
                    index--;
                }
            }
            if (matrix[y, left] == word[index])
            {
                char q = word[index];
                index++;
                matrix[y, x] = ' ';
                bool check = GetIndexForLetter(matrix, word, left, y);
                if (check)
                {
                    string temp = $"[{y},{left}] ";

                    result = temp + result;
                    count++;
                    matrix[y, x] = q;
                    return true;
                }
                else
                {
                    matrix[y, x] = oldChar;
                    index--;
                }
            }
            if (matrix[y, right] == word[index])
            {
                char q = word[index];
                index++;
                matrix[y, x] = ' ';
                bool check = GetIndexForLetter(matrix, word, right, y);
                if (check)
                {
                    string temp = $"[{y},{right}] ";

                    result = temp + result;
                    count++;
                    matrix[y, x] = q;
                    return true;
                }
                else
                {
                    matrix[y, x] = oldChar;
                    index--;
                }
            }
            return false;
        }
    }
}
