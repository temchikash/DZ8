using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using homework8;



namespace Lab
{
    internal class Program
    {
        static void DoNum1()
        {
            
            Bank account_1 = new Bank(BankType.Сберегательный);
            Bank account_2 = new Bank(BankType.Сберегательный);
            // типо приветствие в приложении банка///////
            Console.WriteLine("Вас приветствует бот-аудиоответчик нашего банка, чтобы я открыл доступ к воспользованию функциям банка,\n" +
                "мне необходима информация о вас\n" +
            "Введите имя и фамилию: \n ");
            string name_user = Console.ReadLine();
            Console.WriteLine("Лабораторная работа 9 главы\n");
            Console.WriteLine($"Здравствуйте {name_user}, хорошего вам настроения!\n" +
                $"Какой командой вы хотите воспользоваться?\n" +
                $"Пополнить баланс - нажмите 1.\n" +
                $"Снять средства со счёта - нажмите 2.\n" +
                $"Перевести средства с одного счёта на другой - нажмите 3.\n" +
                $"" +
                $"Проверить баланс - нажмите 4.\n" +
                $"Закончить все операции и выйти - нажмите 5.\n  ");
            account_1.Print();
            string function;
            do
            {
                Console.WriteLine("Введите номер необходимой операции");
                function = Console.ReadLine();
                switch (function)
                {
                    case "1":
                        Console.WriteLine("Введите сумму, которую вы хотите внести на свой счёт");
                        bool Deposit_cash = double.TryParse(Console.ReadLine(), out double cash);
                        if (!Deposit_cash)
                        {
                            do
                            {
                                Console.WriteLine("Ошибка, введите число");
                                Deposit_cash = double.TryParse(Console.ReadLine(),out cash);
                            } while (!Deposit_cash);
                        }
                        account_1.DepositMoney(cash);
                        account_1.Dispose();
                        break;
                    case "2":
                        Console.WriteLine("Введите сумму, которую вы хотите снять");
                        bool Withdrawal_Of_Funds = double.TryParse(Console.ReadLine(),out double withdrawal_cash);
                        if (!Withdrawal_Of_Funds)
                        {
                            do
                            {
                                Console.WriteLine("Ошибка, введите число");
                                Withdrawal_Of_Funds = double.TryParse(Console.ReadLine(), out withdrawal_cash);
                            } while (!Withdrawal_Of_Funds);
                        }
                        account_1.WithdrawalOfFunds(withdrawal_cash);
                        account_1.Dispose();
                        break;
                    case "3":
                        Console.WriteLine("Введите реквизиты клиента банка");
                        bool id_user = ulong.TryParse(Console.ReadLine(), out ulong Id_User);
                        if (!id_user)
                        {
                            do
                            {
                                Console.WriteLine("Ошибка, введите число");
                                id_user = ulong.TryParse(Console.ReadLine(), out Id_User);
                            }while(!id_user);
                        }
                        
                        
                        Console.WriteLine("Введите сумму перевода : \n");
                        bool money_nums = double.TryParse(Console.ReadLine(), out double money);
                        if (!money_nums)
                        {
                            do
                            {
                                Console.WriteLine("Ошибка, введите число");
                                money_nums = double.TryParse(Console.ReadLine(), out money);
                            } while (!money_nums);
                        }
                        account_1.Money_Transfer(money, account_2);
                        account_1.Dispose();
                        break;
                    case "4":
                        account_1.Balance();
                        break;

                    case "5":
                        break;
                    default:
                        Console.WriteLine("Вы ввели неверную комнаду\n");
                        break;

                }
            }while (!function.Equals("5"));
        }
        static void DoNum2()
        {
            Console.WriteLine("HomeWork1\n");

            Song MySong1 = new Song("Ирина Кайратовна", "5000");
            Song MySong2 = new Song("Ирина Кайратовна", "5000", MySong1);
            Song MySong3 = new Song("Special", "Yanix", MySong2);
            Song MySong4 = new Song("Мальчики", "163onmyneck", MySong3);
            Song MySong5 = new Song("Timati", "5000", MySong4);

            List<Song> list = new List<Song>() { MySong1, MySong2, MySong3, MySong4, MySong5 };
            for (int i = 0; i < list.Count; i++)
            {
                list[i].SongName();
                list[i].SongAuthor();
                if (i != 0)
                {
                    list[i].prev_song = list[i - 1];
                }
                list[i].Print();

            }

            if (list[1].Equals(list[4].prev_song))
            {
                Console.WriteLine($"Песня {list[1].Print()} и песня {list[4].prev_song.Print()} одинаковы ");
            }
            else
            {
                Console.WriteLine("Это разные песни");
            }
        }

        static void Main(string[] args)

        {
            DoNum1();
            DoNum2();
            

            Console.ReadKey(true);
        }
    }
}
