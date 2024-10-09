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
            double randomValueInRange =(Convert.ToDouble(rand));
            return randomValueInRange;
        }



        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        int Size = 3; // Zmienna do testów, możesz zmienić na potrzebną wartość

         
         
         
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
    }
}