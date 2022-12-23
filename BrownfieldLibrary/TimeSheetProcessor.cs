using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownfieldLibrary
{
    public class TimeSheetProcessor
    {
        public static double GetHouresWorkedForCompany(List<TimeSheetEntry> timeSheets, string campanyName)
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
    }
}
