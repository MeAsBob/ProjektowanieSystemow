using System.ComponentModel;
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
        int[,] MatrixCalculator(int[,] matrix1, int[,] matrix2)
        {
            int rowsA = matrix1.GetLength(0); // Liczba wierszy macierzy A
            int colsA = matrix1.GetLength(1); // Liczba kolumn macierzy A
            int rowsB = matrix2.GetLength(0); // Liczba wierszy macierzy B
            int colsB = matrix2.GetLength(1); // Liczba kolumn macierzy B

            // Sprawdzenie zgodności wymiarów
            if (colsA != rowsB)
            {
                throw new InvalidOperationException("Nie można pomnożyć macierzy: niezgodne wymiary.");
            }

            // Tworzenie macierzy wynikowej
            int[,] matrix3 = new int[rowsA, colsB];

            // Obliczanie wartości elementów wynikowej macierzy
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    matrix3[i, j] = sum;
                }
            }

            return matrix3;

        }
        string FromMatrix(int[,] matrix)
        {
            string pomoc = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    pomoc += matrix[i, j] +""; // Dodajemy elementy z wiersza
                }
            }
            return pomoc;

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
        int[,] Ft = { { 1, 1, 1 } };
        int[,] mnozna = new int[3, 1];
        int[,] wynik = new int[1, 1];
        int[,] wynik2 = new int[2, 1];
        int[,] Fs1 = { { 0, 1, -1 } };
        int[,] Fs2 = { { 0, 0, 1 } };
        int[,] Fs3 = { { 1, 0, 0 }, { 0, 0, 1 } };

        string[,] nr = new string[nr_size, 9];
        string[,] nr2 = new string[nr_size, 8];
        string[,] nr3 = new string[nr_size, 7];
        string[,] nr4 = new string[nr_size, 2];
        string[,] nr5 = new string[nr_size, 2];
        string[,] nr6 = new string[nr_size, 2];
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
        Console.Write("iter|i|j|k|jk|ji|ik|ii|\n");
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
            for (int x2 = 0; x2 != nr_size; x2++)//kopiowanie i,j,k dla tabeli nr2
        {
            nr2[x2, 1] = nr[x2, 1];
            nr2[x2, 2] = nr[x2, 2];
            nr2[x2, 3] = nr[x2, 3];
            nr2[x2, 4] = nr[x2, 4];
        }
        Console.WriteLine("-------------------------------------");

        for (int x2 = 0; x2 != nr_size; x2++)// Sprawdzanie Prostych do góry
        {

            for (x = x2 + 1; x != nr_size; x++)
            {
                if (nr[x2, 5] == nr[x, 5])
                {
                    nr2[x2, 7] = nr[x, 2] + "," + nr[x, 3] + "," + nr[x, 4] + "P";
                    break;
                }
                else
                {
                    nr2[x2, 7] = "BRAK ";
                }
            }
        }
        for (int x2 = 0; x2 != nr_size; x2++)//Spr ukośnych do góry
        {

            for (x = x2 + 1; x != nr_size; x++)
            {
                if (nr[x2, 5] == nr[x, 7] && (nr2[x2, 7] == "BRAK "))
                {
                    nr2[x2, 7] = nr[x, 2] + "," + nr[x, 3] + "," + nr[x, 4] + "U";
                    break;
                }

            }
        }

        for (int x2 = 0; x2 != nr_size; x2++)//Spr  jakeś strony part 1
        {

            for (x = x2 + 1; x != nr_size; x++)
            {
                if (nr[x2, 6] == nr[x, 6])
                {
                    nr2[x2, 5] = nr[x, 2] + "," + nr[x, 3] + "," + nr[x, 4];
                    break;
                }
                else
                {
                    nr2[x2, 5] = "BRAK ";
                }
            }
        }

        for (int x2 = 0; x2 != nr_size; x2++)//part 2
        {

            for (x = x2 + 1; x != nr_size; x++)
            {
                if (nr[x2, 7] == nr[x, 7])
                {
                    nr2[x2, 6] = nr[x, 2] + "," + nr[x, 3] + "," + nr[x, 4];
                    break;
                }
                else
                {
                    nr2[x2, 6] = "BRAK ";
                }
            }
        }


        Console.Write("iter|i|j|k|Prawo|Dół|Góra|\n");
        for (x = 0; x != nr_size; x++)//wypisywanie tabeli nr2
        {
            for (y = 0; y != 8; y++)
            {
                if (nr2[x, y] == null)
                {
                    nr2[x, y] = "";
                }
                else
                {
                    Console.Write(nr2[x, y]);
                    Console.Write("|");
                }
            }
            Console.WriteLine("");

        }
        Console.WriteLine("-------------------------------------");

        // Tworzenie i wypisywanie tabeli nr3
        for (int i = 0; i != nr_size - 1; i++)
        {
            mnozna[0, 0] = int.Parse(nr[i, 2]);
            mnozna[1, 0] = int.Parse(nr[i, 3]);
            mnozna[2, 0] = int.Parse(nr[i, 4]);
            wynik = MatrixCalculator(Ft, mnozna); 
            nr3[i, 0] = nr[i, 1];
            nr3[i, 1] = nr[i, 2] + "," + nr[i, 3] + "," + nr[i, 4];
            nr3[i, 2] = FromMatrix(wynik);
        }
        for (int i = 0; i != nr_size - 1; i++)
        {
            mnozna[0, 0] = int.Parse(nr[i, 2]);
            mnozna[1, 0] = int.Parse(nr[i, 3]);
            mnozna[2, 0] = int.Parse(nr[i, 4]);
            wynik = MatrixCalculator(Fs1, mnozna);

            nr3[i, 6] = FromMatrix(wynik);
            nr3[i, 3] = FromMatrix(wynik);
        }
        int najmniejsza_wartosc = 0;
        int pomoc = 0;
        for (int i = 0; i != nr_size - 1; i++)
        {
            pomoc = int.Parse(nr3[i, 3]);
            if (pomoc < najmniejsza_wartosc)
            {
                najmniejsza_wartosc = pomoc;
            }
        }
        najmniejsza_wartosc = najmniejsza_wartosc * -1; // zakładając że najmniejsza wartość jest na minusie
        for (int i = 0; i != nr_size - 1; i++)
        {
            pomoc = int.Parse(nr3[i, 3]);
            pomoc += najmniejsza_wartosc;
            nr3[i, 3] = pomoc.ToString();
        }


        for (int i = 0; i != nr_size - 1; i++)
        {
            mnozna[0, 0] = int.Parse(nr[i, 2]);
            mnozna[1, 0] = int.Parse(nr[i, 3]);
            mnozna[2, 0] = int.Parse(nr[i, 4]);
            wynik = MatrixCalculator(Fs2, mnozna);
            nr3[i, 4] = FromMatrix(wynik);
        }

        for (int i = 0; i != nr_size - 1; i++)
        {
            mnozna[0, 0] = int.Parse(nr[i, 2]);
            mnozna[1, 0] = int.Parse(nr[i, 3]);
            mnozna[2, 0] = int.Parse(nr[i, 4]);
            wynik2 = MatrixCalculator(Fs3, mnozna);
            nr3[i, 5] = FromMatrix(wynik2);
        }
        Console.Write("iter|Współ|Ft|Fs1+najm|Fs2|Fs3|Fs1\n");
        for (x = 0; x != nr_size - 1; x++)
        {
            for (y = 0; y != 7; y++)
            {
                Console.Write(nr3[x, y]);
                Console.Write("|");
            }
            Console.WriteLine("");
        }
        Console.WriteLine("-------------------------------------");

        for (x = 0; x < nr_size; x++)// Robienie tablicy nr4
        {
            bool exists = false;

            // Sprawdzenie, czy "Ep" + nr3[x, 3] istnieje już w nr4
            for (int xy = 0; xy < x; xy++)
            {
                if (nr4[xy, 0] == "Ep" + nr3[x, 3])
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                nr4[x, 0] = "Ep" + nr3[x, 3];
                HashSet<string> uniqueValues = new HashSet<string>();//W HashSet wartość może wystąpić tylko raz

                for (y = x; y < nr_size; y++)
                {
                    if (nr3[x, 3] == nr3[y, 3])
                    {
                        string value = "K" + nr3[y, 0] + "(" + nr3[y, 2] + ")";
                        uniqueValues.Add(value);
                    }
                }

                // Dodanie unikalnych wartości do nr4[x, 1]
                nr4[x, 1] = string.Join(",", uniqueValues) + ",";
            }
        }
        Console.Write("Ep(Fs1)+najmniejsza|Wierzchołki w Macierzy (Takt)\n");
        for (x = 0; x != nr_size - 1; x++)// Wypisywanie tablicy nr4
        {
            bool exists = true;

            for (y = 0; y != 2; y++)
            {
                if (nr4[x, y] == null)
                {
                    exists = false;
                    break;
                    
                }
                else
                {
                    Console.Write(nr4[x, y]);
                    Console.Write("|");
                }
                
            }
            if (exists)
            {
                Console.WriteLine("");
            }
            
        }
        Console.WriteLine("-------------------------------------");

        for (x = 0; x < nr_size; x++)// Robienie tablicy nr5
        {
            bool exists = false;

            // Sprawdzenie, czy "Ep" + nr3[x, 3] istnieje już w nr5
            for (int xy = 0; xy < x; xy++)
            {
                if (nr5[xy, 0] == "Ep" + nr3[x, 4])
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                nr5[x, 0] = "Ep" + nr3[x, 4];

                // Użycie HashSet, aby zapobiec duplikatom w nr5[x, 1]
                HashSet<string> uniqueValues = new HashSet<string>();

                for (y = x; y < nr_size; y++)
                {
                    if (nr3[x, 4] == nr3[y, 4])
                    {
                        string value = "K" + nr3[y, 0] + "(" + nr3[y, 2] + ")";
                        uniqueValues.Add(value);
                    }
                }

                // Dodanie unikalnych wartości do nr5[x, 1]
                nr5[x, 1] = string.Join(",", uniqueValues) + ",";
            }
        }
        Console.Write("Ep(Fs2)|Wierzchołki w Macierzy (Takt)\n");
        for (x = 0; x != nr_size - 1; x++)// Wypisywanie tablicy nr5
        {
            bool exists = true;

            for (y = 0; y != 2; y++)
            {
                if (nr5[x, y] == null)
                {
                    exists = false;
                    break;

                }
                else
                {
                    Console.Write(nr5[x, y]);
                    Console.Write("|");
                }

            }
            if (exists)
            {
                Console.WriteLine("");
            }

        }
        Console.WriteLine("-------------------------------------");
        for (x = 0; x < nr_size; x++)// Robienie tablicy nr6
        {
            bool exists = false;

            // Sprawdzenie, czy "Ep" + nr3[x, 3] istnieje już w nr6
            for (int xy = 0; xy < x; xy++)
            {
                if (nr6[xy, 0] == "Ep" + nr3[x, 5])
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                nr6[x, 0] = "Ep" + nr3[x, 5];

                // Użycie HashSet, aby zapobiec duplikatom w nr6[x, 1]
                HashSet<string> uniqueValues = new HashSet<string>();

                for (y = x; y < nr_size; y++)
                {
                    if (nr3[x, 5] == nr3[y, 5])
                    {
                        string value = "K" + nr3[y, 0] + "(" + nr3[y, 2] + ")";
                        uniqueValues.Add(value);
                    }
                }

                // Dodanie unikalnych wartości do nr6[x, 1]
                nr6[x, 1] = string.Join(",", uniqueValues) + ",";
            }
        }
        Console.Write("Ep(Fs3)|Wierzchołki w Macierzy (Takt)\n");
        for (x = 0; x != nr_size - 1; x++)// Wypisywanie tablicy nr6
        {
            bool exists = true;

            for (y = 0; y != 2; y++)
            {
                if (nr6[x, y] == null)
                {
                    exists = false;
                    break;

                }
                else
                {
                    Console.Write(nr6[x, y]);
                    Console.Write("|");
                }

            }
            if (exists)
            {
                Console.WriteLine("");
            }

        }
    }
}