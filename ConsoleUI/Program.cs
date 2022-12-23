using BrownfieldLibrary;
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

            List<TimeSheetEntry> timeSheets = LoadTimeSheets();

            SendEmailToCampany(timeSheets, "acme", 150);
            SendEmailToCampany(timeSheets, "abc", 125);
           
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

        private static List<TimeSheetEntry> LoadTimeSheets()
        {
            List<TimeSheetEntry> output = new List<TimeSheetEntry>();
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

                TimeSheetEntry timeSheet = new TimeSheetEntry();
                timeSheet.HoursWorked = houresWorked;
                timeSheet.WorkDone = workDone;
                output.Add(timeSheet);

                Console.Write("Do you want to enter more time:");
                entreMoreTimeSheet = Console.ReadLine();

            } while (entreMoreTimeSheet.ToLower() == "yes");

            return output;
        }
        public static void SendEmailToCampany(List<TimeSheetEntry> timeSheets, string campanyName, int hourRate)
        {
            double totalPaidHoures = TimeSheetProcessor.GetHouresWorkedForCompany(timeSheets, campanyName);

            Console.WriteLine($"Simulating Sending email to {campanyName}");
            Console.WriteLine("Your bill is $" + totalPaidHoures * hourRate + " for the hours worked.");
        }
    }

    
}
