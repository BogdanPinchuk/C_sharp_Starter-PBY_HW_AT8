using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // тестування перегрузок
            Console.WriteLine("Тестування перегрузок:");
            Console.WriteLine();

            Console.Write("\t");
            Method(new Random().Next(int.MinValue, int.MaxValue));
            Console.Write("\t");
            Method(new Random().NextDouble());
            Console.Write("\t");
            Console.WriteLine(Method(Math.PI, Math.E).ToString("N3"));
            Console.Write("\t");
            Console.WriteLine(Method(
                new Random().Next(int.MinValue, int.MaxValue),
                new Random().Next(ushort.MinValue + 1, ushort.MaxValue)));

            // повторення
            DoExitOrRepeat();
        }

        /// <summary>
        /// Виведення цілого числа
        /// </summary>
        /// <param name="a"></param>
        static void Method(int a)
        {
            Console.WriteLine(a);
        }

        /// <summary>
        /// Виведення дійсного числа
        /// </summary>
        /// <param name="a"></param>
        static void Method(double a)
        {
            Console.WriteLine($"{a:N3}");
        }

        /// <summary>
        /// Добуток двох чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static double Method(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Залишок від ділення
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int Method(int a, int b)
        {
            return a % b;
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
