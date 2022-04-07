using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciple
{
    internal class SavingAccount
    {

                double amount=55, interest;
        public double CalculateInterest(string accountType, double balance)
        {
            if (accountType == "Saving")
            {
                interest = balance * 0.4;
                if (balance < 5000)
                    interest += amount * 0.4;
                if(balance < 1000)
                     interest -= balance * 0.2;
            }
            else if(accountType == "Salary")
            {
                interest = balance * 0.5;
            }
                return interest;
        }
    }
}
