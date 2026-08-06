using Assignment_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount[] Accounts =
            {
                new BankAccount(),
                new SavingsAccount()

            };

            Accounts[0].Deposit(50);
            Accounts[1].Deposit(100);

            foreach (var account in Accounts)
            {
                Console.WriteLine(account.GetAccountType());
                Console.WriteLine(account.Balance.ToString());
            }

        }
    }
}
