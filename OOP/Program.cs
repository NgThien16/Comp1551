using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class BankAccount
    {
        // private and get&set demonstrate encapsulation
        private double balance;
        public double Balance
        {
            get { return balance; } 
            set { balance = value; }
        }
       
        // overloadid
        public BankAccount()
        {

        }
        public BankAccount(double balance)
        {
            this.balance = balance;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Successfull depository: {amount} and your balance: {balance}");
            }
            else
            {
                Console.WriteLine("Amount must be positive");
            }

        }
        public void WithDraw(double amount)
        {
            if (balance > 50 && amount > 0)
            {
                balance -= amount;
                Console.WriteLine($"Successfully withdraw:{amount} and your balance: {balance}");
            }
            else
            {
                Console.WriteLine("Amount must be positive and the balance >50");
            }

        }
        public double GetBalance()
        {
            Console.WriteLine($"The balance now is:{balance}");
            return balance;
        }

    }

   
    internal class Program
    { 
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();
            account.Deposit(100);
            account.WithDraw(25);
            account.GetBalance();
            
        }
    }
}
