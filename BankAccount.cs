using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba11._1
{
    public enum TypeOfAccount
    {
        DEBIT,
        CREDIT,
        DEPOSIT
    }
    class BankAccount:IDisposable
    {
        protected int _number;
        protected decimal _balance;
        protected TypeOfAccount _typeAccount;
        static int _counter = 1;
        private System.Collections.Queue transactions = new System.Collections.Queue();
        private bool disposed = false;

        public BankAccount()
        {
            _number = Increase();
        }
        public BankAccount(decimal balance)
        {
            _balance = balance;
            _number = Increase();
        }
        public BankAccount(TypeOfAccount typeAccount)
        {
            _typeAccount = typeAccount;
            _number = Increase();
        }
        public BankAccount(decimal balance, TypeOfAccount typeAccount)
        {
            _typeAccount = typeAccount;
            _balance = balance;
            _number = Increase();
        }
        public int Increase()
        {
            return _counter++;
        }
        public System.Collections.Queue accountTransactions
        {
            get { return transactions; }

        }
        public int accountNumber
        {
            get { return _number; }
            set { _number = value; }
        }
        public decimal accountBalance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public TypeOfAccount accountType
        {
            get { return _typeAccount; }
            set { _typeAccount = value; }
        }
        public void PutMoney(int money)
        {
            _balance += money;
            transactions.Enqueue(new BankTransaction(money));
        }
        public void TakeMoney(int money)
        {
            if (_balance >= money)
            {
                _balance -= money;
                transactions.Enqueue(new BankTransaction(-money));
            }
        }
        public void TransferMoney(ref BankAccount transferAccaunt, int amount)
        {
            if (transferAccaunt.accountBalance >= amount)
            {
                transferAccaunt.accountBalance -= amount;
                this.accountBalance += amount;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            foreach(BankTransaction bank in this.accountTransactions)
            {
                System.IO.File.WriteAllText("result.txt", bank.showInfo());
            }
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }
                disposed = true;
            }
        }
        ~BankAccount()
        {
            Dispose(false);
        }
    }
}

