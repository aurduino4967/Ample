using System;
using AtmApplication.Options;
using AtmApplication.Accounts;
using AtmApplication.Services;
namespace AtmApplication.CLI
{
    class Program
    {
        enum opt
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
            int choice, i = -1;    //stores the count of accounts
            Account[] acnts = new Account[100];       //array of accounts
            Option.Bankdisplay();
            while (true)
            {
                Option.ServiceOpt();                                                    //service options

                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case    (int)opt.create:                                            //account creation
                        i = Service.Create(i, acnts);
                        Console.ReadKey(true);
                        break;

                    case    (int)opt.deposit:                                          //deposition section
                        Service.Deposit(i, acnts);
                        Console.ReadKey(true);
                        break;



                    case    (int)opt.withdraw:                                          //withdraw section
                        Service.Withdraw(i, acnts);
                        Console.ReadKey(true);

                        break;



                    case    (int)opt.transfer:                                           //transfer section
                        Service.Transfer(i, acnts);
                        Console.ReadKey(true);
                        break;

                    case    (int)opt.history:                                            //transaction history section
                        Service.History(i, acnts);
                        Console.ReadKey(true);
                        break;


                     case    (int)opt.exit:                                                        //exit section
                        System.Environment.Exit(0);
                        break;
                }
            }
        }
    }
}