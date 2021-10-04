using System;
using System.Collections.Generic;


namespace ConsoleApp1
{
    class Program
    {

        static int findL(int[][] matrix)
        {
            int max = 0; // переменная для записи максимального произведения
            int com; // переменная для записи произведения
            int L = -1; // переменная для записи искомого L

            for (int l = 0; l < matrix.Length; l++)     // пробегаемся по элементам массива через строки
            {
                com = 1;
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix.Length; j++)
                    {
                        if (i == l)
                        {
                            com = com * matrix[i][j];
                        }
                    }
                }
                if (com > max) // поиск максимального произведения
                {
                    max = com;
                    L = l; // записываем число строки с большим произведением в L
                }
            }
            return L;
        }

        static int findK(int[][] matrix)
        {
            int max = 0; // переменная для записи максимального произведения
            int com; // переменная для записи произведения
            int K = -1; // переменная для записи искомого K

            for (int k = 0; k < matrix.Length; k++)    // пробегаемся по элементам массива через столбцы
            {
                com = 1;
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix.Length; j++)
                    {
                        if (j == k)
                        {
                            com = com * matrix[i][j];
                        }
                    }
                }
                if (com > max) // поиск максимального произведения
                {
                    max = com;
                    K = k; // записываем число строки с большим произведением в K
                }
            }
            return K;
        }

        static List<int> сutArrFromMatrixRows(int[][] matrix, int row)
        {
            List<int> newrow = new List<int>();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (i == row)
                    {
                        newrow.Add(matrix[i][j]);
                    }
                }
            }
            return newrow;
        }

        static List<int> сutArrFromMatrixColumn(int[][] matrix, int col)
        {
            List<int> newcol = new List<int>();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (j == col)
                    {
                        newcol.Add(matrix[i][j]);
                    }
                }
            }
            return newcol;
        }

        static List<int> createVector(List<int> L, List<int> K)
        {
            List<int> B = new List<int>();

            for (int i = 0; i < L.Count * 2; i++)
            {
                if (i % 2 == 0)
                {
                    B.Add(K[i / 2] - L[i / 2]);
                }
                else
                {
                    B.Add(K[i / 2] + L[i / 2]);
                }
            }
            return B;

        }
        static void Main(string[] args)
        {
            int[][] matrix = new int[3][];

            matrix[0] = new int[3] { 1, 2, 3 };
            matrix[1] = new int[3] { 4, 5, 6 };
            matrix[2] = new int[3] { 7, 8, 9 };

            int L = findL(matrix);
            int K = findK(matrix);

            List<int> maxcol = сutArrFromMatrixColumn(matrix, K);
            List<int> maxrow = сutArrFromMatrixRows(matrix, L);

            for (int i = 0; i < createVector(maxrow, maxcol).Count; i++)
            {
                Console.Write((createVector(maxrow, maxcol)[i]) + " ");
            }

        }
    }
}
