using System;

namespace Chislo_bolishe_menshe
{
    class Program
    {
        static Random R = new Random();
        static int max_zagad_chislo, b, rnum;
        static byte i, regim_Game = 0;
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
            
            while (true)
            {
                try
                {
                    while (true)
                    {
                       
                        Console.WriteLine("Виберете режим игри: №1 P1 vs P2, №2 Bot vs P1");
                        Console.Write("Я вибираю режим игри №");
                        regim_Game = Convert.ToByte(Console.ReadLine());
                        if (regim_Game == 1)
                        {

                            return  true;

                        }
                        else if (regim_Game == 2)
                        {
                            return false;

                        }
                        else
                        {
                            WriteError();

                        }
                    }

                }
                catch
                {
                    WriteError();

                }
            }
        }
        static void P1_vs_P2()
        {

        }
        static void P1_vs_Bot()
        {
            bot_pridumivaet_chislo();
            while(true)
            {
                ves_ch_sravn();
                if (write_srav())
                {
                    break;
                }
                
            }

        }
        static void bot_pridumivaet_chislo()
        {
            #region bot_pridumivaet_chislo            
            Console.Write("Введите до кокого числа бот будет придумивать число: ");
            while (true)
            {
                try
                {

                    max_zagad_chislo = Convert.ToInt32(Console.ReadLine());
                    rnum = R.Next(0, max_zagad_chislo);
                    return;
                }
                catch
                {
                    WriteError();
                }
            }
            
            #endregion
        }
        static bool write_srav()
        {
            #region write_srav
            Console.Write($"{i}: ");
            if (rnum == b)
            {
                Console.WriteLine($"Поздровляю!!! Ви вийграли за {i} ходов");
                return true;
            }
            else if (rnum < b)
            {
                Console.WriteLine($"Загаданое число меньше {b}");
            }
            else
            {
                Console.WriteLine($"Загаданое число больше {b}");
            }
            return false;
            #endregion
        }
        static void ves_ch_sravn()
        {
            #region ves_ch_sravn
            i++;
            Console.Write("Введите число для сравнения: ");
            while (true)
            {
                try
                {

                    b = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    if (b <= max_zagad_chislo)
                    {
                        return;
                    }
                    else
                    {
                        WriteError();
                    }
                }
                catch
                {
                    WriteError();
                }

            }
            #endregion
        }
        
        static void WriteError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ви не правильно ввели значение, введите ещо раз, но теперь правильно.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }    
}
   

