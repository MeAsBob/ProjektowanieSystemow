using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)

    {
        double RVIR()
        {
            Random Losowe = new Random(); //Randomizacija
            int min = 5;//od 5
            int max = 10;//do 9
            int rand = Losowe.Next(min, max);
            double randomValueInRange = (Convert.ToDouble(rand));
            return randomValueInRange;
        }



        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        int Size = 10; // Zmienna do testów, możesz zmienić na potrzebną wartość
        int nr_size = 1;
        for (int i = 0; i < Size - 1; i++)
        {
            for (int j = i + 1; j < Size; j++)
            {
                for (int k = i; k < Size; k++)
                {
                    nr_size++;
                }
            }
        }
        string[,] nr = new string[nr_size, 9];
        string[,] nr3 = new string[nr_size, 8];
        int iter2 = 1;
        int x = 0;
        int y = 0;




        double[,] MatrixA = new double[Size, Size]; // Tworzenie macierzy A
        double[,] MatrixL = new double[Size, Size]; // Tworzenie macierzy L
        double[,] MatrixU = new double[Size, Size]; // Tworzenie macierzy U


        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {

                MatrixA[i, j] = RVIR(); //Wypełnianie Macierzy A wartościami losowymi


            }
        }

        for (int i = 0; i < Size; i++)
        {
            MatrixL[i, i] = 1; //Ustawianie przkątnej w Macierzy L
            for (int j = 0; j < Size; j++)
            {
                MatrixU[i, j] = MatrixA[i, j]; // Przekopowywanie Macierzy A do Macierzu U

            }
        }

        for (int i = 0; i < Size - 1; i++)
        {
            for (int j = i + 1; j < Size; j++)
            {
                if (MatrixU[i, i] != 0.0)
                {
                    MatrixL[j, i] = MatrixU[j, i] / MatrixU[i, i]; // lji = aji / aii
                }
                else
                {
                    MatrixL[j, i] = 0.0;
                }

                for (int k = i; k < Size; k++)
                {
                    MatrixU[j, k] -= MatrixL[j, i] * MatrixU[i, k]; // ajk = ajk - lji * aik
                    nr[x, 1] = (iter2).ToString();
                    iter2++;
                    nr[x, 2] = (i).ToString();
                    nr[x, 3] = (j).ToString();
                    nr[x, 4] = (k).ToString();
                    nr[x, 5] = (j).ToString() + "," + (k).ToString();
                    nr[x, 6] = (j).ToString() + "," + (i).ToString();
                    nr[x, 7] = (i).ToString() + "," + (k).ToString();
                    nr[x, 8] = (i).ToString() + "," + (i).ToString();
                    x++;
                }
            }
        }





        // Zatrzymujemy stoper
        stopwatch.Stop();

        // Wyświetlamy czas wykonania
        Console.WriteLine($"Czas wykonania funkcji: {stopwatch.Elapsed.TotalMilliseconds} ms");
        // Opcjonalnie, możemy wyświetlić wynikową macierz
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Console.Write($"{MatrixA[i, j]:F2} " + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Console.Write($"{MatrixL[i, j]:F2} " + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Console.Write($"{MatrixU[i, j]:F2} " + "\t");
            }
            Console.WriteLine();
        }

        for (x = 0; x != nr_size; x++)
        {
            for (y = 0; y != 9; y++)
            {
                if (nr[x, y] == null)
                {
                    nr[x, y] = "";
                }
                else
                {
                    Console.Write(nr[x, y]);
                    Console.Write("|");
                }
            }
            Console.WriteLine("");
        }
        for (int x2 = 0; x2 != nr_size; x2++)//kopiowanie i,j,k
        {
            nr3[x2, 1] = nr[x2, 1];
            nr3[x2, 2] = nr[x2, 2];
            nr3[x2, 3] = nr[x2, 3];
            nr3[x2, 4] = nr[x2, 4];
        }
        Console.WriteLine("-------------------------------------");

        for (int x2 = 0; x2 != nr_size; x2++)
        {

            for (x = x2 + 1; x != nr_size; x++)
            {
                if (nr[x2, 5] == nr[x, 5])
                {
                    nr3[x2, 7] = nr[x, 2] + "," + nr[x, 3] + "," + nr[x, 4] + "P";
                    break;
                }
                else
                {
                    nr3[x2, 7] = "BRAK ";
                }
            }
        }
        for (int x2 = 0; x2 != nr_size; x2++)
        {

            for (x = x2 + 1; x != nr_size; x++)
            {
                if (nr[x2, 5] == nr[x, 7] && (nr3[x2, 7] == "BRAK "))
                {
                    nr3[x2, 7] = nr[x, 2] + "," + nr[x, 3] + "," + nr[x, 4] + "U";
                    break;
                }

            }
        }

        for (int x2 = 0; x2 != nr_size; x2++)
        {

            for (x = x2 + 1; x != nr_size; x++)
            {
                if (nr[x2,6] == nr[x,6])
                {
                    nr3[x2, 5] = nr[x,2] + "," + nr[x, 3] + "," + nr[x, 4];
                    break;
                }
                else
                {
                    nr3[x2, 5] = "BRAK ";
                }
            }
        }

        for (int x2 = 0; x2 != nr_size; x2++)
        {

            for (x = x2 + 1; x != nr_size; x++)
            {
                if (nr[x2, 7] == nr[x, 7])
                {
                    nr3[x2, 6] = nr[x, 2] + "," + nr[x, 3] + "," + nr[x, 4];
                    break;
                }
                else
                {
                    nr3[x2, 6] = "BRAK ";
                }
            }
        }



        for (x = 0; x != nr_size; x++)//wypisywanie tabeli nr3
        {
            for (y = 0; y != 8; y++)
            {
                if (nr3[x, y] == null)
                {
                    nr3[x, y] = "";
                }
                else
                {
                    Console.Write(nr3[x, y]);
                    Console.Write("|");
                }
            }
            Console.WriteLine("");


        }
    }
}