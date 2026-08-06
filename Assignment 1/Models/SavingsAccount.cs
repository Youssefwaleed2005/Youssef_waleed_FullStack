using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Models
{
    internal class SavingsAccount:BankAccount
    {
        public decimal InterestRate;

        public void ApplyInterest()
        {
            this._balance *= InterestRate;    
        }

        public override string GetAccountType()
        {
            return "Savings";
        }
    }
}
