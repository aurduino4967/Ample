using System;
using AtmApplication.MODEL;
using AtmApplication.SERVICE;

namespace AtmApplication.CLI
{
    class Program
    {
        public class Option
        {
            public static void Print(String msg)
            {
                Console.WriteLine(msg);
            }
            public static void ServiceOpt()
            {
                Console.Clear();
                Print("WELCOME TO TECHIE'S BANK ATM SERVICE\n");
                Print("\t\t1. CREATE ACCOUNT\n");
                Print("\t\t2. DEPOSIT \n");
                Print("\t\t3. WITHDRAW \n");
                Print("\t\t4. TRANSFER\n");
                Print("\t\t5. TRANSACTION HISTORY\n");
                Print("\t\t6. EXIT");
                Print("********************************\n\n");
                Print("ENTER YOUR CHOICE : ");
            }
            public static void Bankdisplay()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Print("\n\n\n\n\n\n\n\n\n\t\t\t*************************************TECHIE'S BANK*******************************");
                Print("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\tenter a key to continue...");
                Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void Wait()
        {
            Wait();
        }
        public enum opt
        {
            create=1,
            deposit,
            withdraw,
            transfer,
            history,
            exit
        }
        public static void Main()
        {
            int choice;
            Option.Bankdisplay();
            while (true)
            {
                Option.ServiceOpt();                                                    //service options

                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case (int)opt.create:                                            //account creation
                        Service.Create();
                        Wait();
                        break;

                    case (int)opt.deposit:                                          //deposition section
                        Service.Deposit();
                        Wait();
                        break;



                    case (int)opt.withdraw:                                          //withdraw section
                        Service.Withdraw();
                        Wait();

                        break;



                    case (int)opt.transfer:                                           //transfer section
                        Service.Transfer();
                        Wait();
                        break;

                    case (int)opt.history:                                            //transaction history section
                        Service.History();
                        Wait();
                        break;


                    case (int)opt.exit:                                                        //exit section
                        System.Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
