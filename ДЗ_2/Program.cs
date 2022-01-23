using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк массива");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов массива");
            int m = int.Parse(Console.ReadLine());
            int[,] a = new int[n, m];

            for (int i = 0; i < n; i++)

                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine("Введите X{0},{1} эллемент массива A", i, j);
                    a[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0}\t", a[i, j]);  //до операций  
                }
            }
            Console.WriteLine();
            Console.WriteLine("Для инверсии элементов матрицы построчно нажмите 1 ");
            Console.WriteLine("Для cортировкм элементов матрицы построчно (в двух направлениях) нажмите 2 ");
            Console.WriteLine("Для нахождения количества положительных/отрицательных чисел в матрице нажмите 3 ");

            int ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1:                                                     // инверсия
                    {
                        for (int i = 0; i < a.GetLength(1) / 2; i++)
                            for (int j = 0; j < a.GetLength(0); j++)
                            {
                                int temp = a[j, i];
                                a[j, i] = a[j, a.GetLength(1) - i - 1];
                                a[j, a.GetLength(1) - i - 1] = temp;
                            }
                        for (int i = 0; i < a.GetLength(0); i++)
                        {
                            for (int j = 0; j < a.GetLength(1); j++)
                                Console.Write("{0}\t ", a[i, j]);      
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        Console.WriteLine();

                        break;
                    }
                case 2:                                                      // сортировка
                    {
                        Console.WriteLine("Для сортировки слева-направо нажмите 1 ");
                        Console.WriteLine("Для сортировки справа-налево нажмите 2 ");

                        int cs = int.Parse(Console.ReadLine());

                        switch (cs)
                        {
                            case 1:                                            // сортировка слева-направо
                                {
                                    int sort;

                                    for (int i = 0; i < n; i++)
                                        for (int j = 0; j < m; j++)
                                        {
                                            for (int r = j + 1; r < m; r++)
                                            {
                                                if (a[i, j] > a[i, r])
                                                {
                                                    sort = a[i, j];
                                                    a[i, j] = a[i, r];
                                                    a[i, r] = sort;
                                                }
                                            }
                                        }
                                    for (int i = 0; i < n; i++)
                                    {
                                        for (int j = 0; j < m; j++)
                                            Console.Write("{0}\t ", a[i, j]);
                                        Console.WriteLine();
                                    }
                                    break;
                                }
                            case 2:                                        // сортировка справа-налево
                                {
                                    int sortb;

                                    for (int i = 0; i < n; i++)
                                        for (int j = 0; j < m; j++)
                                        {
                                            for (int r = j + 1; r < n; r++)
                                            {
                                                if (a[i, j] < a[i, r])
                                                {
                                                    sortb = a[i, j];
                                                    a[i, j] = a[i, r];
                                                    a[i, r] = sortb;
                                                }
                                            }
                                            
                                        }
                                    for (int i = 0; i < n; i++)
                                    {
                                        for (int j = 0; j < m; j++)
                                            Console.Write("{0}\t ", a[i, j]);
                                        Console.WriteLine();
                                    }
                                    break;
                                }

                        }
                        break;
                    } 
                case 3:                                                    // положительные-отрицательные
                    {
                        int resultpl = 0;
                        int resultmi = 0;
                        int resultnu = 0;

                        foreach (int number in a)
                        {
                            if (number > 0)
                            {
                                resultpl++;
                            }
                            else if (number < 0)
                                {
                                    resultmi++;
                                }
                                else
                                {
                                    resultnu++;
                                }
                        }
                        Console.WriteLine($"Число элементов меньше нуля: {resultmi}");
                        Console.WriteLine($"Число элементов больше нуля: {resultpl}");
                        Console.WriteLine($"Число элементов равных нулю: {resultnu}");

                        break;
                    }          
        }   
            Console.ReadKey();
        }
    }

}
