using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Пользователь\source\repos\ДЗ\ConsoleApp1\Text.txt";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    var str = sr.ReadToEnd();

                    var words = str.Split(' ');


                    Console.WriteLine(str);

                    Console.WriteLine("Для нахождения слов, содержащих больше всего цифр нажмите 1 ");
                    Console.WriteLine("Для нахождения самого длинного слова в тексте нажмите 2 ");
                    Console.WriteLine("Для написания цифр буквами нажмите 3 ");
                    Console.WriteLine("Для вывода на экран сначала вопросительных, а затем восклицательных предложений нажмите 4 ");
                    Console.WriteLine("Для вывода на экран предложений без зарятых нажмите 5 ");
                    Console.WriteLine("Для вывода слов, начинающихся и заканчивающихся на одну и ту же букву, нажмите 6 ");

                    int ch = int.Parse(Console.ReadLine());

                    switch (ch)
                    {
                        case 1:
                            {
                                int max = 0;
                                int index = 0;

                                for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
                                {
                                    int digitscount = 0;

                                    for (int letterIndex = 0; letterIndex < words[wordIndex].Length; letterIndex++)
                                    {
                                        if (char.IsNumber(words[wordIndex][letterIndex]))
                                        {
                                            digitscount++;
                                        }
                                    }

                                    if (digitscount > max)
                                    {
                                        max = digitscount;
                                        index = wordIndex;
                                    }
                                }

                                for (int i = 0; i < words.Length; i++)
                                {
                                    int digitscount = 0;

                                    for (int letterIndex = 0; letterIndex < words[i].Length; letterIndex++)
                                    {
                                        if (char.IsNumber(words[i][letterIndex]))
                                        {
                                            digitscount++;
                                        }
                                    }

                                    if (max == digitscount)
                                    {
                                        Console.WriteLine("Наибольше цифр в слове " + words[i]);
                                    }

                                }

                                break;
                            }
                        case 2:
                            {
                                int max = 0;
                                int index = 0;

                                for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
                                {
                                    if (words[wordIndex].Length > max)
                                    {
                                        max = words[wordIndex].Length;
                                        index = wordIndex;
                                    }
                                }

                                for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
                                {
                                    if (words[wordIndex].Length == max)
                                    {
                                        Console.WriteLine("Самое длинное слово " + words[wordIndex]);
                                    }
                                }

                                break;
                            }
                        case 3:
                            {
                                str = str.Replace("1", "один").Replace("2", "два").Replace("3", "три").Replace("4", "четыре").Replace("5", "пять").Replace("6", "шесть").Replace("7", "семь").Replace("8", "восемь").Replace("9", "девять").Replace("0", "ноль");
                                Console.WriteLine(str);

                                break;
                            }
                        case 4:
                            {
                                var words1 = str.Split('.');
                                foreach (string stroka in words1)
                                {
                                    if (stroka.Contains('?') == true)
                                    {
                                        string trimmed = stroka.Trim();
                                        Console.WriteLine(trimmed.Substring(0, trimmed.IndexOf('?') + 1));
                                    }
                                }
                                foreach (string stroka in words1)
                                {
                                    if (stroka.Contains('!') == true)
                                    {
                                        string trimmed = stroka.Trim();
                                        Console.WriteLine(trimmed.Substring(0, trimmed.IndexOf('!') + 1));
                                    }
                                }

                                break;
                            }
                        case 5:
                            {
                                string[] sentences = str.Split(new[] { '.', '!', '?' });
                                foreach (string sentence in sentences)
                                {
                                    if (!sentence.Contains(','))
                                        Console.WriteLine(sentence.Trim());
                                }
                                break;
                            }
                        case 6:
                            {
                                foreach (var word in words)
                                {
                                    if (word.Length > 1 && word[0] == word[word.Length - 1])
                                    {
                                        Console.WriteLine(word);
                                    }
                                }
                                break;
                            }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();


        }
    }
}
