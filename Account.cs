using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking_system
{
    public abstract class Account
    {
            
        private static long num = 0;
        private long number;
        private decimal balance;

        public decimal Balance
        {
            get
            {
                return balance;
            }
        }

        public long Number
        {
            get
            {
                return number;
            }
        }

        public Account()
        {
            balance = 0;
            number = ++num;
        }

        public Account(decimal amount)
        {
            balance = balance + amount;
            number = ++num;
        }

        public override string ToString()
        {
            string strout;
            strout = string.Format("Account num: {0}", number);
            strout = strout + string.Format("Ballance:{0:c}", balance);

            return strout;
        }

        public void credit(decimal amount)
        {
            balance = balance + amount;
        }

        virtual public void debit(decimal amount)
        {
            balance = balance - amount;
        }



    }



    public class creditAccount : Account
    {
        private decimal ODlimit = 100;
        public decimal ODLimit
        {
            get
            {
                return ODlimit;
            }
        }

        public creditAccount(decimal amount) : base(amount)
        {
            ODlimit = 100;

        }

        public creditAccount() : base()
        {
            ODlimit = 100;
        }

        public creditAccount(decimal amount, decimal limit) : base()
        {
            ODlimit = 100;
        }

        public override string ToString()
        {
            string strout;
            strout = "Credit account \n" + base.ToString();
            strout = strout + string.Format("\n OD Limit:{0:c}", ODlimit);
            return strout;
        }

        public override void debit(decimal amount)
        {
            if (amount < (ODlimit))
                throw new Exception("insufficient funds - Transaction Cancelled");
            else
                base.debit(amount);
        }


    }





    public class depositAccount : Account
    {
        private double rate = 0;
        public double Rate
        {
            get
            {
                return rate;
            }
            set
            {
                rate = value;
            }
        }

        public depositAccount(decimal amount) : base(amount)
        {
            rate = 0.0;
        }

        public depositAccount() : base()
        {
            rate = 0.0;
        }

        public depositAccount(decimal amount, decimal limit) : base(amount)
        {
            rate = 0.0;
        }


        public override string ToString()
        {
            string strout;
            strout = "DepositAccount \n" + base.ToString();
            strout = strout + string.Format("\n Rate:{0:f2}", rate);
            return strout;
        }





    }
}
    

