﻿using cheto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework8
{
    enum BankType
    {
        Сберегательный,
        Зарплатный
    }
    class Bank
    {
        private static uint id_account = 0;
        private uint id;
        private double balance;
        private BankType type;
        private Queue<BankTransaction> operations = new Queue<BankTransaction>();
        private bool disp = false;


        public void UnicID()
        {
            id_account++;
        }
        public Bank(double balance)
        {
            UnicID();
            this.balance = balance;
            id_account++;
            id = id_account;
        }

        public Bank()
        {

        }

        public Bank(BankType type, double balance)
        {

            UnicID();
            id_account++;
            this.type = type;
            this.balance = balance;
            id = id_account;
        }

        public Bank(BankType type)
        {
            UnicID();
            id_account++;
            id = id_account;
            this.type = type;
        }


        public void DepositMoney(double money)
        {
            if (money > 0)
            {

                BankTransaction operation = new BankTransaction(money);
                operations.Enqueue(operation);
                balance += money;
                Console.WriteLine($"Вы внесли на свой счёт {money} рублей, ваш баланс составляет {balance} рублей\n");
            }
            else
            {
                Console.WriteLine("Ошибка, сумма должна быть положительной\n");
            }
        }




        public void WithdrawalOfFunds(double money)
        {
            if (balance >= money)
            {
                BankTransaction operation = new BankTransaction(money);
                operations.Enqueue(operation);
                balance -= money;

                Console.WriteLine($"С вашего счёта снято {money} рублей, ваш баланс составляет {balance} рублей\n");
            }
            else
            {
                Console.WriteLine("Ошибка, на вашем счёте недостаточно средств, чтобы совершить операцию\n");
            }
        }




        public void Balance()
        {
            Console.WriteLine($"Ваш баланс составляет {balance} рублей\n");
        }




        public void Money_Transfer(double money, Bank account_2)
        {
            if (balance < money)
            {
                Console.WriteLine("Ошибка, на счёте недостаточно средств");
            }
            else
            {
                BankTransaction operation = new BankTransaction(money);
                operations.Enqueue(operation);
                balance -= money;
                account_2.balance += money;
                Console.WriteLine($"Вы перевели {money} рублей на счет {account_2.id}, ваш баланс  {balance} рублей");
            }


        }

        public void Print()
        {
            Console.WriteLine($"Номер вашего счёта {id}, Тип {type}, Ваш баланс {balance} рублей. ");
        }

        public void Dispose()
        {
            if (!disp)
            {
                foreach (BankTransaction place in operations)
                {
                    File.WriteAllText("operations.txt", place.DataOnTheMonetaryTransaction());
                    
                }
                operations.Clear();
                disp = true;

                GC.SuppressFinalize(this);
            }
        }
    }
       

    
}
