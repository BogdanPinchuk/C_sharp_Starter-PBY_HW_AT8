using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp3
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            #region Введення чисел і вибір методу розрахунку
            Console.WriteLine("Введіть 3 цілих числа: \n");
            // для массиву чисел, що будуть вводитись
            int[] a = new int[3];

            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"\ta{i} = ");
                bool error = int.TryParse(Console.ReadLine(), out a[i]);
                // аналіз чи можна далі продовжувати 
                AnaliseOfInputNumber(error);
            }

            Console.WriteLine("\nВиберіть метод розрахунку: \n");
            Console.WriteLine("Т - з врахуванням інкрементування;");
            Console.WriteLine("Н - без врахування інкрементування;");
            // вибір як рахувати
            bool calc = true;

            Console.Write("\t");

            switch (Console.ReadKey(true).KeyChar.ToString().ToLower())
            {
                case "т":
                case "n":   // можливо забули переключити розкладку клавіатури
                    calc = true;
                    break;
                case "н":
                case "y":   // можливо забули переключити розкладку клавіатури
                    calc = false;
                    break;
                default:    // помилка вводу
                    AnaliseOfInputNumber(false);
                    break;
            }
            #endregion

            // Вивід результатів
            Console.WriteLine();
            if (calc)
            {
                Console.WriteLine($"Сума з інкрементуванням: {Calculate(ref a, calc):N0}");
                Console.WriteLine("\nІнкрементовані дані:");
                for (int i = 0; i < a.Length; i++)
                {
                    Console.Write($"\ta{i} = {a[i]:N0}\n");
                }
            }
            else
            {
                Console.WriteLine($"Сума без інкрементування: {Calculate(ref a, calc):N0}");
            }

            // повторення
            DoExitOrRepeat();
        }

        /// <summary>
        /// Базовий метод за яким вибираэться чи робити інкрементування
        /// </summary>
        /// <param name="mas">Масив вхідних даних</param>
        /// <param name="calc">Вибір: true - з інкрементом, false - без інкременту</param>
        /// <returns></returns>
        static int Calculate(ref int[] mas, bool calc)
        {
            if (calc)
            {
                return Calculate(ref mas);
            }
            else
            {
                return Calculate(mas);
            }
        }

        /// <summary>
        /// Метод який повертає тільки сумму
        /// </summary>
        /// <param name="mas">Масив вхідних даних</param>
        /// <returns></returns>
        static int Calculate(int[] mas)
        {
            // визначення суми через функції колекцій
            return mas.Sum();
        }

        /// <summary>
        /// Метод, який інкрементує і повертає їхню суму
        /// </summary>
        /// <param name="mas">Масив вхідних даних</param>
        /// <returns></returns>
        static int Calculate(ref int[] mas)
        {
            // Інкрементування через лямда-вираз (компактніше за цикли)
            mas = mas.Select(t => ++t).ToArray();

            // визначення суми через функції колекцій
            return mas.Sum();
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
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}
