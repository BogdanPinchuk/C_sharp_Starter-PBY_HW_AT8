using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("\tВведіть кількість співробітників: ");
            bool error = int.TryParse(Console.ReadLine(), out int employer);
            // аналіз чи можна далі продовжувати 
            if (!error || employer <= 0)
            {
                AnaliseOfInputNumber(false);
            }

            Console.Write("\tВартість одного трудодня співробітника: ");
            error = double.TryParse(Console.ReadLine().Replace(".", ","), out double pay);
            // аналіз чи можна далі продовжувати 
            if (!error || pay <= 0) // будь яка робота повинна оплачуватися
            {
                AnaliseOfInputNumber(false);
            }

            Console.Write("\tВведіть кількість днів які будуть оплачені: ");
            error = int.TryParse(Console.ReadLine(), out int days);
            // аналіз чи можна далі продовжувати 
            if (!error || days < 0)
            {
                AnaliseOfInputNumber(false);
            }

            // Вивід результату
            Console.WriteLine($"\n\tЗарплатня одному співробітнику: {Calc(pay, days):N2} грн");
            Console.WriteLine($"\tСумарна зарплатня всім співробітникам: {Calc(employer, pay, days):N2} грн");

            // повторення
            DoExitOrRepeat();
        }

        /// <summary>
        /// Розрахунок сумарної виплати
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="pay"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        static double Calc(int emp, double pay, int days)
        {
            return emp * Calc(pay, days);
        }

        /// <summary>
        /// Розрахунок сумарної виплати одному співробітнику
        /// </summary>
        /// <param name="pay"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        static double Calc(double pay, int days)
        {
            return pay * days;
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
