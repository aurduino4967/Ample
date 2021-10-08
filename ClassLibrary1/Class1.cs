using System;
using AtmApplication.Accounts;
using AtmApplication.Readers;
namespace AtmApplication.Services
{
    public class Service
    {
        public static int Create(int i, Account[] ac)
        {
            
            string name, ph;
            int pin;
            Console.WriteLine("enter your name");
            name = Console.ReadLine();

            Console.WriteLine("enter your phno:");
            ph = Console.ReadLine();
            Console.WriteLine("create a 4 digit pin");
            pin = Reader.PinRead();
            if (pin != -245)
            {
                i += 1;
                ac[i] = new Account(name, ph, pin, i);
                Console.Write("account created succesfully\n your acount number is" + Convert.ToString(i + 1000));
                return i;
            }
            else
            {
                Console.WriteLine("account can't be created");
                return i;
            }

        }
        public static void Deposit(int i, Account[] ac)
        {
            Console.WriteLine("Enter your account no");
            int num = Reader.AccountRead()-1000;
            if (num <= i)
            {
                Console.WriteLine("Enter the amount to deposit");
                double amt = Reader.AmountRead();
                if (amt > 0)
                {
                    Console.WriteLine("\nSuccessfully deposited the money and your current balance is");
                    ac[num].history += "\ndeposited the money   " + Convert.ToString(amt) + "\n";
                    Console.WriteLine(ac[num].setAmount(amt, true));
                }
                else
                    Console.WriteLine("Invalid amount transfer");

            }
            else
            {
                Console.WriteLine("account not present");
            }

        }

        public static void Withdraw(int i, Account[] ac)
        {
            Console.WriteLine("Enter your account no");
            int num = Reader.AccountRead() - 1000;
            Console.WriteLine("Enter your pin");
            int ppin = Reader.PinRead();

            if (num <= i && ac[num].getPin() == ppin)
            {
                Console.WriteLine("Enter the amount to withdraw");
                double amt = double.Parse(Console.ReadLine());
                if (ac[num].getAmount() >= amt)
                {
                    Console.WriteLine("collect your amount");
                    ac[num].setAmount(amt, false);
                    Console.WriteLine("\nSuccessfully withdrawn the money and your current balance is");
                    ac[num].history += "\ndebited the money    " + Convert.ToString(amt) + "\n";

                    Console.WriteLine(ac[num].getAmount());


                }
                else
                { Console.WriteLine("insufficient balanace"); }


            }
            else
            {
                Console.WriteLine("account not present");
            }


        }

        public static void Transfer(int i,Account[] ac)
        {
            Console.WriteLine("Enter your account no");
            int num = Reader.AccountRead()-1000;
            Console.WriteLine("Enter your pin");
            int ppin = Reader.PinRead();
            if (num <= i && ac[num].getPin() == ppin)
            {
                Console.WriteLine("Enter the account no to transfer");
                int acntno = Reader.AccountRead()-1000;
                if (acntno <= i)
                {
                    Console.WriteLine("Enter the amount  to transfer");

                    double amt = double.Parse(Console.ReadLine());

                    if (ac[num].getAmount() >= amt)
                    {
                        ac[acntno].setAmount(amt, true);
                        ac[num].history += "\nmoney transferred(debited) to   " + ac[acntno].name + "      " + Convert.ToString(amt) + "\n";
                        ac[acntno].history += "\nmoney transferred(credited) by " + ac[num].name + "      " + Convert.ToString(amt) + "\n";

                        Console.WriteLine("\nSuccessfully transferred the money and your current balance is");
                        Console.WriteLine(ac[num].setAmount(amt, false));


                    }
                    else
                    {
                        Console.WriteLine("insufficient balance");
                    }
                }
                else
                {
                    Console.WriteLine("invalid account");
                }
            }
            else
            {
                Console.WriteLine("account may not present or your passcode is wrong");
            }
        }

        public static void History(int i,Account[] ac)
        {
            Console.WriteLine("Enter your account no");
            int num = Reader.AccountRead()-1000;
            Console.WriteLine("Enter your PIN");
           int ppin=Reader.PinRead();
            if (num <= i && ac[num].getPin() == ppin)
            {
                Console.Clear();
                Console.Write(ac[num].history);
                Console.WriteLine("your current balance is   " + ac[num].getAmount());

            }
            else
            {
                Console.WriteLine("invalid account credentials");
            }
        }
    }
}
