using System;

namespace Chislo_bolishe_menshe
{
    class Program
    {

        
         
        static void Main()
        {
            if (Game_start())
            {
                P1_vs_P2();
                
            }
            else
            {
                P1_vs_Bot();
            }
        }


        static bool Game_start( )
        {
            byte c = 0;
            while (true)
            {
                try
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Виберете режим игри: №1 P1 vs P2, №2 Bot vs P1");
                        Console.Write("Я вибираю режим игри №");
                        c = Convert.ToByte(Console.ReadLine());
                        if (c == 1)
                        {

                            return  true;

                        }
                        else if (c == 2)
                        {
                            return false;

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ви не правильно ввели значение, введите ещо раз, но теперь правильно.");

                        }
                    }

                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ви не правильно ввели значение, введите ещо раз, но теперь правильно.");

                }
            }
        }
        static void P1_vs_P2()
        {

        }
        static void P1_vs_Bot()
        {                    
            Random R = new Random();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Введите до кокого числа бот будет придумивать число: ");
            int a;
            int b;
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    a = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ви не правильно ввели значение, введите ещо раз, но теперь правильно.");
                }
            }
            int rnum = R.Next(0, a);
            byte i = 0;
            while(true)
            {
                i++;
                Console.Write("Введите число для сравнения: ");
                while (true) 
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (b <= a)
                        {
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ви не правильно ввели значение, введите ещо раз, но теперь правильно.");
                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ви не правильно ввели значение, введите ещо раз, но теперь правильно.");
                    }
                    
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{i}: ");
                if (rnum == b)
                {
                    Console.WriteLine($"Поздровляю!!! Ви вийграли за {i} ходов") ;
                    break;
                }
                else if (rnum < b)
                {
                    Console.WriteLine($"Загаданое число меньше {b}");
                }
                else
                {
                    Console.WriteLine($"Загаданое число больше {b}");
                }
            }         
        }

    }    
}
   

