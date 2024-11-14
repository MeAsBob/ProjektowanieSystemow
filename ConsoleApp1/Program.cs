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

        int Size = 6; // Zmienna do testów, możesz zmienić na potrzebną wartość
        string[,] nr = new string[100, 7];
        string[,] nr2 = new string[100, 7];
        string[,] nr3 = new string[100, 7];
        int iter = 1;
        int iter2 = 1;
        //int iter3 = 1;
        int x = 0;
        int x2 = 0;
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
                    nr[x, y] = (iter).ToString();
                    iter++;
                    y++;
                    nr[x, y] = (i).ToString();
                    y++;
                    nr[x, y] = (j).ToString();
                    y++;
                    nr[x, y] = (i).ToString();
                    y++;
                    nr[x, y] = (j).ToString() + "," + (i).ToString();
                    y++;
                    nr[x, y] = (j).ToString() + "," + (i).ToString();
                    y++;
                    nr[x, y] = (i).ToString() + "," + (i).ToString();
                    x++;
                    y = 0;
                }
                else
                {
                    MatrixL[j, i] = 0.0;
                    nr[x, y] = (iter).ToString();
                    iter++;
                    y++;
                    nr[x, y] = (i).ToString();
                    y++;
                    nr[x, y] = (j).ToString();
                    y++;
                    nr[x, y] = (i).ToString();
                    y++;
                    nr[x, y] = (j).ToString() + "," + (i).ToString();
                    y++;
                    nr[x, y] = (j).ToString() + "," + (i).ToString();
                    y++;
                    nr[x, y] = (i).ToString() + "," + (i).ToString();
                    x++;
                    y = 0;
                }

                for (int k = i; k < Size; k++)
                {
                    MatrixU[j, k] -= MatrixL[j, i] * MatrixU[i, k]; // ajk = ajk - lji * aik
                    nr2[x2, y] = (iter2).ToString();
                    iter2++;
                    y++;
                    nr2[x2, y] = (i).ToString();
                    y++;
                    nr2[x2, y] = (j).ToString();
                    y++;
                    nr2[x2, y] = (k).ToString();
                    y++;
                    nr2[x2, y] = (j).ToString() + "," + (k).ToString();
                    y++;
                    nr2[x2, y] = (j).ToString() + "," + (i).ToString();
                    y++;
                    nr2[x2, y] = (i).ToString() + "," + (k).ToString();
                    x2++;
                    y = 0;
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



        x = 0;
        x2 = 0;
        y = 0;
        for (x = 0; x != 100; x++)
        {
            for (y = 0; y != 7; y++)
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
        y = 0;
        Console.WriteLine("-----------------------------------");
        for (x2 = 0; x2 != 100; x2++)
        {
            for (y = 0; y != 7; y++)
            {
                if (nr2[x2, y] == null)
                {
                    nr2[x2, y] = "";
                }
                else
                {
                    Console.Write(nr2[x2, y]);
                    Console.Write("|");
                }
            }
            Console.WriteLine("");
        }
    }
}