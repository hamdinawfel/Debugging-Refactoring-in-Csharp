using BrownfieldLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownfieldLibrary
{
    public class TimeSheetProcessor
    {
        public static double GetHouresWorkedForCompany(List<TimeSheetEntryModel> timeSheets, string campanyName)
        {
            double output = 0;
            for (int i = 0; i < timeSheets.Count; i++)
            {
                if (timeSheets[i].WorkDone.ToLower().Contains(campanyName))
                {
                    output += timeSheets[i].HoursWorked;
                }
            }

            return output;
        }

        public static decimal CalculateEmployeePaid(List<TimeSheetEntryModel> timeSheets, EmployeeModel employee)
        {
            decimal output = 0;
            double totalPaidHoures = 0;
            for (int i = 0; i < timeSheets.Count; i++)
            {
                totalPaidHoures += timeSheets[i].HoursWorked;
            }
            if (totalPaidHoures > 40)
            {
                output = ((((decimal)totalPaidHoures - 40M) * employee.HourlyRate * 1.5M) + (40M * employee.HourlyRate));
            }
            else
            {
                output = (decimal)totalPaidHoures * employee.HourlyRate;
            }

            return output;
        }
    }
}
