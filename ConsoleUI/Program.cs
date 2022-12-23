using BrownfieldLibrary;
using BrownfieldLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Please note - THIS IS A BAD APPLICATION - DO NOT REPLICATE WHAT IT DOES
// This application was designed to simulate a poorly-built application that
// you need to support. Do not follow any of these practices. This is for 
// demonstration purposes only. You have been warned.
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string w;
            int i;
            double totalPaidHoures;

            List<TimeSheetEntryModel> timeSheets = LoadTimeSheets();

            List<CustomerModel> customers = DataAccess.GetCustomers();
            foreach (var customer in customers)
            {
                SendEmailToCustomer(timeSheets, customer.CustomerName, customer.HourlyRate);
            }
           
            totalPaidHoures = 0;
            for (i = 0; i < timeSheets.Count; i++)
            {
                totalPaidHoures += timeSheets[i].HoursWorked;
            }
            if (totalPaidHoures > 40)
            {
                Console.WriteLine("You will get paid $" + (((totalPaidHoures-40) * 15) + (40 * 10 )) + " for your work.");
            }
            else
            {
                Console.WriteLine("You will get paid $" + totalPaidHoures * 10 + " for your time.");
            }
            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }

        private static List<TimeSheetEntryModel> LoadTimeSheets()
        {
            List<TimeSheetEntryModel> output = new List<TimeSheetEntryModel>();
            string entreMoreTimeSheet = "";
            do
            {
                Console.Write("Enter what you did: ");
                string workDone = Console.ReadLine();
                Console.Write("How long did you do it for: ");

                string rowTimeWorkd = Console.ReadLine();
                double houresWorked;
                while (!double.TryParse(rowTimeWorkd, out houresWorked))
                {
                    Console.WriteLine();
                    Console.WriteLine("Invaled intred work");
                    Console.Write("How long did you do it for: ");
                    rowTimeWorkd = Console.ReadLine();
                }

                TimeSheetEntryModel timeSheet = new TimeSheetEntryModel();
                timeSheet.HoursWorked = houresWorked;
                timeSheet.WorkDone = workDone;
                output.Add(timeSheet);

                Console.Write("Do you want to enter more time:");
                entreMoreTimeSheet = Console.ReadLine();

            } while (entreMoreTimeSheet.ToLower() == "yes");

            return output;
        }
        public static void SendEmailToCustomer(List<TimeSheetEntryModel> timeSheets, CustomerModel customer)
        {
            double totalPaidHoures = TimeSheetProcessor.GetHouresWorkedForCompany(timeSheets, customer.CustomerName);

            Console.WriteLine($"Simulating Sending email to { customer.CustomerName }");
            Console.WriteLine("Your bill is $" + (decimal)totalPaidHoures * customer.HourlyRate + " for the hours worked.");
        }
    }

    
}
