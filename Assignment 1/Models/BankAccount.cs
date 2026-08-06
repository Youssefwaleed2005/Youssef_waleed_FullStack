using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Models
{
    internal class BankAccount
    {
        protected decimal _balance;

        public  decimal Balance{ get { return _balance; } }

        public string Owner;


        public void Deposit(decimal ammount )
        {
            if (ammount > 0)
                this._balance += ammount;
            else throw new Exception();

        }

        public void Withdraw(decimal ammount)
        {
            if (ammount > 0 && this._balance > ammount)
                this._balance -= ammount;
            else throw new Exception();
        }

        public virtual String GetAccountType()
        {
            return "Standard";
        }
    }
}
