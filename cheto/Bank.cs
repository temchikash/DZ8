using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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

        public Bank(BankType type,double balance)
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
        public void Money_Transfer(double money,Bank account_2)
        {
            balance -= money;
            account_2.balance += money;
            Console.WriteLine($"Вы перевели {money} рублей на счет {account_2.id}, ваш баланс  {balance} рублей");
        }
        public void Print()
        {
            Console.WriteLine($"Номер вашего счёта {id}, Тип {type}, Ваш баланс {balance} рублей. ");
        }
    }
       

    
}
