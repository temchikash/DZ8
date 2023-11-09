﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using homework8;



namespace homework7
{
    internal class Program
    {
        static void DoNum1()
        {
            
            Bank account_1 = new Bank(BankType.Сберегательный);
            Bank account_2 = new Bank(BankType.Сберегательный);
            Console.WriteLine("Как вас зовут?");
            string name_user = Console.ReadLine();
            
            Console.WriteLine($"Здравствуйте {name_user}!\n" +
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
    static void Main(string[] args)

        {
            DoNum1();
            

            Console.ReadKey(true);
        }
    }
}

















