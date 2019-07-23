using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// А для чого зберігати дані?

namespace LesApp4
{
    class Program
    {
        // кількість чоловік
        static int nMen = 2;
        // імена
        static string[] names;
        // ставка ЗП за день
        static double[] pays;

        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            #region Введення чисел і вибір методу розрахунку
            Console.WriteLine("Введіть дані по співробітниках: \n");

            // для массиву чисел, що будуть вводитись
            // кількість чоловік
            int nMen = Program.nMen;
            // імена
            string[] names = new string[nMen];
            // ставка ЗП за день
            double[] pays = new double[nMen];

            // почерговий ввід
            for (int i = 0; i < names.Length; i++)
            {
                Console.Write($"\nІм'я {i + 1}-го співробітника: ");
                names[i] = Console.ReadLine();

                Console.Write($"Денна ставка {i + 1}-го співробітника: ");
                bool error = double.TryParse(Console.ReadLine().Replace(".", ","), out pays[i]);
                // аналіз чи можна далі продовжувати
                if (!error || pays[i] <= 0) // будь яка робота повинна оплачуватися
                {
                    AnaliseOfInputNumber(false);
                }
            }

            // Збереження даних
            SaveData(names, pays);
            #endregion

            for (; ; )
            {
                Console.Write("\nВведіть ім'я: ");
                string name = Console.ReadLine();

                #region номер найденого співробітника
                int num = 0;
                for (; num < names.Length; num++)
                {
                    if (name == names[num])
                    {
                        break;
                    }
                }

                if (num == names.Length)
                {
                    Console.WriteLine("Такий співробітник не найдений.");

                    Console.Write("\nПовторити пошук: [т, н]\n");
                    bool repeat = false;

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

                    if (repeat)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                #endregion

                // кількість місяців
                int months;

                // введення кількості відпрацьованих місяців
                for (; ; )
                {
                    Console.Write($"\nВведіть кількість місяців які він працював: ");
                    bool error = int.TryParse(Console.ReadLine(), out months);
                    if (!error || months < 0)
                    {
                        Console.WriteLine("Невірне введення даних.");

                        Console.Write("\nПовторити ввід: [т, н]\n");
                        bool repeat = false;

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

                        if (repeat)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }

                    break;
                }

                // розрахунок ЗП
                Calc(names[num], pays[num], months);
                
                {   // повторення
                    Console.Write("\nПовторити розрахунок для іншого співробітника: [т, н]\n");
                    bool repeat = false;

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

                    if (repeat)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // повторення
            DoExitOrRepeat();
        }
        
        /// <summary>
        /// Розрахунок ЗП за первний період часу
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pay"></param>
        /// <param name="months"></param>
        /// <returns></returns>
        static void Calc(string name, double pay, int months)
        {
            Console.WriteLine("\nРезультат: \n");
            Console.WriteLine($"\tСпівробітник: {name}");
            Console.WriteLine($"\tДенна ставка: {pay:N2} грн");
            Console.WriteLine($"\tВідпрацював: {months:N0} місяців");

            // сума до сплати
            double res = months * (30 - 8) * pay;
            Console.WriteLine($"\tЗарплатня: {res:N2} грн");
        } 

        /// <summary>
        /// Збереження даних
        /// </summary>
        /// <param name="names"></param>
        /// <param name="pays"></param>
        static void SaveData(string[] names, double[] pays)
        {
            Program.names = names;
            Program.pays = pays;
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
