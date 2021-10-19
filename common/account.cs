using System;

namespace AtmApplication.Accounts
{
    public class Account                                           //a class which creates objects accounts                     
    {
        public string name, ph, history;                    //history stores transaction history
        private int pin;                                   //stores pin
        private double amount;
        public Account(string pname, string pph, int ppin, int accountno)      //account constructor
        {
            name = pname;
            history = "\n******************************TRANSACTION HISTORY*******************************\n";
            ph = pph;
            pin = ppin;
            amount = 0.0;
        }
        public double setAmount(double pamount, bool op)               //amount setter  method
        {
            if (op == true)
            {
                amount += pamount;
            }
            else
                amount -= pamount;
            return amount;
        }
        public int getPin()                                        //pin getter method
        {
            return pin;
        }
        public double getAmount()
        {
            return amount;

        }
    }
}
