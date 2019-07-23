using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // число яке береться в факторіал
            int f = 5;

            // взято із 8 дз
            Console.WriteLine($"\n\tРезультат: {f}! = {FactorialNR(f):N0}");

            // повторення
            DoExitOrRepeat();
        }

        /// <summary>
        /// Розрахунок факторіалу, не рекомендований варіант
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        static int FactorialNR(int f)
        {
            if (f < 2)
            {
                return 1;
            }
            else
            {
                return f * FactorialNR(--f);
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
