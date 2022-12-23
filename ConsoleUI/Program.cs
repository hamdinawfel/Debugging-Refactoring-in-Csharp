using BrownfieldLibrary;
using BrownfieldLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO 
// 1 : add database for data access
// 2 : replace Simulating seding email with real email sender
// 3 : add frontend side with Razor page
// 4 : generate csv file 
// 5 : add unit test
// 6 : rebuild the application wthe clean architecture
// 7 : deploy the app
// 8 : open sourced the app and create pull request conduct file*
// 9 : write a blog post

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TimeSheetEntryModel> timeSheets = LoadTimeSheets();
            List<CustomerModel> customers = DataAccess.GetCustomers();
            EmployeeModel currentEmployee = DataAccess.GetCurrentEmployee();
            
            customers.ForEach(x => SendEmailToCustomer(timeSheets, x));

            PayEmployee(timeSheets, currentEmployee);

            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
            Console.WriteLine();
        }

        private static void PayEmployee(List<TimeSheetEntryModel> timeSheets, EmployeeModel employee)
        {
            decimal employeePaidAmount = TimeSheetProcessor.CalculateEmployeePaid(timeSheets, employee);
            Console.WriteLine($" { employee.Name } will get paid $ {employeePaidAmount} for your time.");
            Console.WriteLine();
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
        private static void SendEmailToCustomer(List<TimeSheetEntryModel> timeSheets, CustomerModel customer)
        {
            double totalPaidHoures = TimeSheetProcessor.GetHouresWorkedForCompany(timeSheets, customer.CustomerName);

            Console.WriteLine($"Simulating Sending email to { customer.CustomerName }");
            Console.WriteLine("Your bill is $" + (decimal)totalPaidHoures * customer.HourlyRate + " for the hours worked.");
            Console.WriteLine();
        }
    }
}
