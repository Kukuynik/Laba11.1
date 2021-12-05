using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba11._1
{
    class BankTransaction
    {
        readonly DateTime currentDateTime;
        readonly decimal amount;
        public BankTransaction(decimal sum)
        {
            currentDateTime = DateTime.Now;
            amount = sum;
        }
        public string showInfo()
        {
            return currentDateTime.ToString() + ' ' + amount.ToString()+'\r';
        } 
    }
}
