using System;

namespace AtmApplication
{
	class account                                           //a class which creates objects accounts                     
	{
		public string name, ph,history;                    //history stores transaction history
		private int pin;                                   //stores pin
		private double amount;
		public account(string pname, string pph,int ppin,int accountno)      //account constructor
		{
			name = pname;
			history = "\n******************************TRANSACTION HISTORY*******************************\n";
			ph = pph;
			pin=ppin;
			amount = 0.0;
		}
		public double setAmount(double pamount,bool op)               //amount setter  method
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



    class program
    {
        public static void Main()
        {
            int choice, i = -1,num,ppin,acntno;
            double amt;
            account[] acnts = new account[100];
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.Write("\n\n\n\n\n\n\n\n\n\t\t\t*************************************TECHIE'S BANK*******************************");
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\tenter a key to continue...");
            Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("WELCOME TO TECHIE'S BANK ATM SERVICE\n");
                Console.WriteLine("\t\t1. CREATE ACCOUNT\n");
                Console.WriteLine("\t\t2. DEPOSIT \n");
                Console.WriteLine("\t\t3. WITHDRAW \n");
                Console.WriteLine("\t\t4. TRANSFER\n");
                Console.WriteLine("\t\t5. TRANSACTION HISTORY\n");
                Console.WriteLine("\t\t6. EXIT");
                Console.WriteLine("********************************\n\n");
                Console.WriteLine("ENTER YOUR CHOICE : ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:                                        //account creation
                        i += 1;
                        string name, ph;
                        int pin;
                        Console.WriteLine("enter your name");
                        name = Console.ReadLine();
                        Console.WriteLine("enter your phno:");
                        ph = Console.ReadLine();
                        Console.WriteLine("create a 4 digit pin");
                        pin = int.Parse(Console.ReadLine());

                        acnts[i] = new account(name, ph, pin, i);
                        Console.Write("account created succesfully\n your acount number is" + Convert.ToString(i + 1000));

                        Console.ReadKey(true);


                        break;



                    case 2:                                             //deposition section
                        Console.WriteLine("Enter your account no");              
                         num = int.Parse(Console.ReadLine()) - 1000;

                        if (num <= i)
                        {
                            Console.WriteLine("Enter the amount to deposit");
                            amt = double.Parse(Console.ReadLine());
                            Console.WriteLine("\nSuccessfully deposited the money and your current balance is");
                            acnts[num].history += "\ndeposited the money   " + Convert.ToString(amt)+"\n";
                            Console.WriteLine(acnts[num].setAmount(amt, true));

                        }
                        else                                         
                        {
                            Console.WriteLine("account not present");
                        }
                        Console.ReadKey(true);

                        break;



                    case 3:                                            //withdraw section
                        Console.WriteLine("Enter your account no");
                        num = int.Parse(Console.ReadLine()) - 1000;
                        Console.WriteLine("Enter your pin");
                        ppin = int.Parse(Console.ReadLine());

                        if (num <= i && acnts[num].getPin() == ppin)
                        {
                            Console.WriteLine("Enter the amount to withdraw");
                            amt = double.Parse(Console.ReadLine());
                            if (acnts[num].getAmount() >= amt)
                            {
                                Console.WriteLine("collect your amount");
                                acnts[num].setAmount(amt, false);
                                Console.WriteLine("\nSuccessfully withdrawn the money and your current balance is");
                                acnts[num].history += "\ndebited the money    " + Convert.ToString(amt) + "\n";

                                Console.WriteLine(acnts[num].getAmount());


                            }
                            else
                            { Console.WriteLine("insufficient balanace"); }


                        }
                        else
                        {
                            Console.WriteLine("account not present");
                        }
                        Console.ReadKey(true);

                        break;



                    case 4:                                                 //transfer section
                        Console.WriteLine("Enter your account no");
                        num = int.Parse(Console.ReadLine()) - 1000;
                        Console.WriteLine("Enter your pin");
                        ppin = int.Parse(Console.ReadLine());
                        if (num <= i && acnts[num].getPin() == ppin)
                        {
                            Console.WriteLine("Enter the account no to transfer");
                            acntno = int.Parse(Console.ReadLine()) - 1000;
                            if (acntno <= i)
                            {
                                Console.WriteLine("Enter the amount  to transfer");

                                amt = double.Parse(Console.ReadLine());

                                if (acnts[num].getAmount() >= amt)
                                {
                                    acnts[acntno].setAmount(amt, true);
                                    acnts[num].history    +="\nmoney transferred(debited) by   "+acnts[acntno].name +"      "+ Convert.ToString(amt) + "\n";
                                    acnts[acntno].history += "\nmoney transferred(credited) by "+acnts[num].name+"      "+ Convert.ToString(amt) + "\n";

                                    Console.WriteLine("\nSuccessfully transferred the money and your current balance is");
                                    Console.WriteLine(acnts[num].setAmount(amt, false));


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
                        Console.ReadKey(true);
                        break;

                    case 5:                                                          //transaction history section
                        Console.WriteLine("Enter your account no");
                        num = int.Parse(Console.ReadLine()) - 1000;
                        Console.WriteLine("Enter your PIN");
                        ppin = int.Parse(Console.ReadLine());
                        if (num <= i && acnts[num].getPin()==ppin)
                        {
                            Console.Clear();
                            Console.Write(acnts[num].history);
                            Console.WriteLine("your current balance is   " + acnts[num].getAmount());
                            
                        }
                        else
                        {
                            Console.WriteLine("invalid account credentials");
                        }
                        Console.ReadKey(true);
                        break;
                    
                    
                    case 6:                                                        //exit section
                        System.Environment.Exit(0);
                        break;
                }
            }
        }
    }
}