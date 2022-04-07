using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciple
{
    interface ISavingAccount
    {
        decimal calculateInterest();
    }

    public class SavingAccountOC
    {
        public decimal interest, balance;
    }
    internal class SalaryAccountOpenClosedPrinciple : SavingAccountOC, ISavingAccount
    {
        public decimal calculateInterest()
        {
            interest = balance * (decimal)0.5;
            //Calculate interest for regular saving account based on rules and   
            return interest;
        }
    }

    internal class RegularSavingAccount : SavingAccountOC, ISavingAccount
    {
        public decimal calculateInterest()
        {
            //Calculate interest for regular saving account based on rules and   
            // regulation of bank  
            interest = balance *(decimal) 0.4;
            if(balance < 1000) 
                interest -= balance * (decimal)0.2;
            if(balance < 50000)
                interest += balance * (decimal)0.4;
            return interest;
        }
    }
}
