using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cheto
{
    internal class BankTransaction
    {
        DateTime Operation {  get; set; }
        
        readonly double money;

        public BankTransaction(double money)
        {
            Operation = DateTime.Now;
            this.money = money;
        }

        public string DataOnTheMonetaryTransaction()
        {
            return($"{Operation} была создана транзакция на сумму {money} рублей\n");
        }
    }
}
