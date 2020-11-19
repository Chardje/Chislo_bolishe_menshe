using System;

namespace Chislo_bolishe_menshe
{
    class Program
    {
        static Random R = new Random();
        static int max_zagad_chislo, b, zagad_chislo, chiclo_pred_bot = 0;
        static char Bol_Mensh;
        static byte i, regim_Game;
        static bool wriosh;
        static void Main()
        {
            if (Game_start())
            {
                Game_Bot_Otgad();

            }
            else
            {
                Bot_Zagad();
            }
        }
        static bool Game_start()
        {

            while (true)
            {
                try
                {
                    while (true)
                    {

                        Console.WriteLine("Виберете режим игри: №1 bot otgadivat, №2 bot zagad.");
                        Console.Write("Я вибираю режим игри №");
                        regim_Game = Convert.ToByte(Console.ReadLine());
                        if (regim_Game == 1)
                        {

                            return true;

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

        #region game1
        static void Game_Bot_Otgad()
        {
            //
            //1-человек загадивает число
            Chelovek_Zagad_Chislo();
            chiclo_pred_bot = max_zagad_chislo;
            //2-бот говорит число 
            while (true)
            {
                Bot_gov_chisl();
                //3 ти говориш оно больше мньше
                Ti_gov_bolsh_or_mensh();
                //4 проверка так ли ето
                write_tr_or_fl();
                //5 бот ищит число дальше
                if (wriosh)
                {
                    WriteWranio();
                    break;
                }
                else if (chiclo_pred_bot == zagad_chislo)
                {
                    Console.WriteLine("Поздровляю, бот вийграл!!!");
                    break;
                }
            }
        }
        static void Chelovek_Zagad_Chislo()
        {
            while (true)
            {
                try
                {

                    Console.Write("Виберете диапазон загадоного числа: ");
                    max_zagad_chislo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    do
                    {
                        Console.Write("Ви загадали число: ");
                        zagad_chislo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (max_zagad_chislo < zagad_chislo)
                        {
                            WriteError();
                        }
                    } while (max_zagad_chislo < zagad_chislo);

                    return;
                }
                catch
                {
                    WriteError();
                }
            }
        }
        static void Bot_gov_chisl()
        {
            chiclo_pred_bot = chiclo_pred_bot / 2;
            Console.WriteLine($"Бот говорит число: {chiclo_pred_bot}");
        }
        static void Ti_gov_bolsh_or_mensh()
        {
            while (true)
            {
                try
                {
                    Console.Write($"Число{chiclo_pred_bot} больше или меньше?(>-больше,<-меньше,=-равно):");
                    Bol_Mensh = Convert.ToChar(Console.ReadLine());
                    Console.WriteLine();
                    if (Bol_Mensh == '>' || Bol_Mensh == '<' || Bol_Mensh == '=')
                    {
                        break;
                    }
                    WriteError();
                }
                catch
                {
                    WriteError();
                }
            }

        }
        static void write_tr_or_fl()
        {

            if (Bol_Mensh == '>')
            {
                if (chiclo_pred_bot > zagad_chislo)
                {
                    wriosh = false;
                }
                else if (chiclo_pred_bot < zagad_chislo)
                {
                    wriosh = true;
                }
                else
                {
                    wriosh = true;
                }
            }
            else if (Bol_Mensh == '<')
            {
                if (chiclo_pred_bot > zagad_chislo)
                {
                    wriosh = true;
                }
                else if (chiclo_pred_bot < zagad_chislo)
                {
                    wriosh = false;
                }
                else
                {
                    wriosh = true;
                }
            }
            else
            {
                if (chiclo_pred_bot > zagad_chislo)
                {
                    wriosh = true;
                }
                else if (chiclo_pred_bot < zagad_chislo)
                {
                    wriosh = true;
                }
                else
                {
                    wriosh = false;
                }
            }


        }
        #endregion
        #region game2
        static void Bot_Zagad()
        {
            bot_pridumivaet_chislo();
            while (true)
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
                    zagad_chislo = R.Next(0, max_zagad_chislo);
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
            if (zagad_chislo == b)
            {
                Console.WriteLine($"Поздровляю!!! Ви вийграли за {i} ходов");
                return true;
            }
            else if (zagad_chislo < b)
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
        #endregion
        #region write
        static void WriteError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ви не правильно ввели значение, введите ещо раз, но теперь правильно.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void WriteWranio()
        {
            switch (R.Next(0, 5))
            {
                case (0):
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ОН ВРЬОТ!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case (1):
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ОБМАНИВАТЬ ПЛОХО!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case (2):
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("НЕ ВРИ!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case (3):
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Арбуз!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case (4):
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ТИ ЗНАЕШ, ШТО ВРЬОШ КОМП'ЮТЕРУ?");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case (5):
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("АГРУС!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
        #endregion
    }
}
   

