using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LesApp5
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // випадкові дані
            Random rnd = new Random();

            // ідентифікатори
            int[] a = new int[3];

            // заповнення даними
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rnd.Next(short.MinValue, short.MaxValue);
            }

            // вивід даних
            Console.WriteLine("Випадково згенеровані 3 цілі числа:");
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"\ta{i} = {a[i]:N0};");
            }

            for (; ; )
            {
                Console.WriteLine("\nВиди розрахунків:");
                Console.WriteLine("\t1) Отримує 3 цілі змінні і відображає на екрані результат суми");
                Console.WriteLine("\t2) Отримує 3 цілі змінні і відображає на екрані результат їх різниці");
                Console.WriteLine("\t3) Отримує 2 цілі змінні і відображає на екрані 1-е число в спепені другого");
                Console.WriteLine("\t4) Отримує 3 цілі змінні і відображає на екрані суму ціх значень в рядковому типі (пример: «3» + «4» + «5»)");
                Console.Write("\nВиберіть тип розрахунку: ");
                string manager = Console.ReadLine();

                // повторення пошуку
                bool repeat = false;

                switch (manager)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                        Manager(a, manager);
                        repeat = Calc();
                        break;
                    default:
                        Console.WriteLine("Такий тип не найдений.");
                        repeat = Calc();
                        break;
                }

                if (repeat)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

            // повторення
            DoExitOrRepeat();
        }

        /// <summary>
        /// Повторення розрахунку
        /// </summary>
        /// <returns></returns>
        static bool Calc()
        {
            Console.Write("\nПовторити пошук: [т, н]\n");
            bool repeat = true;

            switch (Console.ReadKey(true).KeyChar.ToString().ToLower())
            {
                case "т":
                case "n":   // можливо забули переключити розкладку клавіатури
                    repeat = true;
                    break;
                case "н":
                case "y":   // можливо забули переключити розкладку клавіатури
                    repeat = false;
                    break;
                default:    // помилка вводу
                    AnaliseOfInputNumber(false);
                    break;
            }

            return repeat;
        }


        /// <summary>
        /// Керуючий метод
        /// </summary>
        /// <param name="mas"></param>
        /// <param name="s"></param>
        static void Manager(int[] mas, string manage)
        {
            switch (manage)
            {
                case "1":
                    // 1) Отримує 3 цілі змінні і відображає на екрані результат суми
                    PrintResult(mas);
                    break;
                case "2":
                    // 2) Отримує 3 цілі змінні і відображає на екрані результат їх різниці
                    Console.WriteLine($"Результат: {PrintResult(ref mas):N0}");
                    break;
                case "3":
                    // 3) Отримує 2 цілі змінні і відображає на екрані 1-е число в спепені другого
                    PrintResult(mas[0], mas[1]);
                    break;
                case "4":
                    // 4) Отримує 3 цілі змінні і відображає на екрані суму ціх значень в рядковому типі (пример: «3» + «4» + «5»)
                    PrintResult(mas, out string s);
                    Console.WriteLine($"Результат: " + s);
                    break;
            }
        }


        /// <summary>
        /// 1) Отримує 3 цілі змінні і відображає на екрані результат суми
        /// </summary>
        static void PrintResult(int[] mas)
        {
            Console.WriteLine("\n1) Отримує 3 цілі змінні і відображає на екрані результат суми:");
            Console.WriteLine($"Результат: {mas.Sum():N0}");
        }

        /// <summary>
        /// 2) Отримує 3 цілі змінні і відображає на екрані результат їх різниці
        /// </summary>
        static double PrintResult(ref int[] mas)
        {
            Console.WriteLine("\n2) Отримує 3 цілі змінні і відображає на екрані результат їх різниці:");

            double res = mas[0];

            for (int i = 1; i < mas.Length; i++)
            {
                res -= mas[i];
            }

            return res;
        }

        /// <summary>
        /// 3) Отримує 2 цілі змінні і відображає на екрані 1-е число в спепені другого
        /// </summary>
        static void PrintResult(int a, int b)
        {
            Console.WriteLine("\n3) Отримує 2 цілі змінні і відображає на екрані 1-е число в спепені другого:");
            Console.WriteLine($"Результат: {Math.Pow(a, b):N2}");
        }

        /// <summary>
        /// 4) Отримує 3 цілі змінні і відображає на екрані суму ціх значень в рядковому типі (пример: «3» + «4» + «5»)
        /// </summary>
        static void PrintResult(int[] mas, out string s)
        {
            Console.WriteLine("\n4) Отримує 3 цілі змінні і відображає на екрані суму ціх значень в рядковому типі (пример: «3» + «4» + «5»)");

            s = mas[0].ToString();

            for (int i = 1; i < mas.Length; i++)
            {
                if (mas[i] >= 0)
                {
                    s += " + " + mas[i].ToString();
                }
                else
                {
                    s += " - " + Math.Abs(mas[i]).ToString();
                }
            }
        }

        /// <summary>
        /// Умова коли невірно введені дані
        /// </summary>
        /// <param name="res"></param>
        static void AnaliseOfInputNumber(bool res)
        {
            if (!res)
            {
                Console.WriteLine("\nНевірно введені дані!");
                DoExitOrRepeat();
            }
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}
